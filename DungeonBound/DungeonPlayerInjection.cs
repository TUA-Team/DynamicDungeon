using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicDungeon.DungeonWorld;
using InfinityCore.Players;
using Microsoft.Xna.Framework;
using Terraria;

namespace DynamicDungeon.DungeonBound
{
    class DungeonPlayerInjection
    {

        internal static void Load()
        {
            On.Terraria.Player.BordersMovement += ModifyRoomMovement;
            On.Terraria.Main.ClampScreenPositionToWorld += ModifyRoomCamera;
        }

        internal static void Unload()
        {

        }

        private static void ModifyRoomMovement(On.Terraria.Player.orig_BordersMovement orig, Terraria.Player self)
        {
            if (!DungeonSubworld.inDungeon)
            {
                orig(self);
                return;
            }
            try
            {
                var chunk = self.GetCurrentChunk().GetModChunk<DungeonChunk.DungeonChunk>();
                Rectangle roomBound = new Rectangle((int) (chunk.Chunk.Position.X * 16), (int) (chunk.Chunk.Position.Y * 16), chunk.width * 16, chunk.height * 16);
                if (self.position.X < roomBound.X + self.width)
                {
                    self.position.X = roomBound.X + self.width;
                    self.velocity.X = 0f;
                }
                if (self.position.X > roomBound.X + roomBound.Width - 16f)
                {
                    self.position.X = roomBound.X + roomBound.Width - 16f;
                    self.velocity.X = 0f;
                }
                if (self.position.Y < roomBound.Y + 16f)
                {
                    self.position.Y = roomBound.Y + 16f;
                    if ((double)self.velocity.Y < 0.11)
                    {
                        self.velocity.Y = 0.11f;
                    }
                    self.gravDir = 1f;
                }
                if (self.position.Y > roomBound.Y + roomBound.Height - 16f)
                {
                    self.position.Y = roomBound.Y + roomBound.Height - 16f;
                    self.velocity.Y = 0f;
                }
            }
            catch (Exception e)
            {
            }
        }

        private static void ModifyRoomCamera(On.Terraria.Main.orig_ClampScreenPositionToWorld orig)
        {
            if (!DungeonSubworld.inDungeon)
            {
                orig();
                return;
            }

            var chunk = Main.LocalPlayer.GetCurrentChunk().GetModChunk<DungeonChunk.DungeonChunk>();
            Rectangle roomBound = new Rectangle((int) (chunk.Chunk.Position.X * 16), (int) (chunk.Chunk.Position.Y * 16), chunk.width * 16, chunk.height * 16);

            Vector2 vector = new Vector2(roomBound.X, roomBound.Y) - Main.GameViewMatrix.Translation;
            Vector2 vector2 = new Vector2(roomBound.X + roomBound.Width - (float)Main.screenWidth / Main.GameViewMatrix.Zoom.X, roomBound.Y + roomBound.Height - (float)Main.screenHeight / Main.GameViewMatrix.Zoom.Y) - Main.GameViewMatrix.Translation;
            vector = Utils.Round(vector);
            vector2 = Utils.Round(vector2);
            Main.screenPosition = Vector2.Clamp(Main.screenPosition, vector, vector2);
        }
    }
}
