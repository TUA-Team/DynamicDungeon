using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicDungeon.DungeonBase;
using Terraria;
using Terraria.ModLoader;

namespace DynamicDungeon.DungeonNPCs
{

	public delegate void OnDeath();

	public delegate void OnLoot();

	public delegate void OnSpawn();

	/// <summary>
	/// Mainly used for boss
	/// </summary>
	public class ConditionalDungeonsNPCs
	{
		public NPC targetNPC;

		public event OnDeath onDeath;
		public event OnLoot onLoot;
		public event OnSpawn onSpawn;
	}
}
