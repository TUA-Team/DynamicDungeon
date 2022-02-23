namespace DynamicDungeon.DungeonEntity.Interfaces
{
    interface IDungeonEntityLiving : IDungeonEntityUpdatable
    {
        int Health { get; set; }

        bool IsAlive();
    }
}