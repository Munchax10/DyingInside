using DyingInside.Utils;
using Il2Cpp;
using Il2CppBasicTypes;
using UnityEngine;

namespace DyingInside.Cheats.Movement
{
	internal class Teleport : Cheat
	{
		public Teleport(KeyCode key, string name, bool toggled, Category category) : base(key, name, toggled, category)
		{

		}

		List<Vector2i>? path;
		int count = 0;
		int tickstowait = 0;

		public override void OnEnable()
		{
			count = 0;
			tickstowait = 0;
			Vector2i goal = TeleportUtils.ConvertWorldPointToMapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
			path = TeleportUtils.FindPath(ControllerHelper.worldController.player.currentPlayerMapPoint, goal);
			if (path == null)
			{
				Disable();
				return;
			}
		}

		
		public override void OnUpdate()
		{
			if (tickstowait > 0)
			{
				tickstowait--;
				return;
			}
			if (path == null || count + 1 >= path.Count)
			{
				return;
			}

			Utils.Logger.Msg(count + " " + path.Count);

			ControllerHelper.worldController.player.transform.position = TeleportUtils.ConvertMapPointToWorldPoint(path[count]) - new Vector2(0, 0.125f);
			count++;
			tickstowait = 2;
		}
	}
}
