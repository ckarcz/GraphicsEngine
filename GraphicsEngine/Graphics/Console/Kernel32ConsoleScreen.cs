#region Imports

using System;
using System.Diagnostics;
using System.Text;
using GraphicsEngine.Win32;

#endregion

namespace GraphicsEngine.Graphics.Console
{
	public class Kernel32ConsoleScreen
		: IConsoleScreen
	{
		private Kernel32Console.SMALL_RECT consoleScreenSizeRect;
		private readonly Kernel32Console.CHAR_INFO[] consoleScreenBuffer;
		private readonly Kernel32Console.COORD consoleScreenBufferStartCoords;
		private readonly Kernel32Console.CONSOLE_SCREEN_BUFFER_INFO_EX consoleScreenBufferInfoEx;
		private readonly Kernel32Console.COORD consoleScreenBufferSizeCoords;
		private readonly IntPtr stdOutputHandle;

		public Kernel32ConsoleScreen(int width, int height, string windowTitle, short colors = Kernel32Console.Colors.BACKGROUND_BLACK | Kernel32Console.Colors.FOREGROUND_GREY | Kernel32Console.Colors.FOREGROUND_INTENSITY)
		{
			Width = width;
			Height = height;
			WindowTitle = windowTitle;
			stdOutputHandle = Kernel32Console.GetStdHandle(Kernel32Console.STD_OUTPUT_HANDLE);

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
			for (int i = 0; i < width * height; i++)
			{
				consoleScreenBuffer[i] = emptyChar;
			}

			Draw();
		}

		public string WindowTitle
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

		public void SetFrame(IConsoleGraphicsFrame consoleGraphicsBuffer)
		{
			for (int x = 0; x < consoleGraphicsBuffer.Width; x++)
			{
				for (int y = 0; y < consoleGraphicsBuffer.Height; y++)
				{
					SetPixel(x, y, consoleGraphicsBuffer.ColorBuffer[x, y], consoleGraphicsBuffer.CharacterBuffer[x, y]);
				}
			}
		}

		public void SetPixel(int x, int y, short color, byte chr)
		{
			consoleScreenBuffer[x + y * Width].Attributes = color;
			consoleScreenBuffer[x + y * Width].Char.AsciiChar = chr;
		}

		public void SetPixel(int x, int y, short color)
		{
			consoleScreenBuffer[x + y * Width].Attributes = color;
			//consoleScreenBuffer[x + y * Width].Char.AsciiChar = chr;
		}

		public short GetPixelColor(int x, int y)
		{
			return consoleScreenBuffer[x + y * Width].Attributes;
		}

		public byte GetPixelChar(int x, int y)
		{
			return consoleScreenBuffer[x + y * Width].Char.AsciiChar;
		}

		public void Draw()
		{
			Kernel32Console.WriteConsoleOutput(stdOutputHandle, consoleScreenBuffer, consoleScreenBufferSizeCoords, consoleScreenBufferStartCoords, ref consoleScreenSizeRect);
		}

		public void ClearFrame(short color)
		{
			for (int i = 0; i < Width * Height; i++)
			{
				consoleScreenBuffer[i].Attributes = color;
				consoleScreenBuffer[i].Char.AsciiChar = (byte)' '; // save as const
			}
		}
	}
}