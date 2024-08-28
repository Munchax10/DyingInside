using DyingInside.Cheats;
using DyingInside.Utils;
using HarmonyLib;
using Il2Cpp;
using Il2CppBasicTypes;


namespace DyingInside.Patches
{
	internal class PlayerPatch
	{

		[HarmonyPatch(typeof(Player), "HitPlayerFromBlock", new Type[]
		{
			typeof(int),
			typeof(World.BlockType),
			typeof(Vector2i),
		})]
		private static class Player_HitPlayerFromBlock
		{
			private static bool Prefix(ref bool __result)
			{
				if (!CheatManager.GetToggled("GodMode")) return true;
				__result = true;
				return false;
			}
		}

		[HarmonyPatch(typeof(Player), "HitPlayerFromBlock", new Type[]
		{
			typeof(World.BlockType),
			typeof(Vector2i),
			typeof(bool),
		})]
		private static class Player_HitPlayerFromBlock2
		{
			private static bool Prefix(ref bool __result)
			{
				if (!CheatManager.GetToggled("GodMode")) return true;
				__result = true;
				return false;
			}
		}

		
		[HarmonyPatch(typeof(Player), "CanGiveAIEnemyDamage")]
		private static class Player_CanGiveAIEnemyDamage
		{
			private static bool Prefix()
			{
				return !CheatManager.GetToggled("GodMode");
			}
		}

		[HarmonyPatch(typeof(Player), "DeathByColliderInCollider", new Type[]
		{
			typeof(Vector2i)
		})]
		private static class Player_DeathByColliderInCollider
		{
			private static bool Prefix()
			{
				return !CheatManager.GetToggled("BlockKill");
			}
		}

		[HarmonyPatch(typeof(Player), "IsPlayerInMapPoint")]
		private static class Player_IsPlayerInMapPoint
		{
			private static bool Prefix(ref bool __result)
			{
				if (CheatManager.GetToggled("BlockKill"))
				{
					__result = false;
					return false;
				}
				return true;
			}
		}
	}
}
