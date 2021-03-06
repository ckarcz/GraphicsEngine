﻿namespace GraphicsEngine.Graphics
{
	public class CharacterBuffer
		: ICharacterBuffer
	{
		private readonly byte[,] consoleCharacterBuffer;

		public CharacterBuffer(int width, int height)
		{
			consoleCharacterBuffer = new byte[width, height];
			Width = width;
			Height = height;
		}

		public byte this[int x, int y]
		{
			get { return consoleCharacterBuffer[x, y]; }
			set { consoleCharacterBuffer[x, y] = value; }
		}

		public int Width { get; private set; }
		public int Height { get; private set; }

		public byte[,] GetMultiArrayAsCopy()
		{
			var copy = new byte[Width, Height];
			consoleCharacterBuffer.CopyTo(copy, 0);

			return copy;
		}

		public byte[] GetBytesCopy()
		{
			var screenBufferBytes = new byte[Width * Height];
			for (var x = 0; x < Width; x++)
			{
				for (var y = 0; y < Height; y++)
				{
					screenBufferBytes[x + y * Width] = consoleCharacterBuffer[x, y];
				}
			}

			return screenBufferBytes;
		}
	}
}