#region Imports

using GraphicsEngine.Wavefront.Loaders;
using GraphicsEngine.Wavefront.Parsers.Interfaces;

#endregion

namespace GraphicsEngine.Wavefront.Parsers
{
	public class MaterialLibraryParser
		: TypeParserBase, IMaterialLibraryParser
	{
		private readonly IMaterialLibraryLoaderFacade _libraryLoaderFacade;

		public MaterialLibraryParser(IMaterialLibraryLoaderFacade libraryLoaderFacade)
		{
			_libraryLoaderFacade = libraryLoaderFacade;
		}

		protected override string Keyword
		{
			get { return "mtllib"; }
		}

		public override void Parse(string line)
		{
			_libraryLoaderFacade.Load(line);
		}
	}
}