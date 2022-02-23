using DynamicDungeon.DungeonCollision;

namespace DynamicDungeon.DungeonEntity.Interfaces
{
    public interface IDungeonEntity
    {
        Hitbox EntityHitbox { get; }

        int x { get; set; }
        int y { get; set; }
    }
}