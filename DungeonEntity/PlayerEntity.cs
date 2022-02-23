using DynamicDungeon.DungeonCollision;
using DynamicDungeon.DungeonEntity.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace DynamicDungeon.DungeonEntity
{
    public class PlayerEntity : IDungeonEntityLiving
    {
        private static DungeonPlayer myPlayer = Main.LocalPlayer.GetModPlayer<DungeonPlayer>();

        private Player player = myPlayer.player;
        public Point MyPosition => new Point((int)myPlayer.player.position.X, (int)myPlayer.player.position.Y);

        private readonly CircularHitbox _playerHitbox;
        public Hitbox EntityHitbox => _playerHitbox;
        public int x { get; set; }
        public int y { get; set; }

        private Vector2 pendingVelocity = Vector2.Zero;

        public PlayerEntity()
        {
            _playerHitbox = new CircularHitbox((int)myPlayer.player.position.X, (int)myPlayer.player.position.Y, 5);
            DungeonWorld.DungeonWorld.RegisterNewEntity(this);
        }

        public void UpdateEntity()
        {
            
            
            if (player.controlLeft)
            {
                player.velocity.X = -5;
                player.direction = -1;
            }
            else if (player.controlRight)
            {
                player.velocity.X = 5;
                player.direction = 1;
            }
            if (player.controlUp)
            {
                player.velocity.Y = -5;
            }
            else if (player.controlDown)
            {
                player.velocity.Y = 5;
                Vector2 test = Collision.TileCollision(player.position, player.velocity, player.width, player.height, true, false, (int)player.gravDir);
                if (test.Y == 0f)
                {
                    player.velocity.Y = 0.5f;
                }
            }

            pendingVelocity = player.velocity;
            player.position += pendingVelocity;
            _playerHitbox.HitboxShapes.x = MyPosition.X;
            _playerHitbox.HitboxShapes.y = MyPosition.Y;
        }
        
        /// <summary>
        /// Not used for the moment, will be used for special stuff later on
        /// </summary>
        /// <param name="sb"></param>
        public void DrawEntity(SpriteBatch sb)
        {
            return;
        }

        public void ResolveCollisionWithOtherEntity(IDungeonEntityUpdatable other)
        {
            if (other is PlayerEntity)
            {
                return;
            }
            
            if (other is DungeonEntity)
            {
                myPlayer.player.gravity = 0;
                myPlayer.player.fallStart = 1;
                myPlayer.player.fallStart2 = 1;
            }

            player.position -= pendingVelocity;
        }

        public int Health { get; set; }
        public bool IsAlive()
        {
            return Health <= 0;
        }
    }
}