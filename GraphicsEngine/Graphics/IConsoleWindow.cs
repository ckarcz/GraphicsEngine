namespace GraphicsEngine.Graphics
{
	public interface IConsoleWindow
	{
		string WindowTitle { get; }
		int Width { get; }
		int Height { get; }

		void ShowCursor(bool showCursor);

		void SetCursor(int x, int y);

		void SetPixel(int x, int y, byte character, short color);

		void SetPixel(int x, int y, byte character);

		void SetPixel(int x, int y, short color);

		short GetPixelColor(int x, int y);

		byte GetPixelCharacter(int x, int y);

		void Draw();

		void Clear(byte? character = null, short? color = null);
	}
}