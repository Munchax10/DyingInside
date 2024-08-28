using DyingInside.Cheats;
using Il2Cpp;
using HarmonyLib;

using DyingInside.Utils;

namespace DyingInside.Patches
{
	internal class OutgoingMessagesPatch
	{
		[HarmonyPatch(typeof(OutgoingMessages), "AddOneMessageToList")]
		private static class OutGoingMessages_AddOneMessageToList
		{
			private static bool Prefix()
			{
				return !CheatManager.GetToggled("Teleport");
			}
		}

		/* AUDIO LOGGER
		[HarmonyPatch(typeof(OutgoingMessages), "SendPlayPlayerAudioMessage")]
		private static class AudioLogger
		{
			private static bool Prefix(int audioType, int audioBlockType)
			{
				Logger.Msg(audioType + " " + audioBlockType);
				return true;
			}
		}
		*/
	}
}
