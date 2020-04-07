using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace DynamicDungeon.DungeonWorld
{
	class DungeonWorld : ModWorld
	{
		public static bool InDungeon
		{
			get => inDungeon;
		}
		internal static bool inDungeon = false;
		
	}
}
