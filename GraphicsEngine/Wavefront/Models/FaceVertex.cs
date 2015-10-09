namespace GraphicsEngine.Wavefront.Models
{
	public struct FaceVertex
	{
		public FaceVertex(int vertexIndex, int textureIndex, int normalIndex)
			: this()
		{
			VertexIndex = vertexIndex;
			TextureIndex = textureIndex;
			NormalIndex = normalIndex;
		}

		public int VertexIndex { get; set; }
		public int TextureIndex { get; set; }
		public int NormalIndex { get; set; }
	}
}