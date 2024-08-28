using Il2Cpp;

namespace DyingInside.Command
{
	public class Commands
	{
		private static readonly World.BlockType[] pickaxes =
		{
			World.BlockType.WeaponPickaxeFlimsy,
			World.BlockType.WeaponPickaxeCrappy,
			World.BlockType.WeaponPickaxeBasic,
			World.BlockType.WeaponPickaxeDark,
			World.BlockType.WeaponPickaxeEpic,
			World.BlockType.WeaponPickaxeHeavy,
			World.BlockType.WeaponPickaxeMaster,
			World.BlockType.WeaponPickaxeSturdy,
		};
		public static void Execute(string str)
		{
			if (str == "durability")
			{
				foreach (World.BlockType type in pickaxes)
				{
					ControllerHelper.worldController.player.myPlayerData.GetDurabilityData(type).SetDurability(2147483647);
				}
			}
		}
	}
}
