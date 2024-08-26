using Il2Cpp;
using HarmonyLib;

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
	}
}
