using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityCore.Worlds.Chunk;
using Microsoft.Xna.Framework;

namespace DynamicDungeon.DungeonBase
{
    public abstract class BaseRoom
    {
        internal bool doorTop, doorBottom, doorLeft, doorRight;
		internal bool cleared;
		internal Rectangle roomBound;

		internal int width;
		internal int height;

        internal Chunk chunk;

		internal abstract Rectangle Generate();
        internal abstract void Activate();


        public BaseRoom(Chunk chunk)
        {
            this.chunk = chunk;
        }
	}
}
