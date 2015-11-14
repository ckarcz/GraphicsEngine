namespace GraphicsEngine.Engine
{
	public class ConsoleEngineExecutionContext
		: IConsoleEngineExecutionContext
	{
		public ConsoleEngineExecutionContext(int startTick)
		{
			StartTick = CurrentTick = startTick;
		}

		public int StartTick { get; }
		public int CurrentTick { get; set; }

		public int DeltaTick
		{
			get { return StartTick - CurrentTick; }
		}
	}
}