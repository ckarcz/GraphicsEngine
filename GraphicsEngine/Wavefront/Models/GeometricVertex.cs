namespace GraphicsEngine.Wavefront.Models
{
	public struct GeometricVertex
	{
		public GeometricVertex(float x, float y, float z)
			: this()
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