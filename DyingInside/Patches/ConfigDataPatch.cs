using Boo.Lang.Compiler.Steps;
using DyingInside.Cheats;
using DyingInside.Cheats.Movement;
using DyingInside.Utils;
using HarmonyLib;
using Il2Cpp;


namespace DyingInside.Patches
{
	internal class ConfigDataPatch
	{
		[HarmonyPatch(typeof(ConfigData), "GetBlockGravity")]
		private static class ConfigData_GetBlockGravity
		{
			private static bool Prefix()
			{
				Cheat? fly = CheatManager.GetInstance("Fly");
				if (fly != null) return !fly.toggled;
				return true;
			}
		}

		[HarmonyPatch(typeof(ConfigData), "GetBlockRunSpeed")]
		private static class ConfigData_GetBlockRunSpeed
		{
			private static bool Prefix(ref float __result, World.BlockType blockType)
			{
				Cheat? speed = CheatManager.GetInstance("Speed");
				if (Globals.glue.Contains((int) blockType) || speed == null || !speed.toggled) return true;

				__result = 3;

				return false;
			}
		}

		[HarmonyPatch(typeof(ConfigData), "GetBlockJumpHeight")]
		private static class ConfigData_GetBlockJumpHeight
		{
			private static bool Prefix(ref float __result)
			{
				Cheat? highjump = CheatManager.GetInstance("HighJump");
				if (highjump == null || !highjump.toggled) return true;

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
				Cheat? noKnockback = CheatManager.GetInstance("NoKnockback");
				bool toggled = false;
				if (noKnockback != null) toggled = noKnockback.toggled;

				foreach (int i in Globals.ice)
				{
					if (toggled) ConfigData.SetBlockGroundDamping("10", i);
					else ConfigData.SetBlockGroundDamping("1", i);
				}

				foreach (int i in Globals.glue)
				{
					if (toggled) ConfigData.SetBlockRunSpeed("1.8", i);
					else ConfigData.SetBlockRunSpeed("0.3", i);
				}
				
				return !toggled;
			}
		}

		[HarmonyPatch(typeof(ConfigData), "IsBlockSpring")]
		private static class ConfigData_IsBlockSpring
		{
			private static bool Prefix()
			{
				Cheat? noKnockback = CheatManager.GetInstance("NoKnockback");
				if (noKnockback != null) return !noKnockback.toggled;
				return true;
			}
		}

		[HarmonyPatch(typeof(ConfigData), "IsBlockPinball")]
		private static class ConfigData_IsBlockPinball
		{
			private static bool Prefix()
			{
				Cheat? noKnockback = CheatManager.GetInstance("NoKnockback");
				if (noKnockback != null) return !noKnockback.toggled;
				return true;
			}
		}

		[HarmonyPatch(typeof(ConfigData), "IsBlockElastic")]
		private static class ConfigData_IsBlockElastic
		{
			private static bool Prefix()
			{
				Cheat? noKnockback = CheatManager.GetInstance("NoKnockback");
				if (noKnockback != null) return !noKnockback.toggled;
				return true;
			}
		}

		[HarmonyPatch(typeof(ConfigData), "IsBlockElevator")]
		private static class ConfigData_IsBlockElevator
		{
			private static bool Prefix()
			{
				Cheat? noKnockback = CheatManager.GetInstance("NoKnockback");
				if (noKnockback != null) return !noKnockback.toggled;
				return true;
			}
		}

		[HarmonyPatch(typeof(ConfigData), "IsBlockTrampolin")]
		private static class ConfigData_IsBlockTrampolin
		{
			private static bool Prefix()
			{
				Cheat? noKnockback = CheatManager.GetInstance("NoKnockback");
				if (noKnockback != null) return !noKnockback.toggled;
				return true;
			}
		}

		[HarmonyPatch(typeof(ConfigData), "IsBlockSwimming")]
		private static class ConfigData_IsBlockSwimming
		{
			private static bool Prefix()
			{
				Cheat? noKnockback = CheatManager.GetInstance("NoKnockback");
				if (noKnockback != null) return !noKnockback.toggled;
				return true;
			}
		}

		[HarmonyPatch(typeof(ConfigData), "GetDeflectorMaxForceRange")]
		private static class ConfigData_GetDeflectorMaxForceRange
		{
			private static bool Prefix()
			{
				Cheat? noKnockback = CheatManager.GetInstance("NoKnockback");
				if (noKnockback != null) return !noKnockback.toggled;
				return true;
			}
		}

		[HarmonyPatch(typeof(ConfigData), "GetDeflectorRange")]
		private static class ConfigData_GetDeflectorRange
		{
			private static bool Prefix()
			{
				Cheat? noKnockback = CheatManager.GetInstance("NoKnockback");
				if (noKnockback != null) return !noKnockback.toggled;
				return true;
			}
		}
	}
}
