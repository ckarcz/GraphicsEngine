#region Imports

using System;
using System.Text;
using System.Threading.Tasks;
using GraphicsEngine.Win32;

#endregion

namespace GraphicsEngine.Graphics
{
	public class Kernel32ConsoleWindow
		: IConsoleWindow
	{
		private Kernel32Console.SMALL_RECT consoleScreenSizeRect;
		private readonly Kernel32Console.CHAR_INFO[] consoleScreenBuffer;
		private readonly Kernel32Console.CONSOLE_SCREEN_BUFFER_INFO_EX consoleScreenBufferInfoEx;
		private readonly Kernel32Console.COORD consoleScreenBufferSizeCoords;
		private readonly Kernel32Console.COORD consoleScreenBufferStartCoords;
		private readonly IntPtr stdOutputHandle;

		public Kernel32ConsoleWindow(int width, int height, string title, ushort colors = Kernel32Console.Colors.Background.BLACK | Kernel32Console.Colors.Foreground.WHITE)
		{
			Width = width;
			Height = height;
			Title = title;
			stdOutputHandle = Kernel32Console.GetStdHandle(Kernel32Console.Constants.STD_OUTPUT_HANDLE);

			consoleScreenBufferSizeCoords = new Kernel32Console.COORD(Width, Height);
			consoleScreenBufferStartCoords = new Kernel32Console.COORD(0, 0);
			consoleScreenSizeRect = new Kernel32Console.SMALL_RECT(0, 0, Width, Height);

			consoleScreenBufferInfoEx = Kernel32Console.CONSOLE_SCREEN_BUFFER_INFO_EX.Create();
			Kernel32Console.GetConsoleScreenBufferInfoEx(stdOutputHandle, ref consoleScreenBufferInfoEx);

			consoleScreenBufferInfoEx.dwSize = consoleScreenBufferSizeCoords;
			consoleScreenBufferInfoEx.dwCursorPosition = new Kernel32Console.COORD(0, 0);
			consoleScreenBufferInfoEx.srWindow = consoleScreenSizeRect;
			consoleScreenBufferInfoEx.bFullscreenSupported = false;

			Kernel32Console.SetConsoleScreenBufferInfoEx(stdOutputHandle, ref consoleScreenBufferInfoEx);

			consoleScreenBuffer = new Kernel32Console.CHAR_INFO[Width * Height];
			var emptyChar = new Kernel32Console.CHAR_INFO(new Kernel32Console.CHAR_UNION(' '), colors);
			for (var i = 0; i < width * height; i++)
			{
				consoleScreenBuffer[i] = emptyChar;
			}

			Update();
		}

		public string Title
		{
			get
			{
				var stringBuilder = new StringBuilder();
				Kernel32Console.GetConsoleTitle(stringBuilder, 256);
				return stringBuilder.ToString();
			}
			set { Kernel32Console.SetConsoleTitle(value); }
		}

		public int Width { get; private set; }
		public int Height { get; private set; }

		public void ShowCursor(bool showCursor)
		{
			Kernel32Console.ShowCursor(showCursor);
		}

		public void SetCursor(int x, int y)
		{
			Kernel32Console.SetConsoleCursorPosition(stdOutputHandle, new Kernel32Console.COORD(x, y));
		}

		public void Set(int x, int y, byte character, ushort color)
		{
			consoleScreenBuffer[x + y * Width].Attributes = color;
			consoleScreenBuffer[x + y * Width].Char.AsciiChar = character;
		}

		public void SetCharacter(int x, int y, byte character)
		{
			consoleScreenBuffer[x + y * Width].Char.AsciiChar = character;
		}

		public void SetColor(int x, int y, ushort color)
		{
			consoleScreenBuffer[x + y * Width].Attributes = color;
		}

		public ushort GetColor(int x, int y)
		{
			return consoleScreenBuffer[x + y * Width].Attributes;
		}

		public byte GetCharacter(int x, int y)
		{
			return consoleScreenBuffer[x + y * Width].Char.AsciiChar;
		}

		public void Update()
		{
			Kernel32Console.WriteConsoleOutput(stdOutputHandle, consoleScreenBuffer, consoleScreenBufferSizeCoords, consoleScreenBufferStartCoords, ref consoleScreenSizeRect);
		}

		public void Clear(byte? character = null, ushort? color = null)
		{
			Parallel.For(0, consoleScreenBuffer.Length, i =>
			{
				consoleScreenBuffer[i].Attributes = color ?? (Kernel32Console.Colors.Background.BLACK | Kernel32Console.Colors.Foreground.WHITE);
				consoleScreenBuffer[i].Char.AsciiChar = character ?? (byte)' ';
			});
		}
	}
}