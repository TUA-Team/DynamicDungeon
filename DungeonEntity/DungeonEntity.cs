using DynamicDungeon.DungeonCollision;
using DynamicDungeon.DungeonEntity.Interfaces;
using DynamicDungeon.DungeonGlobal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace DynamicDungeon.DungeonEntity
{
    // The basic dungeon entity, we are not using NPC system
    public class DungeonEntity : IDungeonEntityUpdatable
    {

        public Hitbox EntityHitbox => new CircularHitbox(x, y, 80);

        public Texture2D entity = ModContent.GetTexture("DynamicDungeon/DungeonAssets/DungeonEntityTest/DungeonCollisionCircle");

        public DungeonEntity()
        {
            DynamicDungeon.instance.Logger.Debug("Successfully created a new dungeon entity");
            EntityHitbox.PhysicalCollision = true;
            DungeonWorld.DungeonWorld.RegisterNewEntity(this);
        }
        
        public int x { get; set; }
        public int y { get; set; }
        public void UpdateEntity()
        {
            DynamicDungeon.instance.Logger.Debug("Dungeon entity : " + new Vector2(x, y));
        }

        public void DrawEntity(SpriteBatch sb)
        {
            DynamicDungeon.instance.Logger.Debug("Dungeon entity : " + (Main.screenPosition - new Vector2(x, y)));
            sb.Draw(entity, (Main.screenPosition - new Vector2(x - 40, y - 40)) * -1f, Color.Red);
        }

        public void ResolveCollisionWithOtherEntity(IDungeonEntityUpdatable other)
        {
            
        }
    }
}