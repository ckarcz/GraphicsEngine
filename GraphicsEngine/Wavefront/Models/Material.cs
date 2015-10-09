namespace GraphicsEngine.Wavefront.Models
{
	public class Material
	{
		public Material(string materialName)
		{
			Name = materialName;
		}

		public string Name { get; set; }
		public Colour AmbientColor { get; set; }
		public Colour DiffuseColor { get; set; }
		public Colour SpecularColor { get; set; }
		public float SpecularCoefficient { get; set; }
		public float Transparency { get; set; }
		public int IlluminationModel { get; set; }
		public string AmbientTextureMap { get; set; }
		public string DiffuseTextureMap { get; set; }
		public string SpecularTextureMap { get; set; }
		public string SpecularHighlightTextureMap { get; set; }
		public string BumpMap { get; set; }
		public string DisplacementMap { get; set; }
		public string StencilDecalMap { get; set; }
		public string AlphaTextureMap { get; set; }
	}
}