using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI.Gamepad;

namespace DynamicDungeon.DungeonEditor
{
    public static class DungeonEditorPlayerInventoryButton
    {
        public static void Update()
        {
            bool isHoldingClick = Main.mouseLeft && Main.mouseLeftRelease;
            
            
        }

        public static void Draw(ref int num, SpriteBatch sb)
        {
            Vector2 vector = new Vector2(Main.screenWidth - 212, 142 + 256);
            Texture2D texture2D =
                ModContent.GetTexture("DynamicDungeon/DungeonAssets/DungeonEditorAssets/EditorButton");
            if (Collision.CheckAABBvAABBCollision(vector, texture2D.Size(), new Vector2(Main.mouseX, Main.mouseY), Vector2.One) && (Main.mouseItem.stack < 1 || Main.mouseItem.dye > 0))
            {
                num = 4;
            }
            if (num == 4)
            {
                sb.Draw(texture2D, vector, null, Main.OurFavoriteColor, 0f, new Vector2(2f), 0.9f, SpriteEffects.None, 0f);
            }
            sb.Draw(texture2D, vector, null, Color.White, 0f, Vector2.Zero, 0.9f, SpriteEffects.None, 0f);
            UILinkPointNavigator.SetPosition(305, vector + texture2D.Size() * 0.75f);
        }
    }

    public class DungeonEditorInterface
    {
        
    }
}