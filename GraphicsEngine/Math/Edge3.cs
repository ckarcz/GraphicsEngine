using System;
using System.Net.Configuration;

namespace GraphicsEngine.Math
{
	public struct Edge3
		: IEquatable<Edge3>
	{
		public Edge3(Vector3 start, Vector3 end)
			: this()
		{
			Start = start;
			End = end;
		}

		public Vector3 Start { get; set; }
		public Vector3 End { get; set; }

		public Vector3 Direction
		{
			get { return Start.GetDirection(End); }
		}

		public float Distance
		{
			get { return Start.GetDistance(End); }
		}

		public static bool operator ==(Edge3 thisEdge, Edge3 otherEdge)
		{
			return ((thisEdge.Start == otherEdge.Start) &&
					(thisEdge.End == otherEdge.End));
		}

		public static bool operator !=(Edge3 thisEdge, Edge3 otherEdge)
		{
			return ((thisEdge.Start != otherEdge.Start) &&
					(thisEdge.End != otherEdge.End));
		}

		public bool IsXValueOnEdge(float xGiven)
		{
			if (Start.X > End.X)
			{
				return xGiven >= End.X && xGiven <= Start.X;
			}
			else
			{
				return xGiven <= End.X && xGiven >= Start.X;
			}
		}

		public bool IsYValueOnEdge(float yGiven)
		{
			if (Start.Y > End.Y)
			{
				return yGiven >= End.Y && yGiven <= Start.Y;
			}
			else
			{
				return yGiven <= End.Y && yGiven >= Start.Y;
			}
		}

		public bool IsZValueOnEdge(float zGiven)
		{
			if (Start.Z > End.Z)
			{
				return zGiven >= End.Z && zGiven <= Start.Z;
			}
			else
			{
				return zGiven <= End.Z && zGiven >= Start.Z;
			}
		}

		public Vector3 GetPointFromX(float xGiven)
		{
			var t = (xGiven - Start.X) / (End.X - Start.X);
			return Start + ((End - Start) * t);
		}

		public Vector3 GetPointFromY(float yGiven)
		{
			var t = (yGiven - Start.Y) / (End.Y - Start.Y);
			return Start + ((End - Start) * t);
		}

		public Vector3 GetPointFromZ(float zGiven)
		{
			var t = (zGiven - Start.Z) / (End.Z - Start.Z);
			return Start + ((End - Start) * t);
		}

		public bool Equals(Edge3 other)
		{
			return this == other;
		}

		public override string ToString()
		{
			return string.Format("{0}<->{1}", Start, End);
		}
	}
}