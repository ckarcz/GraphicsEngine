namespace GraphicsEngine.Wavefront.Models
{
	public struct VertexNormal
	{
		public VertexNormal(float x, float y, float z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public float X { get; private set; }
		public float Y { get; private set; }
		public float Z { get; private set; }
	}
}