using MelonLoader;

namespace DyingInside.Utils
{
	public class Logger
	{
		static MelonLogger.Instance? Instance;

		public static void Msg(Object obj)
		{
			Instance?.Msg(obj);
		}

		public static void SetLogger(MelonLogger.Instance instance)
		{
			Instance = instance;
		}
	}
}
