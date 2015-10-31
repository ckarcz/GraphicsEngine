using System;
using System.Net.Configuration;

namespace GraphicsEngine.Math
{
	public struct Edge2
		: IEquatable<Edge2>
	{
		public Edge2(Vector2 start, Vector2 end)
			: this()
		{
			Start = start;
			End = end;
		}

		public Vector2 Start { get; set; }
		public Vector2 End { get; set; }

		public Vector2 Direction
		{
			get { return Start.GetDirection(End); }
		}

		public float Distance
		{
			get { return Start.GetDistance(End); }
		}

		public static bool operator ==(Edge2 thisEdge, Edge2 otherEdge)
		{
			return ((thisEdge.Start == otherEdge.Start) &&
					(thisEdge.End == otherEdge.End));
		}

		public static bool operator !=(Edge2 thisEdge, Edge2 otherEdge)
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

		public Vector2 GetPointFromX(float xGiven)
		{
			var t = (xGiven - Start.X) / (End.X - Start.X);
			return Start + ((End - Start) * t);
		}

		public Vector2 GetPointFromY(float yGiven)
		{
			var t = (yGiven - Start.Y) / (End.Y - Start.Y);
			return Start + ((End - Start) * t);
		}

		public bool Equals(Edge2 other)
		{
			return this == other;
		}

		public override string ToString()
		{
			return string.Format("{0}<->{1}", Start, End);
		}
	}
}