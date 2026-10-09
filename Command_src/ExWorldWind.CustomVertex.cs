using System.Numerics;

namespace ExWorldWind;

public class CustomVertex
{
	public struct PositionColored
	{
		public float X;

		public float Y;

		public float Z;

		public int Color;

		public PositionColored(float x, float y, float z, int color)
		{
			X = x;
			Y = y;
			Z = z;
			Color = color;
		}

		public PositionColored(Vector3 position, int color)
		{
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			X = position.X;
			Y = position.Y;
			Z = position.Z;
			Color = color;
		}

		static PositionColored()
		{
			Class72.smethod_20();
		}
	}

	public struct PositionTextured
	{
		public float X;

		public float Y;

		public float Z;

		public float Tu;

		public float Tv;

		public PositionTextured(Vector3 position, float u, float v)
		{
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			X = position.X;
			Y = position.Y;
			Z = position.Z;
			Tu = u;
			Tv = v;
		}

		static PositionTextured()
		{
			Class72.smethod_20();
		}
	}

	static CustomVertex()
	{
		Class72.smethod_20();
	}
}
