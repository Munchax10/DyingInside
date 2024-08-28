//using DyingInside.Commands;
using Il2Cpp;
using HarmonyLib;
using DyingInside.Command;

namespace DyingInside.Patches
{
	internal class ChatUIPatch
	{
		
		[HarmonyPatch(typeof(ChatUI), "Submit")]
		private static class ChatUI_Submit
		{
			private static bool Prefix(string text)
			{
				if (text.StartsWith("%"))
				{
					Commands.Execute(text.Substring(1));
					return false;
				}
				return true;
			}
		}
		
	}
}
