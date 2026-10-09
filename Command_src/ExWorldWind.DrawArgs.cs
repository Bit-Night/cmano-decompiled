using System.Drawing;

namespace ExWorldWind;

public class DrawArgs
{
	public static DrawArgs Instance;

	public WorldCamera WorldCamera = new WorldCamera();

	public static Point LastMousePosition;

	public static bool IsLeftMouseButtonDown;

	public static bool IsRightMouseButtonDown;

	public int XOffset;

	internal void Update(float latitude, float longitude, float altitude, float viewportWidth, float viewportHeight, float fieldOfView)
	{
		WorldCamera.Update(latitude, longitude, altitude, viewportWidth, viewportHeight, fieldOfView);
	}

	static DrawArgs()
	{
		Class72.smethod_20();
		Instance = new DrawArgs();
		IsLeftMouseButtonDown = false;
		IsRightMouseButtonDown = false;
	}
}
