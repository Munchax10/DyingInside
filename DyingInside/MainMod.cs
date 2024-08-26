using DyingInside.Cheats;
using MelonLoader;
using UnityEngine;

namespace DyingInside
{
	public class MainMod : MelonMod
	{
		public override void OnLateInitializeMelon()
		{
			MelonEvents.OnGUI.Subscribe(draw, 100);
			// Set defaults or load from json
			Utils.Logger.SetLogger(LoggerInstance);
			Utils.Logger.Msg("DyingInside loaded!");
		}

		public override void OnSceneWasInitialized(int buildIndex, string sceneName)
		{
			if (sceneName == "World")
			{
				// ESP
			}
		}

		private void draw()
		{
			GUI.Box(new Rect(10f, Screen.height - 250, 178f, 240f), "Test: OFF");
		}

		public override void OnUpdate()
		{
			// Main event
			foreach (var cheat in CheatManager.cheats)
			{
				if (Input.GetKeyDown(cheat.key))
				{
					if (cheat.toggled)
					{
						cheat.toggled = false;
						cheat.OnDisable();
					} else
					{
						cheat.toggled = true;
						cheat.OnEnable();
					}
				}
			}

			CheatManager.OnFrame();
		}

		public override void OnFixedUpdate()
		{
			CheatManager.OnUpdate();
		}

	}
}
