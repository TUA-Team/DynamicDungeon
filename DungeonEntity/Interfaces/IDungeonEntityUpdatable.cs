using Microsoft.Xna.Framework.Graphics;

namespace DynamicDungeon.DungeonEntity.Interfaces
{
    public interface IDungeonEntityUpdatable : IDungeonEntity
    {
        void UpdateEntity();
        void DrawEntity(SpriteBatch sb);
        
        void ResolveCollisionWithOtherEntity(IDungeonEntityUpdatable other);
    }
}