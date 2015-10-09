namespace GraphicsEngine.Wavefront.Models
{
	public struct Colour
	{
		public Colour(float r, float g, float b)
		{
			R = r;
			G = g;
			B = b;
		}

		public float R { get; private set; }
		public float G { get; private set; }
		public float B { get; private set; }
	}
}