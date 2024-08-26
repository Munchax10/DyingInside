
using Il2Cpp;
using UnityEngine;

namespace DyingInside.Cheats.Movement
{
	public class Fly : Cheat
	{
		public Fly(KeyCode key, string name, bool toggled) : base(key, name, toggled)
		{

		}

		public override void OnUpdate()
		{
			Vector3 velocity = new(0, 0);

			if (Input.GetKey(KeyCode.W)) velocity = new Vector3(velocity.x, 3);
			if (Input.GetKey(KeyCode.A)) velocity = new Vector3(-3, velocity.y);
			if (Input.GetKey(KeyCode.S)) velocity = new Vector3(velocity.x, -3);
			if (Input.GetKey(KeyCode.D)) velocity = new Vector3(3, velocity.y);

			// TODO china bypass: velocity = new Vector3(velocity.x, velocity.y - 0.3f);

			ControllerHelper.worldController.player.SetVelocity(velocity);
		}


	}
}
