using Boo.Lang.Compiler.Steps;
using DyingInside.Cheats;
using DyingInside.Cheats.Movement;
using DyingInside.Utils;
using HarmonyLib;
using Il2Cpp;
using Mono.CSharp;


namespace DyingInside.Patches
{
	internal class ConfigDataPatch

		// LAGHACK, portal warp (dest and into it)
	{


		[HarmonyPatch(typeof(ConfigData), "DoesBlockHaveCollider")]
		private static class ConfigData_DoesBlockHaveCollider
		{
			private static bool Prefix(World.BlockType blockType, ref bool __result)
			{
				if (CheatManager.GetToggled("NoKnocback") && (blockType == World.BlockType.SpikeBall || blockType == World.BlockType.Spikes))
				{
					__result = true;
					return false;
				}
				return true;
			}
		}

		[HarmonyPatch(typeof(ConfigData), "GetBlockRunSpeed")]
		private static class ConfigData_GetBlockRunSpeed
		{
			private static bool Prefix(ref float __result, World.BlockType blockType)
			{
				if (Globals.glue.Contains((int) blockType) || !CheatManager.GetToggled("Speed")) return true;

				__result = 3;

				return false;
			}
		}

		[HarmonyPatch(typeof(ConfigData), "GetBlockJumpHeight")]
		private static class ConfigData_GetBlockJumpHeight
		{
			private static bool Prefix(ref float __result)
			{
				if (!CheatManager.GetToggled("HighJump")) return true;

				__result = 0.8f;

				return false;
			}
		}

		// AntiBounce

		[HarmonyPatch(typeof(ConfigData), "IsBlockHot")]
		private static class ConfigData_IsBlockHot
		{
			private static bool Prefix()
			{
				foreach (int i in Globals.ice)
				{
					if (CheatManager.GetToggled("NoKnockback")) ConfigData.SetBlockGroundDamping("10", i);
					else ConfigData.SetBlockGroundDamping("1", i);
				}

				foreach (int i in Globals.glue)
				{
					if (CheatManager.GetToggled("NoKnockback")) ConfigData.SetBlockRunSpeed("1.8", i);
					else ConfigData.SetBlockRunSpeed("0.3", i);
				}
				
				return !CheatManager.GetToggled("NoKnockback");
			}
		}

		[HarmonyPatch(typeof(ConfigData), "IsBlockSpring")]
		private static class ConfigData_IsBlockSpring
		{
			private static bool Prefix()
			{
				return !CheatManager.GetToggled("NoKnockback");
			}
		}

		[HarmonyPatch(typeof(ConfigData), "IsBlockPinball")]
		private static class ConfigData_IsBlockPinball
		{
			private static bool Prefix()
			{
				return !CheatManager.GetToggled("NoKnockback");
			}
		}

		[HarmonyPatch(typeof(ConfigData), "IsBlockElastic")]
		private static class ConfigData_IsBlockElastic
		{
			private static bool Prefix()
			{
				return !CheatManager.GetToggled("NoKnockback");
			}
		}

		[HarmonyPatch(typeof(ConfigData), "IsBlockElevator")]
		private static class ConfigData_IsBlockElevator
		{
			private static bool Prefix()
			{
				return !CheatManager.GetToggled("NoKnockback");
			}
		}

		[HarmonyPatch(typeof(ConfigData), "IsBlockTrampolin")]
		private static class ConfigData_IsBlockTrampolin
		{
			private static bool Prefix()
			{
				return !CheatManager.GetToggled("NoKnockback");
			}
		}

		[HarmonyPatch(typeof(ConfigData), "IsBlockSwimming")]
		private static class ConfigData_IsBlockSwimming
		{
			private static bool Prefix()
			{
				return !CheatManager.GetToggled("NoKnockback");
			}
		}

		[HarmonyPatch(typeof(ConfigData), "GetDeflectorMaxForceRange")]
		private static class ConfigData_GetDeflectorMaxForceRange
		{
			private static bool Prefix()
			{
				return !CheatManager.GetToggled("NoKnockback");
			}
		}

		[HarmonyPatch(typeof(ConfigData), "GetDeflectorRange")]
		private static class ConfigData_GetDeflectorRange
		{
			private static bool Prefix()
			{
				return !CheatManager.GetToggled("NoKnockback");
			}
		}
	}
}
