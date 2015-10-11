namespace GraphicsEngine.Graphics.Console
{
	public interface IConsoleScreen
	{
		int Width { get; }
		int Height { get; }

		void ShowCursor(bool showCursor);

		void SetCursor(int x, int y);

		void SetFrame(IConsoleGraphicsFrame consoleGraphicsBuffer);

		void SetPixel(int x, int y, short color, byte chr);

		void SetPixel(int x, int y, short color);

		short GetPixelColor(int x, int y);

		byte GetPixelChar(int x, int y);

		void Draw();

		void ClearFrame(short color);
	}
}