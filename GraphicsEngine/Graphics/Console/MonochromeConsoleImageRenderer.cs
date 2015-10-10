#region Imports

using System;
using System.IO;

#endregion

namespace GraphicsEngine.Graphics.Console
{
	public class MonochromeConsoleImageRenderer
	{
		private int lastTime;
		private int numRenderings;
		private readonly IConsoleScreenConfig consoleScreenConfig;
		private readonly Stream stdOutputStream = System.Console.OpenStandardOutput();

		public MonochromeConsoleImageRenderer(IConsoleScreenConfig consoleScreenConfig)
		{
			this.consoleScreenConfig = consoleScreenConfig;

			System.Console.Title = "Graphics Engine Test";
			System.Console.CursorVisible = false;
			System.Console.BackgroundColor = ConsoleColor.Black;
			reTry:
			try
			{
				System.Console.SetWindowSize(consoleScreenConfig.Width, consoleScreenConfig.Height + 15);
				System.Console.SetBufferSize(consoleScreenConfig.Height, consoleScreenConfig.Height + 15);
			}
			catch (ArgumentOutOfRangeException)
			{
				System.Console.WriteLine("Decrease your font size and press enter");
				System.Console.ReadLine();
				goto reTry;
			}
			System.Console.Clear(); //clear colors from user preset.
			System.Console.SetCursorPosition(0, consoleScreenConfig.Height);
			System.Console.Write(new String('▄', consoleScreenConfig.Width));
			System.Console.ForegroundColor = ConsoleColor.Cyan;
		}

		public void RenderImage(IRasterizedImage rasterizedImage)
		{
			var bufImg = new byte[rasterizedImage.Width * rasterizedImage.Height];
			for (var x = 0; x < rasterizedImage.Width; x++)
			{
				for (var y = 0; y < rasterizedImage.Height; y++)
				{
					bufImg[x + y * rasterizedImage.Width] = rasterizedImage.CharacterBuffer[x, y];
				}
			}
			var beginRender = Environment.TickCount;

			System.Console.SetCursorPosition(0, 0);
			stdOutputStream.Write(bufImg, 0, bufImg.Length);

			var endRender = Environment.TickCount - beginRender;

			//VSync(MAX_FPS, endRender, beginRender);

			if (numRenderings == 0)
			{
				lastTime = Environment.TickCount;
			}

			numRenderings++;
		}
	}
}