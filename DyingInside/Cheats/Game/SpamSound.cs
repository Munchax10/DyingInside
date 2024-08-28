using Il2Cpp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DyingInside.Cheats.Game
{
	internal class SpamSound : Cheat
	{
		public SpamSound(KeyCode key, string name, bool toggled, Category category) : base(key, name, toggled, category)
		{

		}

		bool tick = false;

		public override void OnUpdate()
		{
			// lava 7
			// 959
			tick = !tick;
			if (tick)
			{
				OutgoingMessages.SendPlayPlayerAudioMessage(14, 959);
			}
			
		}
	}
}
