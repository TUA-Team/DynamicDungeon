using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicDungeon.DungeonEnums;
using InfinityCore.Worlds.Chunk;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;

namespace DynamicDungeon.DungeonBase
{
	internal class HallRoom : BaseRoom
	{
		internal BaseRoom connection;
		internal HallRoomDirection direction;


		public HallRoom(HallRoomDirection direction, Point xy, int lenght, Chunk position) : base(position)
		{
			this.direction = direction;
			if (direction == HallRoomDirection.horizontal)
			{
				width = lenght;
				height = WorldGen.genRand.Next(5, 7);
			}
			else
			{
				width = WorldGen.genRand.Next(5, 7);
				height = lenght;
			}
			roomBound = new Rectangle(xy.X, xy.Y, width, height);
		}

		internal void Open()
		{
			cleared = true;
			Point point = new Point(roomBound.X, roomBound.Y);

			for (int i = point.X; i < point.X + roomBound.Width; i++)
			{
				for (int j = point.Y; j < point.Y + roomBound.Height; j++)
				{
					Main.tile[i, j].active(false);
					Main.tile[i, j].wall = WallID.BlueDungeonTile;
				}
			}

			switch (direction)
			{
				case HallRoomDirection.horizontal:
					for (int i = point.X; i < point.X + roomBound.Width; i++)
					{
						if (i % 4 == 0)
						{
							Main.tile[i, point.Y + 2].type = TileID.Torches; //Replace with custom torch or dungeon torch
						}
					}

					break;
				case HallRoomDirection.vertical:
					for (int i = point.Y; i < point.Y + roomBound.Height; i++)
					{
						if (i % 4 == 0)
						{
							Main.tile[point.X + roomBound.Width / 2 , i].type = TileID.Torches; //Replace with custom torch or dungeon torch
						}
					}
					break;
			}
		}


        internal override Rectangle Generate()
        {
            cleared = true;
			Point point = new Point(roomBound.X, roomBound.Y);
			for (int i = point.X; i < point.X + roomBound.Width; i++)
			{
				for (int j = point.Y; j < point.Y + roomBound.Height; j++)
				{
					Main.tile[i, j].active(false);
					Main.tile[i, j].wall = WallID.BlueDungeonTile;
				}
			}

			return roomBound;
		}

        internal override void Activate()
        {
            
        }
    }
}
