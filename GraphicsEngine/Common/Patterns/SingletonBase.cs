namespace GraphicsEngine.Common.Patterns
{
	public abstract class SingletonBase<T>
		where T : SingletonBase<T>, new()
	{
		private static T instance;

		public static T Instance
		{
			get { return instance ?? (instance = new T()); }
		}
	}
}