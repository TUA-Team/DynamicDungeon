using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicDungeon.DungeonWorld;
using InfinityCore.Worlds;
using InfinityCore.Worlds.Chunk;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DynamicDungeon.DungeonBase
{
    class StartingRoom : BaseRoom
    {
        public StartingRoom(Chunk location) : base(location)
        {
        }

        internal override Rectangle Generate()
        {
            Point vector = new Point(Main.maxTilesX / 2, Main.maxTilesY / 2);
            Point topleft = ModContent.GetInstance<InfinityCoreWorld>()[vector.X, vector.Y].Position.ToPoint();

            for (int x = topleft.X + 3; x < topleft.X + 97; x++)
            {
                for (int y = topleft.Y + 3; y < topleft.Y + 73; y++)
                {
                    Main.tile[x, y].active(false);
                }
            }

            for (int x = topleft.X + 20; x < topleft.X + 100 - 20; x++)
            {
                Main.tile[x, topleft.Y + 32].active(true);
                Main.tile[x, topleft.Y + 33].active(true);
                Main.tile[x, topleft.Y + 34].active(true);

                Main.tile[x, topleft.Y + 32].type = TileID.BlueDungeonBrick;
                Main.tile[x, topleft.Y + 33].type = TileID.BlueDungeonBrick;
                Main.tile[x, topleft.Y + 34].type = TileID.BlueDungeonBrick;
            }

            NPC.NewNPC((topleft.X + 37) * 16 - 50, (topleft.Y + 32) * 16 - 132, DynamicDungeon.infinityCore.NPCType("DungeonCrystal"));

            Main.spawnTileX = topleft.X + 50;
            Main.spawnTileY = topleft.Y + 30;

            DungeonSubworld.inDungeon = true;

            return new Rectangle(topleft.X, topleft.Y, 75, 75);
        }
    }
}
