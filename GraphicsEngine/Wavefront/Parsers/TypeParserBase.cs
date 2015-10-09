#region Imports

using GraphicsEngine.Common.Extensions;
using GraphicsEngine.Wavefront.Parsers.Interfaces;

#endregion

namespace GraphicsEngine.Wavefront.Parsers
{
	public abstract class TypeParserBase
		: ITypeParser
	{
		protected abstract string Keyword { get; }

		public bool CanParse(string keyword)
		{
			return keyword.EqualsInvariantCultureIgnoreCase(Keyword);
		}

		public abstract void Parse(string line);
	}
}