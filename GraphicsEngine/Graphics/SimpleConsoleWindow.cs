#region Imports

using System;
using System.IO;
using System.Threading.Tasks;

#endregion

namespace GraphicsEngine.Graphics
{
	public class SimpleConsoleWindow
		: IConsoleWindow
	{
		private readonly byte[] characterBuffer;
		private readonly Stream stdOutputStream;

		public SimpleConsoleWindow(int width, int height, string windowTitle = null, ConsoleColor backgroundColor = ConsoleColor.Black, ConsoleColor foregroundColor = ConsoleColor.Cyan)
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

		public string Title
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

		public void Set(int x, int y, byte character, ushort color)
		{
			SetCharacter(x, y, character);
		}

		public void SetCharacter(int x, int y, byte character)
		{
			characterBuffer[x + y * Width] = character;
		}

		public void SetColor(int x, int y, ushort color)
		{
			throw new NotSupportedException();
		}

		public ushort GetColor(int x, int y)
		{
			throw new NotSupportedException();
		}

		public byte GetCharacter(int x, int y)
		{
			return characterBuffer[x + y * Width];
		}

		public void Update()
		{
			System.Console.SetCursorPosition(0, 0);
			stdOutputStream.Write(characterBuffer, 0, characterBuffer.Length);
		}

		public void Clear(byte? character = null, ushort? color = null)
		{
			Parallel.For(0, characterBuffer.Length, i =>
			{
				characterBuffer[i] = character ?? (byte) ' ';
			});
		}
	}
}