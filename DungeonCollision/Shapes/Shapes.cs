namespace DynamicDungeon.DungeonCollision.Shapes
{
    public abstract class Shapes
    {
        public int x;
        public int y;

        public abstract bool IntersectWith(Shapes other);
        public abstract Microsoft.Xna.Framework.Rectangle ToXNARectangle();
    }
}