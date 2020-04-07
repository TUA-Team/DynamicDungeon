using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityCore.Worlds.Chunk;
using Microsoft.Xna.Framework;

namespace DynamicDungeon.DungeonBase
{
	class RewardRoom : BaseRoom
	{
		internal override Rectangle Generate()
		{
			throw new NotImplementedException();
		}

        public RewardRoom(Chunk chunk) : base(chunk)
        {
        }
    }
}
