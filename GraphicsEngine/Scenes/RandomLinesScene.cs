#region Imports

using System;
using System.Threading;
using GraphicsEngine.Graphics;
using GraphicsEngine.Graphics.Console;
using GraphicsEngine.Math;
using GraphicsEngine.Win32;

#endregion

namespace GraphicsEngine.Engine
{
	public class RandomLinesScene
		: IScene
	{
		private static readonly short[] colors = new short[] {Kernel32Console.Colors.FOREGROUND_BLUE, Kernel32Console.Colors.FOREGROUND_CYAN, Kernel32Console.Colors.FOREGROUND_GREEN, Kernel32Console.Colors.FOREGROUND_MAGENTA, Kernel32Console.Colors.FOREGROUND_RED, Kernel32Console.Colors.FOREGROUND_YELLOW, Kernel32Console.Colors.FOREGROUND_GREY};
		private readonly Random random = new Random(1000);
		private readonly Rasterizer rasterizer;

		public RandomLinesScene(int width, int height)
		{
			Width = width;
			Height = height;

			rasterizer = new Rasterizer(Width, Height);
		}

		public int Width { get; }
		public int Height { get; }

		public void Update()
		{
		}

		public void Draw()
		{
			Thread.Sleep(50);

			rasterizer.ClearImage((byte) ' ', (byte) Kernel32Console.Colors.BACKGROUND_BLACK | Kernel32Console.Colors.FOREGROUND_GREY | Kernel32Console.Colors.FOREGROUND_INTENSITY);

			for (var i = 0; i < 10; i++)
			{
				var randomX1 = random.Next(-Width / 2, Width / 2);
				var randomY1 = random.Next(-Width / 2, Width / 2);
				var randomX2 = random.Next(-Width / 2, Width / 2);
				var randomY2 = random.Next(-Height / 2, Height / 2);
				var randomColorIndex = random.Next(0, colors.Length);
				rasterizer.DrawLine(Transformation.None, new Vector2(randomX1, randomY1), new Vector2(randomX2, randomY2), (short) (colors[randomColorIndex]), Rasterizer.HalfPixelChar);
			}
		}

		public ConsoleGraphicsFrame Rasterize()
		{
			var rasterizedFrame = rasterizer.Rasterize();
			return rasterizedFrame;
		}

		private void InitScene(string wavefrontObjFilePath)
		{
		}
	}
}