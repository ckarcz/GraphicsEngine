namespace GraphicsEngine.Wavefront.Parsers.Interfaces
{
	public interface ITypeParser
	{
		bool CanParse(string keyword);

		void Parse(string line);
	}
}