#region Imports

using System.Windows.Input;

#endregion

namespace GraphicsEngine.Engine
{
	public class InputStateService
	{
		public InputStateService()
		{
		}

		public bool IsKeyDown(Key thisKey)
		{
			return Keyboard.IsKeyDown(thisKey);
		}
	}
}