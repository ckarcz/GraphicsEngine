#region Imports

using System;
using GraphicsEngine.Win32;

#endregion

namespace GraphicsEngine.Graphics.Console
{
	public class Kernel32ConsoleScreen
		: IConsoleScreen
	{
		private Kernel32Console.SmallRect consoleScreenCoords;
		private readonly Kernel32Console.CharInfo[] consoleScreenBuffer;
		private readonly Kernel32Console.Coord consoleScreenBufferCoords;
		private readonly Kernel32Console.CONSOLE_SCREEN_BUFFER_INFO_EX consoleScreenBufferInfoEx;
		private readonly Kernel32Console.Coord consoleScreenBufferSize;
		private readonly byte emptyPixelChar = (byte) ' ';
        private readonly IntPtr stdOutputHandle;

		public Kernel32ConsoleScreen(int width, int height)
		{
			Width = width;
			Height = height;

			this.stdOutputHandle = Kernel32Console.GetStdHandle(Kernel32Console.STD_OUTPUT_HANDLE);

			consoleScreenBufferSize = new Kernel32Console.Coord(Width, Height);
			consoleScreenBufferCoords = new Kernel32Console.Coord(0, 0);
			consoleScreenCoords = new Kernel32Console.SmallRect(0, 0, Width, Height);

			consoleScreenBufferInfoEx = Kernel32Console.CONSOLE_SCREEN_BUFFER_INFO_EX.Create();
			Kernel32Console.GetConsoleScreenBufferInfoEx(stdOutputHandle, ref consoleScreenBufferInfoEx);

			consoleScreenBufferInfoEx.dwSize = new Kernel32Console.Coord(Width, Height);
			consoleScreenBufferInfoEx.dwCursorPosition = new Kernel32Console.Coord(0, 0);

			Kernel32Console.SetConsoleScreenBufferInfoEx(stdOutputHandle, ref consoleScreenBufferInfoEx);

			consoleScreenBuffer = new Kernel32Console.CharInfo[Width * Height];
			var chri = new Kernel32Console.CharInfo(new Kernel32Console.CharUnion(' '), 0);

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

		public void SetFrame(IConsoleGraphicsFrame consoleGraphicsBuffer)
		{
			var characterBuffer = consoleGraphicsBuffer.CharacterBuffer;
			var colorBuffer = consoleGraphicsBuffer.ColorBuffer;

			for (var x = 0; x < consoleGraphicsBuffer.Width; x++)
			{
				for (var y = 0; y < consoleGraphicsBuffer.Height; y++)
				{
					var character = characterBuffer[x, y];
					var color = colorBuffer[x, y];

					SetPixel(x, y, color, character);
				}
			}
		}

		public void SetPixel(int x, int y, short color, byte chr)
		{
			if (x < 0 || x >= Width || y < 0 || y >= Height)
			{
				throw new IndexOutOfRangeException("X or Y out of range.");
			}

			consoleScreenBuffer[x + y * Width].Attributes = color;
			consoleScreenBuffer[x + y * Width].Char.AsciiChar = chr;
		}

		public void SetPixel(int x, int y, short color)
		{
			if (x < 0 || x >= Width || y < 0 || y >= Height)
			{
				throw new IndexOutOfRangeException("X or Y out of range.");
			}

			char chr = (char) (y % 2 == 0 ? 223 : 220);

			short mody = (short) System.Math.Round((y / 2.0));
			y -= mody;

			char oldchr = (char) consoleScreenBuffer[x + y * Width].Char.AsciiChar;

			if (oldchr == 219 || oldchr == chr)
			{
				consoleScreenBuffer[x + y * Width].Attributes = color;
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

		public short GetPixelColor(int x, int y)
		{
			if (x < 0 || x >= Width || y < 0 || y >= Height)
			{
				throw new IndexOutOfRangeException("X or Y out of range.");
			}

			return consoleScreenBuffer[x + y * Width].Attributes;
		}

		public byte GetPixelChar(int x, int y)
		{
			if (x < 0 || x >= Width || y < 0 || y >= Height)
			{
				throw new IndexOutOfRangeException("X or Y out of range.");
			}

			return consoleScreenBuffer[x + y * Width].Char.AsciiChar;
		}

		public void Draw()
		{
			Kernel32Console.WriteConsoleOutput(stdOutputHandle, consoleScreenBuffer, consoleScreenBufferSize, consoleScreenBufferCoords, ref consoleScreenCoords);
		}

		public void ClearFrame(short color)
		{
			for (int i = 0; i < Width * Height; i++)
			{
				consoleScreenBuffer[i].Attributes = color;
				consoleScreenBuffer[i].Char.AsciiChar = emptyPixelChar;
			}
		}
	}
}