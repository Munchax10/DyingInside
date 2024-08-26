using UnityEngine;

namespace DyingInside.Cheats
{
	public class Cheat
	{
		public KeyCode key { get; set; }
		public string name { get; set; }
		public bool toggled { get; set; }
		public Cheat(KeyCode key, string name, bool toggled)
		{
			this.key = key;
			this.name = name;
			this.toggled = toggled;
		}

		// Methods to override

		public virtual void OnEnable() { }
		public virtual void OnDisable() { }
		public virtual void OnFrame() { }
		public virtual void OnUpdate() { }
	}
}
