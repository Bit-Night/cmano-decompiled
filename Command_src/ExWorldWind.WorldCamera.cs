using System;
using System.Buffers;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading;
using CSMaterial.ExWorldWind;

namespace ExWorldWind;

public class WorldCamera
{
	public delegate void PanDelegate();

	[CompilerGenerated]
	private PanDelegate panDelegate_0 = delegate
	{
	};

	internal Angle TrueViewRange;

	public Vector3 ReferenceCenter;

	public ViewFrustum ViewFrustum = new ViewFrustum();

	internal Matrix4x4 View;

	internal Matrix4x4 Projection;

	public float ViewportWidth;

	public float ViewportHeight;

	protected int lastStepZoomTickCount;

	protected double _distance;

	protected double _altitude;

	protected Angle _latitude;

	protected Angle _longitude;

	protected Angle _heading;

	protected Quaternion4d m_Orientation = Quaternion4d.EulerToQuaternion(0.0, 0.0, 0.0);

	protected Angle _tilt;

	protected static readonly double minimumAltitude;

	private Matrix4x4 matrix4x4_0 = Matrix4x4.Identity;

	private Matrix4x4 matrix4x4_1 = Matrix4x4.CreateTranslation(0f, 0f, 6378137f);

	private Matrix4x4 matrix4x4_2;

	private Matrix4x4 matrix4x4_3;

	private float float_0;

	private float float_1;

	public virtual float Altitude
	{
		get
		{
			return (float)_altitude;
		}
		set
		{
			if (TargetAltitude != (double)value)
			{
				if ((double)value < minimumAltitude)
				{
					value = (float)minimumAltitude;
				}
				TargetAltitude = value;
			}
		}
	}

	public virtual double TargetAltitude
	{
		get
		{
			return _altitude;
		}
		set
		{
			float num = 127562740f;
			if (value < minimumAltitude)
			{
				value = minimumAltitude;
			}
			if (value > (double)num)
			{
				value = num;
			}
			_altitude = value;
			ComputeDistance(_altitude, _tilt);
		}
	}

	public virtual Angle Latitude => _latitude;

	public virtual Angle Longitude => _longitude;

	public double TargetDistance
	{
		get
		{
			return _distance;
		}
		set
		{
			int num = 10;
			float num2 = 127562740f;
			Angle tilt = new Angle
			{
				Radians = 0.0
			};
			if (value < 10.0)
			{
				value = num;
			}
			if (value > (double)num2)
			{
				value = num2;
			}
			_distance = value;
			ComputeAltitude(_distance, tilt);
		}
	}

	public event PanDelegate PanEvent
	{
		[CompilerGenerated]
		add
		{
			PanDelegate panDelegate = panDelegate_0;
			PanDelegate panDelegate2;
			do
			{
				panDelegate2 = panDelegate;
				PanDelegate value2 = (PanDelegate)Delegate.Combine(panDelegate2, value);
				panDelegate = Interlocked.CompareExchange(ref panDelegate_0, value2, panDelegate2);
			}
			while ((object)panDelegate != panDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			PanDelegate panDelegate = panDelegate_0;
			PanDelegate panDelegate2;
			do
			{
				panDelegate2 = panDelegate;
				PanDelegate value2 = (PanDelegate)Delegate.Remove(panDelegate2, value);
				panDelegate = Interlocked.CompareExchange(ref panDelegate_0, value2, panDelegate2);
			}
			while ((object)panDelegate != panDelegate2);
		}
	}

	protected void InvokePanEvent()
	{
		panDelegate_0();
	}

	internal void Update(float latitude, float longitude, float altitude, float viewportWidth, float viewportHeight, float fieldOfView)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		Altitude = altitude;
		ViewportWidth = viewportWidth;
		ViewportHeight = viewportHeight;
		ReferenceCenter = MathEngine.SphericalToCartesian(Latitude, Longitude, 6378137.0);
		float num = Altitude / 6378137f;
		if (num >= 1f)
		{
			TrueViewRange = Angle.FromRadians(Math.PI);
		}
		else
		{
			TrueViewRange = Angle.FromRadians(Math.Abs(Math.Asin(num)) * 2.0);
		}
		Matrix4x4 identity = Matrix4x4.Identity;
		Vector3 val = MathEngine.SphericalToCartesian((float)Latitude.Degrees, (float)Longitude.Degrees, 6378137f + Altitude);
		Vector3 zero = Vector3.Zero;
		Vector3 val2 = default(Vector3);
		((Vector3)(ref val2))..ctor(0f, 0f, 1f);
		View = Matrix4x4.CreateLookAt(val, zero, val2);
		ComputeProjectionMatrix(ViewportWidth, ViewportHeight, fieldOfView);
		ViewFrustum.Update(identity * View * Projection);
		matrix4x4_2 = Matrix4x4.Multiply(View, matrix4x4_1);
		matrix4x4_3 = Matrix4x4.Multiply(matrix4x4_2, Projection);
		float_0 = ViewportWidth * 0.5f;
		float_1 = ViewportHeight * 0.5f;
	}

