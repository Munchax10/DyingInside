using DyingInside.Cheats;
using HarmonyLib;
using Il2CppPrime31;
using System.Numerics;

namespace DyingInside.Patches
{
	internal class CharacterController2DPatch
	{
		[HarmonyPatch(typeof(CharacterController2D), "move")]
		private static class CharacterController2D_move
		{
			private static bool Prefix()
			{
				return !CheatManager.GetToggled("Teleport");
			}
		}
	}
}
