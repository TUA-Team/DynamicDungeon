using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicDungeon.DungeonEntity;
using DynamicDungeon.DungeonEntity.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace DynamicDungeon.DungeonGlobal
{
	class DungeonGlobalNPCs : GlobalNPC
	{
		public override bool InstancePerEntity => false;
		public override bool CloneNewInstances => false;


		
	}
}
