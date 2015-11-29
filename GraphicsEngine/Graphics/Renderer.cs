using GraphicsEngine.Win32;

namespace GraphicsEngine.Graphics
{
	public class Renderer
		: IRenderer
	{
		private readonly IConsoleWindow _consoleWindow;

		public Renderer(IConsoleWindow consoleWindow)
		{
			this._consoleWindow = consoleWindow;
		}

		public int Width
		{
			get { return _consoleWindow.Width; }
		}

		public int Height
		{
			get { return _consoleWindow.Height; }
		}

		public int Renderings { get; private set; }

		public void Render(IGraphicsBuffer frame)
		{
			ClearConsoleWindow();
			SetConsoleWindowFrame(frame);
			UpdateConsoleWindow();

			Renderings++;
		}

		private void SetConsoleWindowFrame(IGraphicsBuffer frame)
		{
			if (frame != null)
			{
				for (int x = 0; x < frame.Width; x++)
				{
					for (int y = 0; y < frame.Height; y++)
					{
						_consoleWindow.Set(x, y, frame.CharacterBuffer[x, y], frame.ColorBuffer[x, y]);
					}
				}
			}
		}

		private void UpdateConsoleWindow()
		{
			_consoleWindow.Update();
		}
		private void ClearConsoleWindow()
		{
			_consoleWindow.Clear();
		}
	}
}