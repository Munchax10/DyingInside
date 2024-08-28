using DyingInside.Cheats;
using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace DyingInside
{
	internal class MainMod : MelonMod
	{
		public override void OnLateInitializeMelon()
		{
			MelonEvents.OnGUI.Subscribe(CheatGUI.Render, 100);
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

		public override void OnUpdate()
		{
			// Main event
			foreach (var cheat in CheatManager.cheats)
			{
				if (Input.GetKeyDown(cheat.Key))
				{
					cheat.Toggle();
				}
			}

			CheatManager.OnFrame();
		}

		public override void OnFixedUpdate()
		{
			if (ControllerHelper.kukouriCamera != null) ControllerHelper.kukouriCamera.minZoom = 1;
			CheatManager.OnUpdate();
		}

	}
}
