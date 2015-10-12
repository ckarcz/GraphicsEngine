namespace GraphicsEngine.Engine
{
	public interface IConsoleEngine
	{
		bool IsRunning { get; }
		bool VSyncEnabled { get; }
		int FPS { get; }
		int Renderings { get; }

		void Start();

		void Stop();
	}
}