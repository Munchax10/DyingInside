using DyingInside.Utils;
using Il2Cpp;
using UnityEngine;

namespace DyingInside.Cheats.Player
{
	public class GodMode : Cheat
	{
		public GodMode(KeyCode key, string name, bool toggled) : base(key, name, toggled)
		{
			// ConfigDataPatch.cs
		}

		public override void OnUpdate()
		{

			// Set to 0
			ControllerHelper.worldController.player.instakillLayerInt = 9;
		}
	}
}
