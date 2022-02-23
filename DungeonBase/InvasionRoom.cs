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
	class InvasionRoom : BaseRoom
	{
        public InvasionRoom(Chunk chunk) : base(chunk)
        {
        }

        internal override Rectangle Generate()
        {
            Point vector = new Point((int)chunk.Position.X, (int)chunk.Position.Y);
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

                Main.tile[x, topleft.Y + 32].type = TileID.AdamantiteBeam;
                Main.tile[x, topleft.Y + 33].type = TileID.AdamantiteBeam;
                Main.tile[x, topleft.Y + 34].type = TileID.AdamantiteBeam;
            }


            return new Rectangle(topleft.X, topleft.Y, 100, 75);
        }

        internal override void Activate()
        {
            throw new NotImplementedException();
        }
    }
}
