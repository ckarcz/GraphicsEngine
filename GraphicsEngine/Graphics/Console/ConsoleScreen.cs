#region Imports

using System;
using GraphicsEngine.Win32;

#endregion

namespace GraphicsEngine.Graphics.Console
{
	public class ConsoleScreen
	{
		[Flags]
		public enum Colors
			: int
		{
			Black = 0x0000,
			DarkBlue = 0x0001,
			DarkGreen = 0x0002,
			DarkRed = 0x0004,
			Gray = DarkBlue | DarkGreen | DarkRed,
			DarkYellow = DarkRed | DarkGreen,
			DarkPurple = DarkRed | DarkBlue,
			DarkCyan = DarkGreen | DarkBlue,
			LightBlue = DarkBlue | Kernel32Console.HIGH_INTENSITY,
			LightGreen = DarkGreen | Kernel32Console.HIGH_INTENSITY,
			LightRed = DarkRed | Kernel32Console.HIGH_INTENSITY,
			LightWhite = Gray | Kernel32Console.HIGH_INTENSITY,
			LightYellow = DarkYellow | Kernel32Console.HIGH_INTENSITY,
			LightPurple = DarkPurple | Kernel32Console.HIGH_INTENSITY,
			LightCyan = DarkCyan | Kernel32Console.HIGH_INTENSITY
		}

		private Kernel32Console.SmallRect consoleScreenCoords;
		private readonly Kernel32Console.CharInfo[] consoleScreenBuffer;
		private readonly Kernel32Console.Coord consoleScreenBufferCoords;
		private readonly Kernel32Console.CONSOLE_SCREEN_BUFFER_INFO_EX consoleScreenBufferInfoEx;
		private readonly Kernel32Console.Coord consoleScreenBufferSize;
		private readonly IntPtr stdOutputHandle;

		public ConsoleScreen(int width, int height, IntPtr stdOutputHandle)
		{
			Width = width;
			Height = height;

			this.stdOutputHandle = stdOutputHandle;

			consoleScreenBufferSize = new Kernel32Console.Coord(Width, Height);
			consoleScreenBufferCoords = new Kernel32Console.Coord(0, 0);
			consoleScreenCoords = new Kernel32Console.SmallRect(0, 0, Width, Height);

			consoleScreenBufferInfoEx = Kernel32Console.CONSOLE_SCREEN_BUFFER_INFO_EX.Create();
			Kernel32Console.GetConsoleScreenBufferInfoEx(stdOutputHandle, ref consoleScreenBufferInfoEx);

			consoleScreenBufferInfoEx.dwSize = new Kernel32Console.Coord(Width / 4, Height / 2 / 4);
			consoleScreenBufferInfoEx.dwCursorPosition = new Kernel32Console.Coord(0, 0);

			consoleScreenBuffer = new Kernel32Console.CharInfo[Width * (Height * 2)];
			Kernel32Console.CharInfo chri = new Kernel32Console.CharInfo(new Kernel32Console.CharUnion(' '), 0);

			for (int i = 0; i < width * height; i++)
			{
				consoleScreenBuffer[i] = chri;
			}
		}

		public int Width { get; }
		public int Height { get; }

		public void ShowCursor(bool showCursor)
		{
			Kernel32Console.ShowCursor(showCursor);
		}

		public void SetCursor(int x, int y)
		{
			Kernel32Console.SetConsoleCursorPosition(stdOutputHandle, new Kernel32Console.Coord(x, y));
		}

		public void SetPixel(int x, int y, Colors color, char chr)
		{
			if (x < 0 || x >= Width || y < 0 || y >= Height)
			{
				return;
			}

			consoleScreenBuffer[x + y * Width].Attributes = (short) color;
			consoleScreenBuffer[x + y * Width].Char.AsciiChar = (byte) chr;
		}

		public void SetPixel(int x, int y, Colors color)
		{
			if (x < 0 || x >= Width || y < 0 || y >= Height)
			{
				return;
			}

			char chr = (char) (y % 2 == 0 ? 223 : 220);

			short mody = (short) System.Math.Round((y / 2.0));
			y -= mody;

			char oldchr = (char) consoleScreenBuffer[x + y * Width].Char.AsciiChar;

			if (oldchr == 219 || oldchr == chr)
			{
				consoleScreenBuffer[x + y * Width].Attributes = (short) color;
				consoleScreenBuffer[x + y * Width].Char.AsciiChar = (byte) oldchr;

				return;
			}

			if (oldchr != ' ')
			{
				consoleScreenBuffer[x + y * Width].Char.AsciiChar = 219;
			}
			else
			{
				consoleScreenBuffer[x + y * Width].Char.AsciiChar = (byte) chr;
			}

			consoleScreenBuffer[x + y * Width].Attributes = (short) color;
		}

		public Colors GetPixelColor(int x, int y)
		{
			if (x < 0 || x >= Width || y < 0 || y >= Height)
			{
				throw new IndexOutOfRangeException("X or Y out of range.");
			}

			return (Colors) consoleScreenBuffer[x + y * Width].Attributes;
		}

		public char GetPixelChar(int x, int y)
		{
			if (x < 0 || x >= Width || y < 0 || y >= Height)
			{
				return '\0';
			}

			return (char) consoleScreenBuffer[x + y * Width].Char.AsciiChar;
		}

		public void DrawFrame()
		{
			Kernel32Console.WriteConsoleOutput(stdOutputHandle, consoleScreenBuffer, consoleScreenBufferSize, consoleScreenBufferCoords, ref consoleScreenCoords);
		}

		public void ClearFrame(Colors color)
		{
			for (int i = 0; i < Width * Height; i++)
			{
				consoleScreenBuffer[i].Attributes = (short) color;
				consoleScreenBuffer[i].Char.AsciiChar = (byte) ' ';
			}
		}
	}
}