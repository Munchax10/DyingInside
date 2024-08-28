using DyingInside.Cheats;
using Il2Cpp;
using HarmonyLib;

namespace DyingInside.Patches
{
	internal class AIEnemyMonoBehaviourBasePatch
	{
		[HarmonyPatch(typeof(AIEnemyMonoBehaviourBase), "TouchDamageHelper")]
		private static class AIEnemyMonoBehaviourBase_TouchDamageHelper
		{
			private static bool Prefix()
			{
				return !CheatManager.GetToggled("GodMode");
			}
		}
	}
	
}
