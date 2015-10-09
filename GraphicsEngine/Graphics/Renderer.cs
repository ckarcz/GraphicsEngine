#region Imports

using System;
using System.IO;

#endregion

namespace GraphicsEngine.Graphics
{
	public class Renderer
	{
		private int lastTime;
		private int numRenderings;
		private readonly Stream stdOutputStream = Console.OpenStandardOutput();

		public void Render(IScreenBuffer screenBuffer)
		{
			byte[] bufImg = new byte[screenBuffer.Width * screenBuffer.Height];
			for (int x = 0; x < screenBuffer.Width; x++)
			{
				for (int y = 0; y < screenBuffer.Height; y++)
				{
					bufImg[x + y * screenBuffer.Width] = screenBuffer[x, y];
				}
			}
			int beginRender = Environment.TickCount;

			Console.SetCursorPosition(0, 0);
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