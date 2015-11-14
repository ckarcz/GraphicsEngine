#region Imports

using System.Collections.Generic;

#endregion

namespace GraphicsEngine.Graphics
{
	public interface IMeshFormatter
	{
		IEnumerable<IMesh> Transform(IEnumerable<IMesh> meshes);

		IMesh Transform(IMesh mesh);
	}
}