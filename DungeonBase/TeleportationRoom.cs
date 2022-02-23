using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityCore.Worlds.Chunk;
using Microsoft.Xna.Framework;
using Terraria;

namespace DynamicDungeon.DungeonBase
{
	class TeleportationRoom : BaseRoom
	{

		internal TeleportationRoom(Chunk location) : base(location)
		{
			width = 15;
			height = 20;
			roomBound = new Rectangle((int) location.Position.X, (int) location.Position.Y, width, height);
		}

        internal override Rectangle Generate()
        {
            for (int i = roomBound.X; i < roomBound.X + width; i++)
			{
				for (int j = roomBound.Y; j < roomBound.Y + height; j++)
				{
					Main.tile[i, j].active(false);
				}
			}

			NPC.NewNPC((roomBound.X + roomBound.Width / 2) * 16, (roomBound.Y + roomBound.Y) * 16 + 304, DynamicDungeon.instance.NPCType("DungeonCrystal"));

			return roomBound;
		}

        internal override void Activate()
        {
            throw new NotImplementedException();
        }
    }
}
