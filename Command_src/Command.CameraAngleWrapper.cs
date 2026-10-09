using System;
using CSMaterial.ExWorldWind;

namespace Command;

public sealed class CameraAngleWrapper
{
	public Angle Latitude;

	public Angle Longitude;

	public CameraAngleWrapper(Angle _Latitude, Angle _Longitude)
	{
		Latitude = _Latitude;
		Longitude = _Longitude;
	}

	public static bool IsIdentical(CameraAngleWrapper A, CameraAngleWrapper B, double ErrorMargin = 0.0)
	{
		if (ErrorMargin == 0.0)
		{
			if (A.Longitude.Radians != B.Longitude.Radians)
			{
				return false;
			}
			if (A.Latitude.Radians != B.Latitude.Radians)
			{
				return false;
			}
			return true;
		}
		if (Math.Abs(A.Longitude.Radians - B.Longitude.Radians) > ErrorMargin)
		{
			return false;
		}
		if (Math.Abs(A.Latitude.Radians - B.Latitude.Radians) > ErrorMargin)
		{
			return false;
		}
		return true;
	}

	static CameraAngleWrapper()
	{
		Class72.smethod_20();
	}
}
