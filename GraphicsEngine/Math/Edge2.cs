#region Imports

using System;

#endregion

namespace GraphicsEngine.Math
{
	public struct Edge2
		: IEquatable<Edge2>
	{
		#region Constructors

		public Edge2(Vector2 start, Vector2 end)
			: this()
		{
			Start = start;
			End = end;
		}

		#endregion Constructors

		#region Public Properties

		public Vector2 Start { get; }
		public Vector2 End { get; }

		public Vector2 Direction
		{
			get { return Start.GetDirection(End); }
		}

		public float Distance
		{
			get { return Start.GetDistance(End); }
		}

		#endregion Public Properties

		#region Operators

		public static bool operator ==(Edge2 thisEdge, Edge2 otherEdge)
		{
			return ((thisEdge.Start == otherEdge.Start) &&
					(thisEdge.End == otherEdge.End));
		}

		public static bool operator !=(Edge2 thisEdge, Edge2 otherEdge)
		{
			return ((thisEdge.Start != otherEdge.Start) ||
					(thisEdge.End != otherEdge.End));
		}

		#endregion Operators

		#region Public Methods

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

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}

			return obj is Edge2 && Equals((Edge2) obj);
		}

		public bool Equals(Edge2 otherEdge)
		{
			return Equals(this, otherEdge);
		}

		public static bool Equals(Edge3 thisEdge, Edge3 otherEdge)
		{
			return thisEdge == otherEdge;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Start.GetHashCode() * 397) ^ End.GetHashCode();
			}
		}

		public override string ToString()
		{
			return string.Format("{0}<->{1}", Start, End);
		}

		#endregion Public Methods
	}
}