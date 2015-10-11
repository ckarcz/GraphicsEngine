#region Imports

using System.Collections.Generic;

#endregion

namespace GraphicsEngine.Graphics
{
	public interface IMesh
	{
		string Name { get; }
		IEnumerable<IPolygon> Faces { get; }
	}
}