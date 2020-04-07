using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicDungeon.DungeonBase;
using DynamicDungeon.DungeonEnums;
using InfinityCore.Worlds;
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
        }

		public override void Unload()
		{
			Main.worldRate = 1;
			inDungeon = false;
		}

		public override int width => 5000;
		public override int height => 2400;
		public override ModWorld modWorld => null;
		public override SubworldGenPass[] tasks => RoomGenPasses();

		public override bool saveSubworld => false;

		public ushort brickType = WorldGen.genRand.Next(new ushort[] { TileID.BlueDungeonBrick, TileID.GreenDungeonBrick, TileID.PinkDungeonBrick });


		public SubworldGenPass[] RoomGenPasses()
		{
			return new SubworldGenPass[]
			{
				new SubworldGenPass("Resizing Chunk", 1f, progress =>
                {
                    progress.Message = "Resizing chunk";
                    DynamicDungeon.infinityCore.Call("SetCustomChunkSize", 100, 75);
                }), 
				new SubworldGenPass("InitializingDungeon", 1f, progress =>
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
                }),
            };
		}

        public static void PreAddPass(WorldGenerator generator)
        {
            InfinityCoreWorld.specialPostChunkGenPasses.Add(new PassLegacy("Test", progress =>
            {
                progress.Message = "Generating room";
                Point vector = new Point(Main.maxTilesX / 2, Main.maxTilesY / 2);
                ModContent.GetInstance<InfinityCoreWorld>()[vector.X, vector.Y].GetModChunk<DungeonChunk.DungeonChunk>().SetRoomType(new StartingRoom(ModContent.GetInstance<InfinityCoreWorld>()[vector.X, vector.Y]));
            }));
        }
    }
}
