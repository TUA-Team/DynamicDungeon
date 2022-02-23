using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDungeon.DungeonEnums
{
	enum RoomType : int
	{
		noRoom = -1,
		/// <summary>
		/// Room where the player spawn in
		/// </summary>
		StartingRoom = 0,
		/// <summary>
		/// Room where the dungeon crystal spawn, allow you to leave the dungeon or continue.
		/// </summary>
		TeleportationRoom = 1,
		/// <summary>
		/// Room that is guaranteed to appear past floor 2
		/// </summary>
		RewardRoom = 2,
		/// <summary>
		/// Harder room where you have to clear wave of mob to complete it
		/// </summary>
		InvasionRoom = 3,
		/// <summary>
		/// Transition room between room
		/// </summary>
		HallRoom = 4,
		/// <summary>
		///  Transition room between room ,but with actual challenge in it
		/// </summary>
		corridor = 5,
		/// <summary>
		/// Room that is trap with flamethrower, spike, poison trap, grenade launcher trap and more new trap
		/// </summary>
		trapRoom = 6,
		/// <summary>
		/// Room normally located before the teleportation room, a tough boss await...
		/// </summary>
		BossRoom = 7,
		/// <summary>
		/// Room that can be unlocked under certain condition
		/// </summary>
		SecretRoom = 8,
		/// <summary>
		/// Basic room, I guess
		/// </summary>
		BasicRoom = 9,
		/// <summary>
		/// Dev room, only for testing
		/// </summary>
		TestRoom = 10
	}
}
