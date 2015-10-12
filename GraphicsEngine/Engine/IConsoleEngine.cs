namespace GraphicsEngine.Engine
{
	public interface IConsoleEngine
	{
		bool IsRunning { get; }
		int FPS { get; }

		void Start();

		void Stop();
	}
}