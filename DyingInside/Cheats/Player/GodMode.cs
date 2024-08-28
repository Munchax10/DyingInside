using DyingInside.Utils;
using Il2Cpp;
using UnityEngine;

namespace DyingInside.Cheats.Player
{
	internal class GodMode : Cheat
	{
		public GodMode(KeyCode key, string name, bool toggled, Category category) : base(key, name, toggled, category)
		{
			// ConfigDataPatch.cs
		}

		public override void OnUpdate()
		{

			// Set to 0
			//ControllerHelper.worldController.player.instakillLayerInt = 9;
		}
	}
}
