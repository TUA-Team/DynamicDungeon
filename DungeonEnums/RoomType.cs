using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDungeon.DungeonEnums
{
	enum RoomType
	{
		/// <summary>
		/// Room where the player spawn in
		/// </summary>
		StartingRoom,
		/// <summary>
		/// Room where the dungeon crystal spawn, allow you to leave the dungeon or continue.
		/// </summary>
		TeleportationRoom,
		/// <summary>
		/// Room that is guaranteed to appear past floor 2
		/// </summary>
		RewardRoom,
		/// <summary>
		/// Harder room where you have to clear wave of mob to complete it
		/// </summary>
		InvasionRoom,
		/// <summary>
		/// Transition room between room
		/// </summary>
		HallRoom,
		/// <summary>
		///  Transition room between room ,but with actual challenge in it
		/// </summary>
		corridor,
		/// <summary>
		/// Room that is trap with flamethrower, spike, poison trap, grenade launcher trap and more new trap
		/// </summary>
		trapRoom,
		/// <summary>
		/// Room normally located before the teleportation room, a tough boss await...
		/// </summary>
		BossRoom,
		/// <summary>
		/// Room that can be unlocked under certain condition
		/// </summary>
		SecretRoom,
		/// <summary>
		/// Basic room, I guess
		/// </summary>
		BasicRoom,
		/// <summary>
		/// Dev room, only for testing
		/// </summary>
		TestRoom
	}
}
