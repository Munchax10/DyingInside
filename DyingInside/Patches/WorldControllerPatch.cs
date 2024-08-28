using Il2Cpp;
using HarmonyLib;
using DyingInside.Cheats;

namespace DyingInside.Patches
{
	internal class WorldControllerPatch
	{
		[HarmonyPatch(typeof(WorldController), "InstantiateFogOfWar")]
		private static class WorldController_InstantiateFogOfWar
		{
			public static bool Prefix()
			{
				return false;
			}
		}

		[HarmonyPatch(typeof(WorldController), "KickPlayerByInactivity")]
		private static class WorldController_KickPlayerByInactivity
		{
			public static bool Prefix()
			{
				return !CheatManager.GetToggled("NoAfk");
			}
		}
	}
}
