
using Il2Cpp;
using UnityEngine;

namespace DyingInside.Cheats.Movement
{
	internal class Fly : Cheat
	{
		public Fly(KeyCode key, string name, bool toggled, Category category) : base(key, name, toggled, category)
		{

		}

		private float speed = 2.5f;

		public override void OnUpdate()
		{
			if (ControllerHelper.worldController == null) return;
			Vector3 velocity = new(0, 0);

			if (Input.GetKey(KeyCode.W)) velocity = new Vector3(velocity.x, speed);
			if (Input.GetKey(KeyCode.A)) velocity = new Vector3(-speed, velocity.y);
			if (Input.GetKey(KeyCode.S)) velocity = new Vector3(velocity.x, -speed);
			if (Input.GetKey(KeyCode.D)) velocity = new Vector3(speed, velocity.y);

			// TODO china bypass: velocity = new Vector3(velocity.x, velocity.y - 0.3f);

			ControllerHelper.worldController.player.SetVelocity(velocity);
		}


	}
}
