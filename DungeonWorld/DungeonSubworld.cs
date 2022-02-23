using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DynamicDungeon.DungeonBase;
using DynamicDungeon.DungeonEnums;
using InfinityCore.Worlds;
using InfinityCore.Worlds.Chunk;
using Microsoft.Xna.Framework;
using SubworldLibrary;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace DynamicDungeon.DungeonWorld
{
	public class DungeonSubworld : Subworld
	{
		public static int floor;
		public static bool inDungeon;

		public List<BaseRoom> roomList;

		private bool _teleportationRoomGenerated;
		private int secretRoomAmount = 0;

		private int roomAmount = (int) MathHelper.Max(10 * floor + WorldGen.genRand.Next(0, 5), 120);


        public override void Load()
		{
			Main.worldRate = 0;
			Main.dayTime = true;
			inDungeon = true;
        }

		public override void Unload()
		{
			Main.worldRate = 1;
			inDungeon = false;
		}

		public override int width => 5000;
		public override int height => 2400;
		public override ModWorld modWorld => ModContent.GetInstance<DungeonWorld>();
		public override List<GenPass> tasks => RoomGenPasses();

		public override bool saveSubworld => false;

		public ushort brickType = WorldGen.genRand.Next(new ushort[] { TileID.BlueDungeonBrick, TileID.GreenDungeonBrick, TileID.PinkDungeonBrick });

		public List<GenPass> RoomGenPasses()
		{
			return new List<GenPass>
			{
				new PassLegacy("Resizing Chunk", progress =>
                {
                    //progress.Message = "Resizing chunk";
                    //DynamicDungeon.infinityCore.Call("SetCustomChunkSize", 100, 75);
                }, 1f), 
				new PassLegacy("InitializingDungeon", progress =>
				{
					progress.Message = "Filling up world";
					for (int i = 0; i < width; i++)
					{
						for (int j = 0; j < height; j++)
						{
                            Main.tile[i, j].active(true);
							Main.tile[i, j].type = brickType;
							Main.tile[i, j].wall = WallID.BlueDungeonTileUnsafe;
						}
					}
					progress.Message = "Setting room position";
                    DungeonGenerator dungeonGenerator = new DungeonGenerator(13, 13);
				    dungeonGenerator.GenerateDungeon();
				    progress.Message = "Generating room";
				    Point vector = new Point(Main.maxTilesX / 2, Main.maxTilesY / 2);
				    var dungeon = dungeonGenerator.GetGeneratedDungeon();

				    for (int i = 0; i < 13; i++)
				    {
					    for (int j = 0; j < 13; j++)
					    {
						    var dungeonRoom = dungeon[dungeonGenerator.GetIndex(i, j)];
							
						    if (dungeonRoom != RoomType.noRoom)
						    {
                                DynamicDungeon.instance.Logger.Debug($"{i * 100} : {j * 75}");
								switch (dungeonRoom)
							    {
								    case RoomType.RewardRoom:
                                        DynamicDungeon.instance.Logger.Debug("Reward room");
									    ModContent.GetInstance<InfinityCoreWorld>()[i * 100, j * 75].GetModChunk<DungeonChunk.DungeonChunk>().SetRoomType(new RewardRoom(ModContent.GetInstance<InfinityCoreWorld>()[i * 100, j * 75]));
									    break;
								    case RoomType.trapRoom:
                                        DynamicDungeon.instance.Logger.Debug("Trap room");
										ModContent.GetInstance<InfinityCoreWorld>()[i * 100, j * 75].GetModChunk<DungeonChunk.DungeonChunk>().SetRoomType(new InvasionRoom(ModContent.GetInstance<InfinityCoreWorld>()[i * 100, j * 75]));
									    break;
								    case RoomType.StartingRoom :
                                        DynamicDungeon.instance.Logger.Debug("Starting room");
										ModContent.GetInstance<InfinityCoreWorld>()[i * 100, j * 75].GetModChunk<DungeonChunk.DungeonChunk>().SetRoomType(new StartingRoom(ModContent.GetInstance<InfinityCoreWorld>()[i * 100, j * 75]));
									    break;
								    case RoomType.BossRoom :
                                        DynamicDungeon.instance.Logger.Debug("Boss room");
										ModContent.GetInstance<InfinityCoreWorld>()[i * 100, j * 75].GetModChunk<DungeonChunk.DungeonChunk>().SetRoomType(new BossRoom(NPCID.Skeleton, ModContent.GetInstance<InfinityCoreWorld>()[i * 100, j * 75]));
									    break;
									default:
                                        DynamicDungeon.instance.Logger.Debug("Default room");
										ModContent.GetInstance<InfinityCoreWorld>()[i * 100, j * 75].GetModChunk<DungeonChunk.DungeonChunk>().SetRoomType(new BasicRoom(ModContent.GetInstance<InfinityCoreWorld>()[i * 100, j * 75]));
										break;
                                }
                                ModContent.GetInstance<InfinityCoreWorld>()[i * 100, j * 75].GetModChunk<DungeonChunk.DungeonChunk>().Generate(progress);

							}
					    }
				    }
				}, 1f),
            };
		}

        public static void PreAddPass(List<GenPass> pass)
        {
			pass.Add(new PassLegacy("Test", progress =>
            {
	            progress.Message = "Resizing chunk";
                DynamicDungeon.infinityCore.Call("SetCustomChunkSize", 100, 75);
                //progress.Message = "Resizing chunk";
                //DynamicDungeon.infinityCore.Call("SetCustomChunkSize", 100, 75);
                //ModContent.GetInstance<InfinityCoreWorld>()[vector.X, vector.Y].GetModChunk<DungeonChunk.DungeonChunk>().SetRoomType(new StartingRoom(ModContent.GetInstance<InfinityCoreWorld>()[vector.X, vector.Y]));
            }));
        }
    }
}
