#region Imports

using GraphicsEngine.Wavefront.Datastore;
using GraphicsEngine.Wavefront.Parsers.Interfaces;

#endregion

namespace GraphicsEngine.Wavefront.Parsers
{
	public class UseMaterialParser
		: TypeParserBase, IUseMaterialParser
	{
		private readonly IElementGroup _elementGroup;

		public UseMaterialParser(IElementGroup elementGroup)
		{
			_elementGroup = elementGroup;
		}

		protected override string Keyword
		{
			get { return "usemtl"; }
		}

		public override void Parse(string line)
		{
			_elementGroup.SetMaterial(line);
		}
	}
}