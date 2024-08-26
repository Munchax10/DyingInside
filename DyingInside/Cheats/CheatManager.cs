using DyingInside.Cheats.Game;
using DyingInside.Cheats.Movement;
using DyingInside.Cheats.Player;

namespace DyingInside.Cheats
{
	public class CheatManager
	{
		public static Cheat[] cheats = {
			// Game
			new NoAfk(UnityEngine.KeyCode.None, "NoAfk", true),
			new NoFilter(UnityEngine.KeyCode.None, "NoFilter", true),
			// Movement
			new Fly(UnityEngine.KeyCode.F1, "Fly", false),
			new HighJump(UnityEngine.KeyCode.F4, "HighJump", false),
			new Speed(UnityEngine.KeyCode.F5, "Speed", false),
			new Teleport(UnityEngine.KeyCode.F2, "Teleport", false),
			// Player
			new GodMode(UnityEngine.KeyCode.F6, "GodMode", false),
			new NoKnockback(UnityEngine.KeyCode.F3, "NoKnockback", false),
		};


		public static Cheat? GetInstance(string name)
		{
			foreach (var cheat in cheats)
			{
				if (cheat.name == name) return cheat;
			}
			return null;
		}

		public static void OnFrame()
		{
			foreach (var cheat in cheats)
			{
				if (cheat.toggled) cheat.OnFrame();
			}
		}

		public static void OnUpdate()
		{
			foreach (var cheat in cheats)
			{
				if (cheat.toggled) cheat.OnUpdate();
			}
		}
	}
}
