using DynamicDungeon.DungeonWorld;
using InfinityCore.API.ModCompatibility;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace DynamicDungeon
{
	public class DynamicDungeon : Mod
	{
		internal static DynamicDungeon instance;
        internal static Mod infinityCore;

        public static bool EnableInfinityCoreStaticLoader = true;



		public DynamicDungeon()
		{
		}

		public override void Load()
		{
			instance = this;
            infinityCore = ModLoader.GetMod("InfinityCore");
            SubworldLibraryInjection.PreSubworldAddGenerationPass += DungeonSubworld.PreAddPass;
        }

		public override void Unload()
		{
			instance = null;
            infinityCore = null;
        }

		
	}
}