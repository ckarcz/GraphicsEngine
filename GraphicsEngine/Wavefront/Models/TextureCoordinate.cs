namespace GraphicsEngine.Wavefront.Models
{
	public struct TextureCoordinate
	{
		public TextureCoordinate(float x, float y)
		{
			X = x;
			Y = y;
		}

		public float X { get; private set; }
		public float Y { get; private set; }
	}
}