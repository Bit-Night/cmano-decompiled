using System;
using System.Collections.Generic;
using System.Numerics;
using DirectN;

namespace DXRenderer;

public class CVSceneView3D
{
	public class CVSceneObject
	{
		public CVFrame mFrame;

		public Matrix4x4 mWorld;

		public int mColour;

		public CVSceneObject(CVFrame frame, Matrix4x4 trx, int colour)
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			mFrame = frame;
			mWorld = trx;
			mColour = colour;
		}

		static CVSceneObject()
		{
			Class72.smethod_20();
		}
	}

	private DXDevice dxdevice_0;

	private List<CVSceneObject> list_0 = new List<CVSceneObject>();

	private Dictionary<string, CVFrame> dictionary_0 = new Dictionary<string, CVFrame>();

	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	public CVSceneView3D(DXDevice device)
	{
		dxdevice_0 = device;
		method_0();
	}

	public void AddVisibleUnit(float longitude, float latitude, float altitude, float pitch, float roll, float yaw, string assetString, int colour, float scaleFactor = 50f)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		Matrix4x4 identity = Matrix4x4.Identity;
		float num = DXMiscUtils.LongitudeToTheta(longitude);
		float num2 = DXMiscUtils.LatitudeToPhi(latitude);
		float num3 = 6378137f + altitude;
		float num4 = (float)((double)num3 * Math.Sin(num2) * Math.Cos(num));
		float num5 = (float)((double)num3 * Math.Sin(num2) * Math.Sin(num));
		float num6 = (float)((double)num3 * Math.Cos(num2));
		identity = Matrix4x4.Identity;
		identity.M11 = scaleFactor;
		identity.M22 = scaleFactor;
		identity.M33 = scaleFactor;
		Matrix4x4 val = Matrix4x4.CreateTranslation(num4, num6, num5);
		Vector3 val2 = default(Vector3);
		((Vector3)(ref val2))..ctor(num4, num6, num5);
		val2 = Vector3.Normalize(val2);
		val.M21 = val2.X;
		val.M22 = val2.Y;
		val.M23 = val2.Z;
		Vector3 val3 = default(Vector3);
		((Vector3)(ref val3))..ctor(0f, 1f, 0f);
		Vector3 val4 = Vector3.Cross(val2, val3);
		Vector3 val5 = Vector3.Cross(val4, val2);
		val.M11 = val4.X;
		val.M12 = val4.Y;
		val.M13 = val4.Z;
		val.M31 = val5.X;
		val.M32 = val5.Y;
		val.M33 = val5.Z;
		Matrix4x4 val6 = Matrix4x4.CreateRotationY(yaw * (float)Math.PI / 180f);
		Matrix4x4 val7 = Matrix4x4.CreateRotationZ((0f - roll) * (float)Math.PI / 180f);
		Matrix4x4 trx = Matrix4x4.CreateRotationX((0f - pitch) * (float)Math.PI / 180f) * val7 * val6 * identity * val;
		AddFrameForRender(LoadFromObjFile("Meshes/Meshes/" + assetString), trx, colour);
	}

	public void Render()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		CVMesh.VS_MESH_CONSTANT_BUFFER buffer = default(CVMesh.VS_MESH_CONSTANT_BUFFER);
		SetSolidRasterizer();
		foreach (CVSceneObject item in list_0)
		{
			buffer.MeshColour = DXMiscUtils.MakeVectorColour(item.mColour);
			dxdevice_0.UpdateConstantBuffer(2147487744u, 1u, buffer);
			item.mFrame.mLocal = item.mWorld;
			item.mFrame.Render();
		}
		SetWireframeRasterizer();
		foreach (CVSceneObject item2 in list_0)
		{
			buffer.MeshColour = DXMiscUtils.MakeVectorColour(item2.mColour);
			ref Vector4 meshColour = ref buffer.MeshColour;
			meshColour *= 1.3f;
			dxdevice_0.UpdateConstantBuffer(2147487744u, 1u, buffer);
			item2.mFrame.mLocal = item2.mWorld;
			item2.mFrame.Render();
		}
		SetSolidRasterizer();
		list_0.Clear();
	}

	public void AddFrameForRender(CVFrame frame, Matrix4x4 trx, int colour)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		if (frame != null)
		{
			list_0.Add(new CVSceneObject(frame, trx, colour));
		}
	}

	public CVFrame LoadFromObjFile(string filename)
	{
		CVFrame value = null;
		if (!dictionary_0.TryGetValue(filename, out value))
		{
			CVObjFileLoader cVObjFileLoader = new CVObjFileLoader(filename, dxdevice_0);
			if (cVObjFileLoader.GetRoot() == null)
			{
				dictionary_0.Add(filename, null);
				return null;
			}
			value = cVObjFileLoader.GetRoot();
			dictionary_0.Add(filename, cVObjFileLoader.GetRoot());
		}
		return value;
	}

	public void SetSolidRasterizer()
	{
		dxdevice_0.SetRasterizerState(uint_0);
		dxdevice_0.SetDepthStencilState(uint_2);
	}

	public void SetWireframeRasterizer()
	{
		dxdevice_0.SetRasterizerState(uint_1);
		dxdevice_0.SetDepthStencilState(uint_3);
	}

	private bool method_0()
	{
		D3D11_RASTERIZER_DESC desc = new D3D11_RASTERIZER_DESC
		{
			FillMode = D3D11_FILL_MODE.D3D11_FILL_SOLID,
			CullMode = D3D11_CULL_MODE.D3D11_CULL_BACK
		};
		uint_0 = dxdevice_0.CreateRasterizerState(desc);
		desc.FillMode = D3D11_FILL_MODE.D3D11_FILL_WIREFRAME;
		uint_1 = dxdevice_0.CreateRasterizerState(desc);
		D3D11_DEPTH_STENCIL_DESC desc2 = new D3D11_DEPTH_STENCIL_DESC
		{
			DepthEnable = true,
			DepthWriteMask = D3D11_DEPTH_WRITE_MASK.D3D11_DEPTH_WRITE_MASK_ALL,
			DepthFunc = D3D11_COMPARISON_FUNC.D3D11_COMPARISON_LESS,
			StencilEnable = false
		};
		uint_2 = dxdevice_0.CreateDepthStencilState(desc2);
		desc2.DepthFunc = D3D11_COMPARISON_FUNC.D3D11_COMPARISON_LESS_EQUAL;
		uint_3 = dxdevice_0.CreateDepthStencilState(desc2);
		return true;
	}

	static CVSceneView3D()
	{
		Class72.smethod_20();
	}
}
