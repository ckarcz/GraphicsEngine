#region Imports

using System.Collections.Generic;
using System.Linq;
using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Graphics
{
	public class Mesh
		: IMesh
	{
		private Vector3? center = null;
		private Vector3? maximums = null;
		private Vector3? minimums = null;

		public Mesh()
		{
			Faces = new List<IPolygon>();
		}

		public IList<IPolygon> Faces { get; }

		public Vector3? Centers
		{
			get
			{
				if (Minimums.HasValue && Maximums.HasValue && center == null)
				{
					center = Minimums.Value.GetMiddle(Maximums.Value);
				}

				return center;
			}
		}

		public string Name { get; set; }

		public Vector3? Maximums
		{
			get
			{
				if (Faces.Any() && Faces.Any(face => face.Points.Any()) && maximums == null)
				{
					var temp = new Vector3(Faces[0][0].X, Faces[0][0].Y, Faces[0][0].Z);
					foreach (var face in Faces)
					{
						foreach (var point in face.Points)
						{
							temp.X = System.Math.Max(temp.X, point.X);
							temp.Y = System.Math.Max(temp.Y, point.Y);
							temp.Z = System.Math.Max(temp.Z, point.Z);
						}
					}

					maximums = temp;
				}

				return maximums;
			}
		}

		public Vector3? Minimums
		{
			get
			{
				if (Faces.Any() && Faces.Any(face => face.Points.Any()) && minimums == null)
				{
					var temp = new Vector3(Faces[0][0].X, Faces[0][0].Y, Faces[0][0].Z);
					foreach (var face in Faces)
					{
						foreach (var point in face.Points)
						{
							temp.X = System.Math.Min(temp.X, point.X);
							temp.Y = System.Math.Min(temp.Y, point.Y);
							temp.Z = System.Math.Min(temp.Z, point.Z);
						}
					}

					minimums = temp;
				}

				return minimums;
			}
		}

		IEnumerable<IPolygon> IMesh.Faces
		{
			get { return Faces; }
		}
	}
}