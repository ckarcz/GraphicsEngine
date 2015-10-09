#region Imports

using GraphicsEngine.Wavefront.Datastore;
using GraphicsEngine.Wavefront.Parsers.Interfaces;

#endregion

namespace GraphicsEngine.Wavefront.Parsers
{
	public class GroupParser
		: TypeParserBase, IGroupParser
	{
		private readonly IGroupDataStore _groupDataStore;

		public GroupParser(IGroupDataStore groupDataStore)
		{
			_groupDataStore = groupDataStore;
		}

		protected override string Keyword
		{
			get { return "g"; }
		}

		public override void Parse(string line)
		{
			_groupDataStore.PushGroup(line);
		}
	}
}