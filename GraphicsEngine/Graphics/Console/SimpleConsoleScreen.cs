#region Imports

using System;
using System.IO;

#endregion

namespace GraphicsEngine.Graphics.Console
{
	public class SimpleConsoleScreen
		: IConsoleScreen
	{
		private readonly byte[] characterBuffer;
		private readonly Stream stdOutputStream;

		public SimpleConsoleScreen(int width, int height, string windowTitle = null, ConsoleColor backgroundColor = ConsoleColor.Black, ConsoleColor foregroundColor = ConsoleColor.Cyan)
		{
			stdOutputStream = System.Console.OpenStandardOutput();

			Width = width;
			Height = height;
			characterBuffer = new byte[Width * Height];

			reTry:
			System.Console.Clear();
			System.Console.BackgroundColor = backgroundColor;
			System.Console.ForegroundColor = foregroundColor;

			try
			{
				System.Console.BackgroundColor = ConsoleColor.Black;
				System.Console.ForegroundColor = ConsoleColor.Magenta;
				System.Console.SetWindowSize(width, height + 1);
				System.Console.SetBufferSize(width, height + 1);
				System.Console.SetCursorPosition(0, height);
				System.Console.Write(new String(' ', width));
			}
			catch (ArgumentOutOfRangeException)
			{
				System.Console.WriteLine("Change console window font to 'Raster Fonts' and font size to '4 x 6' and hit ENTER.");
				System.Console.ReadLine();
				goto reTry;
			}

			System.Console.Title = windowTitle;
			System.Console.SetCursorPosition(0, 0);
			System.Console.CursorVisible = false;
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
			throw new NotImplementedException();
		}

		public short GetPixelColor(int x, int y)
		{
			throw new NotImplementedException();
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
				characterBuffer[i] = (byte) ' ';
			}
		}
	}
}