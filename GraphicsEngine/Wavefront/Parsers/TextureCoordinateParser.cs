#region Imports

using GraphicsEngine.Common.Extensions;
using GraphicsEngine.Wavefront.Datastore;
using GraphicsEngine.Wavefront.Models;
using GraphicsEngine.Wavefront.Parsers.Interfaces;

#endregion

namespace GraphicsEngine.Wavefront.Parsers
{
	public class TextureCoordinateParser
		: TypeParserBase, ITextureCoordinateParser
	{
		private readonly ITextureCoordinateDataStore _textureDataStore;

		public TextureCoordinateParser(ITextureCoordinateDataStore textureDataStore)
		{
			_textureDataStore = textureDataStore;
		}

		protected override string Keyword
		{
			get { return "vt"; }
		}

		public override void Parse(string line)
		{
			string[] parts = line.Split(' ');

			float x = parts[0].ParseInvariantFloat();
			float y = parts[1].ParseInvariantFloat();

			var texture = new TextureCoordinate(x, y);
			_textureDataStore.AddTexture(texture);
		}
	}
}