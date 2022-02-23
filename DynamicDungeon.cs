using DynamicDungeon.DungeonEditor;
using DynamicDungeon.DungeonWorld;
using InfinityCore.API.ModCompatibility;
using InfinityCore.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
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
            SubworldLibraryInjection.PreSubworldChunkGenerationPass+= DungeonSubworld.PreAddPass;
            On.Terraria.Main.DrawPageIcons += orig =>
            {
	            int num = orig();
	            num++;
	            DungeonEditorPlayerInventoryButton.Draw(ref num, Main.spriteBatch);
	            return num;
            };

            On.Terraria.Main.DrawTiles += (orig, self, only, overrideTile) =>
            {
	            if (!DungeonSubworld.inDungeon)
	            {
		            orig(self, only, overrideTile);
		            return;
	            }
	            
	            var chunk = Main.LocalPlayer.GetCurrentChunk();
            
	            Vector2 playerChunk = chunk.Position;
            
	            Rectangle roomBound = new Rectangle((int) playerChunk.X * 16, (int) playerChunk.Y * 16, 100 * 16, 75 * 16);
	            Vector2 vector = new Vector2(roomBound.X, roomBound.Y);
	            Vector2 vector2 = new Vector2(roomBound.X + roomBound.Width, roomBound.Y + roomBound.Height);
	            vector = Utils.Round(vector);
	            vector2 = Utils.Round(vector2);
	            vector2 *= -1f;
	            Main.screenPosition = roomBound.Center() - new Vector2(Main.screenWidth / 2f, Main.screenHeight / 2f);
	            
	            Main.spriteBatch.GraphicsDevice.ScissorRectangle = new Rectangle((Main.screenWidth / 2) - (50 * 16), (Main.screenHeight / 2) - (37 * 16), 100 * 16, 76 * 16);
	            Main.spriteBatch.GraphicsDevice.RasterizerState = RasterizerState.CullNone;
	            orig(self, only, overrideTile);
            };
		}

		public override void Unload()
		{
			instance = null;
            infinityCore = null;
        }
		

		
	}
}