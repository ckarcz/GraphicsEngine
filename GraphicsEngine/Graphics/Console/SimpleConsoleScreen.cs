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
				System.Console.SetWindowSize(width, height + 1);
				System.Console.SetBufferSize(width, height + 1);
				System.Console.SetCursorPosition(0, height);
				System.Console.Write(new String(' ', width));
			}
			catch (ArgumentOutOfRangeException ex)
			{
				System.Console.BackgroundColor = ConsoleColor.Black;
				System.Console.ForegroundColor = ConsoleColor.Magenta;
				System.Console.WriteLine("Change console window font to 'Raster Fonts' and font size to '4 x 6' and hit ENTER.");
				System.Console.ReadLine();
				goto reTry;
			}

			System.Console.Title = windowTitle;
			System.Console.SetCursorPosition(0, 0);
			System.Console.CursorVisible = false;
		}

		public string WindowTitle
		{
			get { return System.Console.Title; }
			set { System.Console.Title = value; }
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

		public void SetPixel(int x, int y, byte character, short color)
		{
			SetPixel(x, y, character);
		}

		public void SetPixel(int x, int y, byte character)
		{
			characterBuffer[x + y * Width] = character;
		}

		public void SetPixel(int x, int y, short color)
		{
			throw new NotSupportedException();
		}

		public short GetPixelColor(int x, int y)
		{
			throw new NotSupportedException();
		}

		public byte GetPixelCharacter(int x, int y)
		{
			return characterBuffer[x + y * Width];
		}

		public void Write()
		{
			System.Console.SetCursorPosition(0, 0);
			stdOutputStream.Write(characterBuffer, 0, characterBuffer.Length);
		}

		public void Clear(byte? character = null, short? color = null)
		{
			for (int i = 0; i < characterBuffer.Length; i++)
			{
				characterBuffer[i] = character ?? (byte) ' ';
			}
		}
	}
}