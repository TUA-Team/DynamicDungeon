using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicDungeon.DungeonEntity.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace DynamicDungeon.DungeonWorld
{
	class DungeonWorld : ModWorld
	{
		private static readonly List<IDungeonEntityUpdatable> _entity = new List<IDungeonEntityUpdatable>();
		private static Queue<IDungeonEntityUpdatable> _queuedToBeRemovedEntity;
		
		public static bool InDungeon
		{
			get => inDungeon;
		}
		internal static bool inDungeon = false;


        public override void PreWorldGen()
        {
	        
		}

        public override void PreUpdate()
        {
	        if (DungeonSubworld.inDungeon)
	        {
        				
		        foreach (var dungeonEntityUpdatable in _entity)
		        {
			        dungeonEntityUpdatable.UpdateEntity();
			        if (dungeonEntityUpdatable is IDungeonEntityLiving livingEntity)
			        {
				        if (!livingEntity.IsAlive())
				        {
					        _queuedToBeRemovedEntity.Enqueue(livingEntity);
				        }
			        }
		        }
        				
		        foreach (var dungeonEntityUpdatable in _entity)
		        {
			        foreach (var dungeonEntityUpdatable2 in _entity)
			        {
				        if (dungeonEntityUpdatable.EntityHitbox.HitboxShapes.IntersectWith(dungeonEntityUpdatable2.EntityHitbox.HitboxShapes))
				        {
					        dungeonEntityUpdatable.ResolveCollisionWithOtherEntity(dungeonEntityUpdatable2);
				        }
			        }
		        }
        
        
		        foreach (var dungeonEntityUpdatable in _queuedToBeRemovedEntity)
		        {
			        var queuedEntity = _queuedToBeRemovedEntity.Dequeue();
			        _entity.Remove(queuedEntity);
		        }
	        }
        }

        public override void PostDrawTiles()
        {
	        DynamicDungeon.instance.Logger.Debug("Player in dungeon : " + InDungeon);
	        if (DungeonSubworld.inDungeon)
	        {
		        DynamicDungeon.instance.Logger.Debug("Number of entity in the dungeon : " + _entity.Count);
		        Main.spriteBatch.Begin();
		        foreach (var dungeonEntityUpdatable in _entity)
		        {
			        dungeonEntityUpdatable.DrawEntity(Main.spriteBatch);
		        }
		        Main.spriteBatch.End();
	        }
	        base.PostDrawTiles();
        }
        
        public static void RegisterNewEntity(IDungeonEntityUpdatable entity)
        {
	        _entity.Add(entity);
        }
	}
}
