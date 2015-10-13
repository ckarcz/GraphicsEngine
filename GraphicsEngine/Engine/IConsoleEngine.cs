namespace GraphicsEngine.Engine
{
	public interface IConsoleEngine
	{
		bool IsRunning { get; }
		bool VSyncEnabled { get; }
		int CurrentFPS { get; }
		int AverageFPS { get; }
		int Renderings { get; }

		void Start();

		void Stop();
	}
}