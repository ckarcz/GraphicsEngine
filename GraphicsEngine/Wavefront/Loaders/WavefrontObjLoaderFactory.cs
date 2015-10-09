#region Imports

using GraphicsEngine.Wavefront.Datastore;
using GraphicsEngine.Wavefront.Parsers;

#endregion

namespace GraphicsEngine.Wavefront.Loaders
{
	public class WavefrontObjLoaderFactory
		: IWavefrontObjLoaderFactory
	{
		public IWavefrontObjLoader Create()
		{
			return Create(new MaterialStreamProvider());
		}

		public IWavefrontObjLoader Create(IMaterialStreamProvider materialStreamProvider)
		{
			var dataStore = new DataStore();

			var faceParser = new FaceParser(dataStore);
			var groupParser = new GroupParser(dataStore);
			var normalParser = new VertexNormalParser(dataStore);
			var textureParser = new TextureCoordinateParser(dataStore);
			var vertexParser = new GeometricVertexParser(dataStore);

			var materialLibraryLoader = new MaterialLibraryLoader(dataStore);
			var materialLibraryLoaderFacade = new MaterialLibraryLoaderFacade(materialLibraryLoader, materialStreamProvider);
			var materialLibraryParser = new MaterialLibraryParser(materialLibraryLoaderFacade);
			var useMaterialParser = new UseMaterialParser(dataStore);

			return new WavefrontObjLoader(dataStore, faceParser, groupParser, normalParser, textureParser, vertexParser, materialLibraryParser, useMaterialParser);
		}
	}
}