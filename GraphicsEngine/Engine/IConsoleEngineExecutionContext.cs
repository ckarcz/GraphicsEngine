#region Imports

using System;

#endregion

namespace GraphicsEngine.Engine
{
	public interface IConsoleEngineExecutionContext
	{
		int StartTick { get; }
		int CurrentTick { get; }
		int DeltaTick { get; }
	}
}