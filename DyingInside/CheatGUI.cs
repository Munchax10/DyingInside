using DyingInside.Cheats;
using DyingInside.Cheats.Player;
using Microsoft.Diagnostics.Runtime;
using SystemWebTestShim;
using UnityEngine;

namespace DyingInside
{
	internal class CheatGUI
	{
		private static int page = 0;


		private static Rect size = new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 404f, 360f);
		public static void Render()
		{
			if (!CheatManager.GetToggled("GUI")) return;
			size = GUI.Window(0, size, new Action<int>(Menu), "DyingInside");
		}

		private static void Menu(int id)
		{
			if (GUI.Button(new Rect(2f, 16.5f, 80f, 30f), "Main"))
			{
				page = 0;
			}
			if (GUI.Button(new Rect(82f, 16.5f, 80f, 30f), "Movement"))
			{
				page = 1;
			}

			// Fix the mess with variables
			switch (page)
			{
				case 0:
					float offset = 75;
					foreach (Cheat cheat in CheatManager.cheats)
					{
						// Ugly but sends onenable and ondisable
						bool toggled = CheatManager.GetToggled(cheat.Name);
						toggled = GUI.Toggle(new Rect(5f, offset, 100f, 20f), toggled, cheat.Name);
						if (toggled) cheat.Enable();
						else cheat.Disable();
						offset = offset + 20f;
					}
					
					
					break;
				case 1:
					// idk
					break;
				default:
					break;
			}
			GUI.DragWindow();
		}
	}
}
