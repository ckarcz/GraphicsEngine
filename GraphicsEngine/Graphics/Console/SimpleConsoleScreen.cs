using System;
using System.IO;

namespace GraphicsEngine.Graphics.Console
{
	public class SimpleConsoleScreen
		: IConsoleScreen
	{
		private readonly Stream stdOutputStream;
		private readonly byte[] characterBuffer;

		public SimpleConsoleScreen(int width, int height, string windowTitle = null, ConsoleColor backgroundColor = ConsoleColor.Black, ConsoleColor foregroundColor = ConsoleColor.Cyan)
		{
			stdOutputStream = System.Console.OpenStandardOutput();

			Width = width;
			Height = height;
			characterBuffer = new byte[Width * Height];

			System.Console.Title = windowTitle;
			System.Console.CursorVisible = false;
			System.Console.BackgroundColor = backgroundColor;
			reTry:
			try
			{
				System.Console.SetWindowSize(width, height);
				System.Console.SetBufferSize(width, height);
			}
			catch (ArgumentOutOfRangeException)
			{
				System.Console.WriteLine("Decrease your font size and press enter");
				System.Console.ReadLine();
				goto reTry;
			}
			System.Console.Clear();
			System.Console.SetCursorPosition(0, 0);
			System.Console.ForegroundColor = foregroundColor;
		}

		public int Width { get; private set; }

		public int Height { get; private set; }

		public void ShowCursor(bool showCursor)
		{
			System.Console.CursorVisible = showCursor;
		}

		public void SetCursor(int x, int y)
		{
			System.Console.CursorLeft = (Width / 2) + x;
			System.Console.CursorTop = (Height / 2) + y;
		}

		public void SetFrame(IConsoleGraphicsFrame consoleGraphicsBuffer)
		{
			for (var x = 0; x < Width; x++)
			{
				for (var y = 0; y < Height; y++)
				{
					characterBuffer[x + y * Width] = consoleGraphicsBuffer.CharacterBuffer[x, y];
				}
			}
		}

		public void SetPixel(int x, int y, short color, byte chr)
		{
			throw new NotImplementedException();
		}

		public void SetPixel(int x, int y, short color)
		{
			throw new System.NotImplementedException();
		}

		public short GetPixelColor(int x, int y)
		{
			throw new System.NotImplementedException();
		}

		public byte GetPixelChar(int x, int y)
		{
			return characterBuffer[x + y * Width];
		}

		public void Draw()
		{
			System.Console.SetCursorPosition(0, 0);
			stdOutputStream.Write(characterBuffer, 0, characterBuffer.Length);
		}

		public void ClearFrame(short color)
		{
			for (int i = 0; i < characterBuffer.Length; i++)
			{
				characterBuffer[i] = (byte)' ';
			}
		}
	}
}