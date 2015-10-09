#region Imports

using System.Collections.Generic;
using System.IO;
using GraphicsEngine.Wavefront.Datastore;
using GraphicsEngine.Wavefront.Parsers.Interfaces;

#endregion

namespace GraphicsEngine.Wavefront.Loaders
{
	public class WavefrontObjLoader
		: LoaderBase, IWavefrontObjLoader
	{
		private readonly IDataStore _dataStore;
		private readonly List<ITypeParser> _typeParsers = new List<ITypeParser>();
		private readonly List<string> _unrecognizedLines = new List<string>();

		public WavefrontObjLoader(
			IDataStore dataStore,
			IFaceParser faceParser,
			IGroupParser groupParser,
			IVertexNormalParser normalParser,
			ITextureCoordinateParser textureParser,
			IGeometricVertexParser vertexParser,
			IMaterialLibraryParser materialLibraryParser,
			IUseMaterialParser useMaterialParser)
		{
			_dataStore = dataStore;
			SetupTypeParsers(
							 vertexParser,
				faceParser,
				normalParser,
				textureParser,
				groupParser,
				materialLibraryParser,
				useMaterialParser);
		}

		public IWavefrontObj LoadWavefrontObj(Stream lineStream)
		{
			StartLoad(lineStream);

			return CreateResult();
		}

		private void SetupTypeParsers(params ITypeParser[] parsers)
		{
			foreach (var parser in parsers)
			{
				_typeParsers.Add(parser);
			}
		}

		protected override void ParseLine(string keyword, string data)
		{
			foreach (var typeParser in _typeParsers)
			{
				if (typeParser.CanParse(keyword))
				{
					typeParser.Parse(data);
					return;
				}
			}

			_unrecognizedLines.Add(keyword + " " + data);
		}

		private WavefrontObj CreateResult()
		{
			var result = new WavefrontObj(_dataStore.Vertices, _dataStore.Textures, _dataStore.Normals, _dataStore.Groups, _dataStore.Materials);
			return result;
		}
	}
}