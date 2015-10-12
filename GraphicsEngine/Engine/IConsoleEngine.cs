namespace GraphicsEngine.Engine
{
	public interface IConsoleEngine
	{
		bool IsRunning { get; }
		int FPS { get; }

		int Renderings { get; }

		void Start();

		void Stop();
	}
}