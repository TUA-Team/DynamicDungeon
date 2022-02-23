using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DynamicDungeon.DungeonWorld;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SubworldLibrary;
using Terraria;
using Terraria.ModLoader;

namespace DynamicDungeon.DungeonNPCs
{
	class DungeonCrystal : ModNPC
	{

		private int _animationTimer = 20;
		private bool _reverseAnimation = false;

		private int _customFrameX = 0;
		private readonly int GAP_BETWEEN_FRAME = 0;

		private Texture2D _npcTexture;

		public override void SetDefaults()
		{
			npc.immortal = true;
			npc.lavaImmune = true;
			npc.lifeMax = int.MaxValue;
			npc.defense = int.MaxValue;
			npc.aiStyle = -1;
			npc.friendly = true;
			npc.noGravity = false;
			npc.width = 100;
			npc.height = 132;
			npc.immortal = true;
			npc.townNPC = true;
			_npcTexture = mod.GetTexture("DungeonNPCs/DungeonCrystal");
		}

		public override void AI()
		{
			_animationTimer--;
			if (_animationTimer == 0)
			{
				_animationTimer = 20;

				if (_customFrameX > 2 || _customFrameX < 0)
				{
					_reverseAnimation = !_reverseAnimation;
				}

				_customFrameX += (_reverseAnimation) ? 1 : -1;

			}
			base.AI();
		}

		public override string GetChat()
		{
			string[] portalQuote =
			{
				"Are you ready for the great dungeon experience? The dungeon awaits you with its ever increasing difficulty and rewards.",
				"The dynamic dungeon is a hard place, are you ready?"
			};
			if (!NPC.downedBoss3)
			{
				return "The crystal seems to not be reacting...";
			}

			if (DungeonSubworld.inDungeon)
			{
				return "Are you ready to go on the next floor? Or you want to leave?";
			}

			return portalQuote[Main.rand.Next(portalQuote.Length)];
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			if (!NPC.downedBoss3)
			{
				button = "Come back later";
				return;
			}

			if (DungeonWorld.DungeonSubworld.inDungeon)
			{
				button = "Progress to the next floor";
				button2 = "Exit the dungeon";
			}

			button = "Enter the dungeon";

			base.SetChatButtons(ref button, ref button2);
		}

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
			
            if (firstButton && NPC.downedBoss3 && !DungeonWorld.DungeonSubworld.inDungeon)
            {
                Subworld.Enter<DungeonSubworld>();
            }

            var obj = typeof(Subworld).GetField("subworlds", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);

            if (firstButton && DungeonWorld.DungeonSubworld.inDungeon)
            {
				Subworld.Exit();
            }

            base.OnChatButtonClicked(firstButton, ref shop);
        }

        public override bool CheckActive()
        {
            return false;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			return false;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			Vector2 position = npc.position - Main.screenPosition;
			Rectangle frame = new Rectangle(102 * _customFrameX, 0, 100, 132);
			spriteBatch.Draw(_npcTexture, position, frame, Color.White);
			return false;
		}
	}
}
