namespace GraphicsEngine.Math
{
	internal static class MathUtil
	{
		public const float Pi = (float) System.Math.PI;
		public const float PiOver2 = (float) (System.Math.PI / 2.0);
		public const float PiOver4 = (float) (System.Math.PI / 4.0);
		public const float TwoPi = (float) (System.Math.PI * 2.0);

		public static double ToRadian(double degrees)
		{
			return System.Math.PI * degrees / 180.0;
		}

		public static double ToDegree(double radians)
		{
			return 180 * radians / System.Math.PI;
		}

		public static double Clamp(double value, double min, double max)
		{
			value = (value > max) ? max : value;
			value = (value < min) ? min : value;

			return value;
		}

		public static int Clamp(int value, int min, int max)
		{
			value = (value > max) ? max : value;
			value = (value < min) ? min : value;

			return value;
		}

		public static float Distance(float value1, float value2)
		{
			return System.Math.Abs(value1 - value2);
		}

		public static int Distance(int value1, int value2)
		{
			return System.Math.Abs(value1 - value2);
		}

		public static double Interpolate(double value, double fMin, double fMax, double tMin, double tMax)
		{
			var fDist = fMax - fMin;
			var tdist = tMax - tMin;

			var scaled = (value - fMin) / fDist;

			return tMin + (scaled * tdist);
		}
	}
}