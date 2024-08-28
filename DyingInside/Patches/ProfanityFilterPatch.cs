using Il2Cpp;
using HarmonyLib;
using DyingInside.Utils;
using DyingInside.Cheats;

namespace DyingInside.Patches
{
	internal class ProfanityFilterPatch
	{
		[HarmonyPatch(typeof(ProfanityFilter), "Censor")]
		private static class ProfanityFilter_Censor
		{
			private static bool Prefix(ref string __result, ref string str)
			{
				if (CheatManager.GetToggled("NoFilter"))
				{
					__result = str;
					return false;
				}
				return true;
			}
		}
	}
}