	protected void ComputeDistance(double altitude, Angle tilt)
	{
		double num = Math.Cos(Math.PI - tilt.Radians);
		double num2 = 6378137.0 * num;
		double num3 = 6378137.0 + altitude;
		double num4 = Math.Sqrt(40680631590769.0 * num * num + num3 * num3 - 40680631590769.0);
		double num5 = num2 - num4;
		if (num5 < 0.0)
		{
			num5 = num2 + num4;
		}
		_distance = num5;
	}

	internal void ComputeProjectionMatrix(float viewportWidth, float viewportHeight, float fieldOfView)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		float num = viewportWidth / viewportHeight;
		float num2 = Altitude * 0.1f;
		double num3 = Altitude + 6378137f;
		double num4 = Math.Sqrt(num3 * num3 - 40680629993472.0);
		if (num4 < 1000000.0)
		{
			num4 = 1000000.0;
		}
		Projection = Matrix4x4.CreatePerspectiveFieldOfView(fieldOfView, num, num2, (float)num4);
	}

	public Vector3 Project(Vector3 vector3)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		Vector4 val = default(Vector4);
		((Vector4)(ref val))..ctor(vector3, 1f);
		val = Vector4.Transform(val, matrix4x4_3);
		float num = 1f / val.W;
		float num2 = val.X * num * float_0 + float_0;
		float num3 = val.Y * num * float_1 + float_1;
		num3 = ViewportHeight - num3;
		return new Vector3(num2, num3, 0f);
	}

	public Vector3[] Project(Vector3[] SourceArray)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		int num = SourceArray.Length;
		Vector3[] array = ArrayPool<Vector3>.Shared.Rent(num);
		Vector4 val2 = default(Vector4);
		for (int i = 0; i < num; i++)
		{
			Vector3 val = SourceArray[i];
			((Vector4)(ref val2))..ctor(val, 1f);
			val2 = Vector4.Transform(val2, matrix4x4_3);
			float num2 = 1f / val2.W;
			float num3 = val2.X * num2 * float_0 + float_0;
			float num4 = val2.Y * num2 * float_1 + float_1;
			num4 = ViewportHeight - num4;
			array[i] = new Vector3(num3, num4, 0f);
		}
		return array;
	}

	public void Project_Span(Span<Vector3> vectors)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		int length = vectors.Length;
		Vector4 val2 = default(Vector4);
		for (int i = 0; i < length; i++)
		{
			Vector3 val = vectors[i];
			((Vector4)(ref val2))..ctor(val, 1f);
			val2 = Vector4.Transform(val2, matrix4x4_3);
			float num = 1f / val2.W;
			float num2 = val2.X * num * float_0 + float_0;
			float num3 = val2.Y * num * float_1 + float_1;
			num3 = ViewportHeight - num3;
			vectors[i] = new Vector3(num2, num3, 0f);
		}
	}

	public Vector3 UnProject(Vector3 vector3)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		Matrix4x4 val = View * Matrix4x4.CreateTranslation(0f, 0f, 6378137f);
		_ = Projection * val * Matrix4x4.Identity;
		Matrix4x4 val2 = default(Matrix4x4);
		Matrix4x4.Invert(View, ref val2);
		Matrix4x4 val3 = default(Matrix4x4);
		Matrix4x4.Invert(Projection, ref val3);
		Matrix4x4 val4 = val3 * val2;
		vector3.Y = ViewportHeight - vector3.Y;
		Vector4 val5 = default(Vector4);
		((Vector4)(ref val5))..ctor(vector3.X / ViewportWidth * 2f - 1f, vector3.Y / ViewportHeight * 2f - 1f, vector3.Z * 2f - 1f, 1f);
		val5 = Vector4.Transform(val5, val4);
		val5.W = 1f / val5.W;
		return new Vector3(val5.X * val5.W, val5.Y * val5.W, val5.Z * val5.W);
	}

	public virtual void SetPosition(double lat, double lon)
	{
		if (double.IsNaN(lat))
		{
			lat = _latitude.Degrees;
		}
		if (double.IsNaN(lon))
		{
			lon = _longitude.Degrees;
		}
		m_Orientation = Quaternion4d.EulerToQuaternion(MathEngine.DegreesToRadians(lon), MathEngine.DegreesToRadians(lat), MathEngine.DegreesToRadians(0.0));
		Point3d point3d = Quaternion4d.QuaternionToEuler(m_Orientation);
		_latitude.Radians = point3d.Y;
		_longitude.Radians = point3d.X;
		_heading.Radians = point3d.Z;
	}

	public void ZoomStepped(float ticks)
	{
		int tickCount = Environment.TickCount;
		double num = 0.014999999664723873;
		if (num < 0.0)
		{
			num = 0.0;
		}
		if (num > 1.0)
		{
			num = 1.0;
		}
		double num2 = 50.0;
		double num3 = 250.0;
		double num4 = tickCount - lastStepZoomTickCount;
		if (num4 < num2)
		{
			num4 = num2;
		}
		double num5 = 1.0 - Math.Abs((num4 - num2) / num3);
		if (num5 < 0.0)
		{
			num5 = 0.0;
		}
		num5 *= 10.0;
		double x = Math.Pow(1.0 - num, num5 + 1.0);
		x = Math.Pow(x, Math.Abs(ticks));
		if (ticks > 0f)
		{
			TargetDistance *= x;
		}
		else
		{
			TargetDistance /= x;
		}
		lastStepZoomTickCount = tickCount;
	}

	protected void ComputeAltitude(double distance, Angle tilt)
	{
		int num = 10;
		float num2 = 127562740f;
		double num3 = Math.Sqrt(40680631590769.0 + distance * distance - 12756274.0 * distance * Math.Cos(Math.PI - tilt.Radians)) - 6378137.0;
		if (num3 >= 10.0)
		{
			if (num3 > (double)num2)
			{
				num3 = num2;
			}
		}
		else
		{
			num3 = num;
		}
		TargetAltitude = num3;
	}

	public virtual void PickingRayIntersection(int screenX, int screenY, out Angle latitude, out Angle longitude)
	{
		PickingRayIntersection(screenX, screenY, 0f, out latitude, out longitude);
	}

	public virtual void PickingRayIntersection(int screenX, int screenY, float knownAltitudeoffsetFromGlobe, out Angle latitude, out Angle longitude)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		float num = 6378137f + knownAltitudeoffsetFromGlobe;
		Vector3 val = UnProject(new Vector3
		{
			X = screenX,
			Y = screenY,
			Z = 0f
		});
		Vector3 val2 = UnProject(new Vector3
		{
			X = screenX,
			Y = screenY,
			Z = 1f
		});
		Point3d point3d = new Point3d(val.X, val.Y, val.Z);
		Point3d point3d2 = new Point3d(val2.X, val2.Y, val2.Z);
		double num2 = (point3d2.X - point3d.X) * (point3d2.X - point3d.X) + (point3d2.Y - point3d.Y) * (point3d2.Y - point3d.Y) + (point3d2.Z - point3d.Z) * (point3d2.Z - point3d.Z);
		double num3 = 2.0 * ((point3d2.X - point3d.X) * point3d.X + (point3d2.Y - point3d.Y) * point3d.Y + (point3d2.Z - point3d.Z) * point3d.Z);
		double num4 = point3d.X * point3d.X + point3d.Y * point3d.Y + point3d.Z * point3d.Z - (double)(num * num);
		if (num3 * num3 - 4.0 * num2 * num4 > 0.0)
		{
			double num5 = (-1.0 * num3 - Math.Sqrt(num3 * num3 - 4.0 * num2 * num4)) / (2.0 * num2);
			Point3d point3d3 = new Point3d(point3d.X + num5 * (point3d2.X - point3d.X), point3d.Y + num5 * (point3d2.Y - point3d.Y), point3d.Z + num5 * (point3d2.Z - point3d.Z));
			Point3d point3d4 = MathEngine.CartesianToSphericalD(point3d3.X, point3d3.Y, point3d3.Z);
			latitude = Angle.FromRadians(point3d4.Y);
			longitude = Angle.FromRadians(point3d4.Z);
		}
		else
		{
			latitude = Angle.NaN;
			longitude = Angle.NaN;
		}
	}

	public virtual void Pan(Angle lat, Angle lon)
	{
		if (Angle.IsNaN(lat))
		{
			lat = _latitude;
		}
		if (Angle.IsNaN(lon))
		{
			lon = _longitude;
		}
		lat += _latitude;
		lon += _longitude;
		m_Orientation = Quaternion4d.EulerToQuaternion(lon.Radians, lat.Radians, _heading.Radians);
		Point3d point3d = Quaternion4d.QuaternionToEuler(m_Orientation);
		if (!double.IsNaN(point3d.Y))
		{
			_latitude.Radians = point3d.Y;
			_longitude.Radians = point3d.X;
		}
		InvokePanEvent();
	}

	public void Zoom(float percent)
	{
		if (percent <= 0f)
		{
			double num = 1f - percent;
			TargetAltitude *= num;
		}
		else
		{
			double num2 = 1f + percent;
			TargetAltitude /= num2;
		}
	}

	public unsafe static Point[] SphericalToScreenOptimized((double Lon, double Lat)[] coords, int count, float radius, WorldCamera camera, Vector3 cameraRefCenter)
	{
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		Point[] array = new Point[count];
		if (count > 256)
		{
			Vector3[] array2 = ArrayPool<Vector3>.Shared.Rent(count);
			try
			{
				for (int i = 0; i < count; i++)
				{
					double num = coords[i].Lat * Math.PI / 180.0;
					double num2 = coords[i].Lon * Math.PI / 180.0;
					double num3 = (double)radius * Math.Cos(num);
					array2[i] = new Vector3((float)(num3 * Math.Cos(num2)), (float)(num3 * Math.Sin(num2)), (float)((double)radius * Math.Sin(num)));
				}
				Vector3[] array3 = ArrayPool<Vector3>.Shared.Rent(count);
				try
				{
					for (int j = 0; j < count; j++)
					{
						array3[j] = array2[j] - cameraRefCenter;
					}
					Vector3[] array4 = camera.Project(array3);
					try
					{
						for (int k = 0; k < count; k++)
						{
							array[k] = new Point((int)array4[k].X, (int)array4[k].Y);
						}
					}
					finally
					{
						ArrayPool<Vector3>.Shared.Return(array4, clearArray: true);
					}
				}
				finally
				{
					ArrayPool<Vector3>.Shared.Return(array3, clearArray: true);
				}
			}
			finally
			{
				ArrayPool<Vector3>.Shared.Return(array2, clearArray: true);
			}
		}
		else
		{
			int num4 = count;
			Span<Vector3> span = new Span<Vector3>(stackalloc Vector3[num4], num4);
			num4 = count;
			Span<Vector3> vectors = new Span<Vector3>(stackalloc Vector3[num4], num4);
			for (int l = 0; l < count; l++)
			{
				double num5 = coords[l].Lat * Math.PI / 180.0;
				double num6 = coords[l].Lon * Math.PI / 180.0;
				double num7 = (double)radius * Math.Cos(num5);
				span[l] = new Vector3((float)(num7 * Math.Cos(num6)), (float)(num7 * Math.Sin(num6)), (float)((double)radius * Math.Sin(num5)));
			}
			for (int m = 0; m < count; m++)
			{
				vectors[m] = span[m] - cameraRefCenter;
			}
			camera.Project_Span(vectors);
			for (int n = 0; n < count; n++)
			{
				Vector3 val = vectors[n];
				array[n] = new Point((int)val.X, (int)val.Y);
			}
		}
		return array;
	}

	static WorldCamera()
	{
		Class72.smethod_20();
		minimumAltitude = 500.0;
	}
}
