namespace GraphicsEngine.Graphics
{
	public interface IConsoleWindow
	{
		string Title { get; }
		int Width { get; }
		int Height { get; }

		void ShowCursor(bool showCursor);

		void SetCursor(int x, int y);

		void Set(int x, int y, byte character, ushort color);

		void SetCharacter(int x, int y, byte character);

		void SetColor(int x, int y, ushort color);

		ushort GetColor(int x, int y);

		byte GetCharacter(int x, int y);

		void Update();

		void Clear(byte? character = null, ushort? color = null);
	}
}