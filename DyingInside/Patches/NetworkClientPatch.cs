using DyingInside.Cheats;
using HarmonyLib;
using Il2Cpp;
using Mono.CSharp;

namespace DyingInside.Patches
{
	internal class NetworkClientPatch
	{
		[HarmonyPatch(typeof(NetworkClient), "Update")]
		private static class NetworkClient_Update
		{
			private static bool Prefix()
			{
				return !CheatManager.GetToggled("Teleport");
			}
		}
	}
}
