using Il2Cpp;
using UnityEngine;

namespace DyingInside.Cheats.Player
{
	internal class NoKnockback : Cheat
	{
		public NoKnockback(KeyCode key, string name, bool toggled, Category category) : base(key, name, toggled, category)
		{
			// ConfigDataPatch.cs
		}

		public override void OnUpdate()
		{
			ConfigData.playerHitOtherPlayerVelocityMax = 0f;
		}

		public override void OnDisable()
		{
			// set to 0.3f
		}
	}
}
