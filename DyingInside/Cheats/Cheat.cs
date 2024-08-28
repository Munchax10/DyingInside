using UnityEngine;

namespace DyingInside.Cheats
{
	internal class Cheat
	{
		public KeyCode Key;
		public string Name;
		public bool Toggled;
		public Category Category;

		public Cheat(KeyCode key, string name, bool toggled, Category category)
		{
			Key = key;
			Name = name;
			Toggled = toggled;
			Category = category;
		}

		public void Enable()
		{
			Toggled = true;
			OnEnable();
		}

		public void Disable()
		{
			Toggled = false;
			OnDisable();
		}

		public void Toggle()
		{
			if (Toggled) Disable();
			else Enable();
		}

		// Methods to override

		public virtual void OnEnable() { }
		public virtual void OnDisable() { }
		public virtual void OnFrame() { }
		public virtual void OnUpdate() { }
	}
}
