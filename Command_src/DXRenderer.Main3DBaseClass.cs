using System;
using DirectN;

namespace DXRenderer;

public class Main3DBaseClass
{
	private CVSceneView3D cvsceneView3D_0;

	protected float CurrentCameraAltitude;

	protected readonly float FieldOfView = (float)Math.PI / 4f;

	internal DXDevice DXDevice;

	public void Init(RenderState renderState = null)
	{
		IComObject<IDXGIAdapter> adapter;
		try
		{
			adapter = DXAdapterCache.ChoosePhysicalAdapter();
		}
		catch (Exception ex)
		{
			ex?.Data.Add("Error at 4148: ", ex.Message);
			throw ex;
		}
		DXAdapter adapter2;
		try
		{
			adapter2 = DXAdapterCache.FindOrCreateAdapterEntry(adapter);
		}
		catch (Exception ex2)
		{
			ex2?.Data.Add("Error at 4157: ", ex2.Message);
			throw ex2;
		}
		try
		{
			DXDevice = new DXDevice();
			if (renderState != null)
			{
				DXDevice.SetAdapter(adapter2, renderState);
			}
			else
			{
				DXDevice.SetAdapter(adapter2);
			}
		}
		catch (Exception ex3)
		{
			ex3?.Data.Add("Error at 4170: ", ex3.Message);
			throw ex3;
		}
		try
		{
			cvsceneView3D_0 = new CVSceneView3D(DXDevice);
		}
		catch (Exception ex4)
		{
			ex4?.Data.Add("Error at 4179: ", ex4.Message);
			throw ex4;
		}
	}

	public void AddVisibleUnit(float longitude, float latitude, float altitude, float pitch, float roll, float yaw, string assetString, int colour, float scaleFactor = 50f)
	{
		scaleFactor = CurrentCameraAltitude * FieldOfView * 0.0025f;
		cvsceneView3D_0.AddVisibleUnit(longitude, latitude, altitude, pitch, roll, yaw, assetString, colour, scaleFactor);
	}

	public void Render()
	{
		cvsceneView3D_0.Render();
	}

	static Main3DBaseClass()
	{
		Class72.smethod_20();
	}
}
