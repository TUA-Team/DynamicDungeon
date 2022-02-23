using System.Collections.Generic;
using DynamicDungeon.DungeonCollision;
using DynamicDungeon.DungeonEntity;
using DynamicDungeon.DungeonItems;
using DynamicDungeon.DungeonWorld;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace DynamicDungeon
{
    public class DungeonPlayer : ModPlayer
    {
        private List<BaseDungeonItem> playerInventory = new List<BaseDungeonItem>();

        private PlayerEntity playerEntity;

        /// <summary>
        /// A player can have a maximum of 12 full heart, this however can be modified using very special items
        /// </summary>
        public int playerMaxHP = 24;
        /// <summary>
        /// Player current maxHP
        /// </summary>
        public int playerHP = 6;
        
        /// <summary>
        /// Player current HP
        /// </summary>
        public int playerCurrentHP = 6;

        /// <summary>
        /// Player current damage
        /// </summary>
        public double damage = 3.5;

        /// <summary>
        /// The delay between player shot/player sword swing
        /// </summary>
        public double attackSpeed = 3.5;
        
        /// <summary>
        /// The travel speed of a projectile
        /// </summary>
        public double shootSpeed = 1.0;

        /// <summary>
        /// Player current walking speed
        /// </summary>
        public double walkingSpeed = 1.0;

        /// <summary>
        /// Player luck, this affect the frequency of drop you will get, the amount of item proc and other various stuff
        /// </summary>
        public double luck = 0.0;

        /// <summary>
        /// This I guess could be counted as range, essentially the time that a projectile shot by the player can live on
        /// </summary>
        public double projectileLifeTime = 5.0;
        
        /// <summary>
        /// Coming back from TUA, the void corruption is gained from killing boss.
        /// See the void corruption system for more information (W.I.P)
        /// </summary>
        public double voidCorruptionLevel = 0.0;

        public void ResetPlayer()
        {
            playerMaxHP = 24;
            playerHP = 6;
            playerCurrentHP = 6;
        }

        public override void OnEnterWorld(Player player)
        {
            if (DungeonSubworld.inDungeon)
            {
                playerEntity = new PlayerEntity();
            }
        }

        public override void PreUpdateMovement()
        {
            if(DungeonSubworld.inDungeon)
                player.velocity = Vector2.Zero;
        }
    }
}