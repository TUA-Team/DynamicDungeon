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
	internal delegate void OnBossDeath();

	class BossRoom : BaseRoom
	{


		public BossRoom(NPC boss, Chunk location) : base(location)
		{

		}

		internal override Rectangle Generate()
		{
			throw new NotImplementedException();
		}
	}
}
