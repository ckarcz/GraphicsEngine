#region Imports

using System.Collections.Generic;

#endregion

namespace GraphicsEngine.Graphics
{
	public interface IMeshFormatter
	{
		IEnumerable<IMesh> Format(IEnumerable<IMesh> meshes);

		IMesh Format(IMesh mesh);
	}
}