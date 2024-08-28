using DyingInside.Cheats.Game;
using DyingInside.Cheats.Movement;
using DyingInside.Cheats.Player;
using DyingInside.Cheats.Visual;
using Il2Cpp;

namespace DyingInside.Cheats
{
	internal class CheatManager
	{
		public static Cheat[] cheats = {
			// Game
			new NoAfk(UnityEngine.KeyCode.None, "NoAfk", true, Category.Game),
			new NoFilter(UnityEngine.KeyCode.None, "NoFilter", true, Category.Game),
			new SpamSound(UnityEngine.KeyCode.F7, "SpamSound", false, Category.Player),
			// Movement
			new Fly(UnityEngine.KeyCode.F1, "Fly", false, Category.Movement),
			new HighJump(UnityEngine.KeyCode.F4, "HighJump", false, Category.Movement),
			new Speed(UnityEngine.KeyCode.F5, "Speed", false, Category.Movement),
			new Movement.Teleport(UnityEngine.KeyCode.F, "Teleport", false, Category.Movement),
			// Player
			new BlockKill(UnityEngine.KeyCode.F8, "BlockKill", true, Category.Visual),
			new GodMode(UnityEngine.KeyCode.F6, "GodMode", false, Category.Player),
			new NoKnockback(UnityEngine.KeyCode.F3, "NoKnockback", false, Category.Player),
			// Visual
			new GUI(UnityEngine.KeyCode.Insert, "GUI", true, Category.Visual),
		};

		public static bool GetToggled(string name)
		{
			Cheat? cheat = GetInstance(name);
			if (cheat == null) return false;
			return cheat.Toggled;
		}

		public static void SetToggled(string name, bool toggled)
		{
			Cheat? cheat = GetInstance(name);
			if (cheat == null) return;
			cheat.Toggled = toggled;
			if (toggled)
			{
				cheat.OnEnable();
			} else
			{
				cheat.OnDisable();
			}
		}


		public static Cheat? GetInstance(string name)
		{
			foreach (var cheat in cheats)
			{

				if (cheat.Name == name) return cheat;
			}
			return null;
		}

		public static void OnFrame()
		{
			foreach (var cheat in cheats)
			{
				if (cheat.Toggled) cheat.OnFrame();
			}
		}

		public static void OnUpdate()
		{
			foreach (var cheat in cheats)
			{
				if (cheat.Toggled) cheat.OnUpdate();
			}
		}
	}
}
