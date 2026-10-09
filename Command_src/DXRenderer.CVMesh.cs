using System.IO;
using System.Numerics;
using System.Runtime.InteropServices;
using DirectN;

namespace DXRenderer;

public class CVMesh
{
	public struct VS_MESH_CONSTANT_BUFFER
	{
		internal Vector4 MeshColour;
	}

	public struct VS_TRANSFORM_CONSTANT_BUFFER
	{
		internal Matrix4x4 WorldViewProj;

		internal float u;

		internal float v;

		internal float uWidth;

		internal float vWidth;

		internal uint Level;

		internal uint Row;

		internal int Layer;

		internal float Hint;

		internal Matrix4x4 World;

		internal Matrix4x4 View;

		internal Matrix4x4 Proj;
	}

	public class TMeshUV
	{
		public float u;

		public float v;

		static TMeshUV()
		{
			Class72.smethod_20();
		}
	}

	private DXDevice dxdevice_0;

	private Vector3[] vector3_0;

	private Vector3[] JkiyaUhCknI;

	private TMeshUV[] tmeshUV_0;

	private uint[] uint_0;

	private int[] int_0;

	private IComObject<ID3D11Buffer> icomObject_0;

	private IComObject<ID3D11Buffer> icomObject_1;

	private int[] int_1;

	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	private Texture texture_0;

	private uint uint_4;

	public const uint CV_MESH_STREAM_NORMAL = 1u;

	public const uint CV_MESH_STREAM_UV = 2u;

	public const uint CV_MESH_STREAM_PRELIT = 4u;

	public CVMesh(DXDevice device)
	{
		dxdevice_0 = device;
		uint_3 = 0u;
	}

	public void Render(Matrix4x4 transform)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		VS_TRANSFORM_CONSTANT_BUFFER buffer = new VS_TRANSFORM_CONSTANT_BUFFER
		{
			World = transform,
			View = dxdevice_0.ViewMatrix,
			Proj = dxdevice_0.ProjMatrix,
			WorldViewProj = transform * dxdevice_0.ViewMatrix * dxdevice_0.ProjMatrix
		};
		dxdevice_0.UpdateConstantBuffer(2147483649u, 0u, buffer);
		dxdevice_0.Context.Object.IASetVertexBuffers(0u, 1, new ID3D11Buffer[1] { icomObject_0.Object }, new uint[1] { uint_4 }, new uint[1]);
		dxdevice_0.Context.Object.IASetIndexBuffer(icomObject_1.Object, DXGI_FORMAT.DXGI_FORMAT_R32_UINT, 0u);
		dxdevice_0.Context.Object.IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
		if (texture_0 != null)
		{
			dxdevice_0.Context.Object.PSSetShaderResources(0u, 1, new ID3D11ShaderResourceView[1] { texture_0.view.Object });
		}
		dxdevice_0.ShaderManager.SetShader(dxdevice_0.ShaderManager.DefaultMeshShader);
		dxdevice_0.Context.Object.DrawIndexed(FaceCount() * 3, 0u, 0);
	}

	public void SetVertexCount(int count, uint flags)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		uint_3 = flags;
		uint_1 = (uint)count;
		JkiyaUhCknI = null;
		tmeshUV_0 = null;
		vector3_0 = null;
		uint_0 = null;
		if (count < 0)
		{
			return;
		}
		vector3_0 = (Vector3[])(object)new Vector3[count];
		for (int i = 0; i < count; i++)
		{
			vector3_0[i] = default(Vector3);
		}
		if ((flags & 1) != 0)
		{
			JkiyaUhCknI = (Vector3[])(object)new Vector3[count];
			for (int i = 0; i < count; i++)
			{
				JkiyaUhCknI[i] = default(Vector3);
			}
		}
		if ((flags & 2) != 0)
		{
			tmeshUV_0 = new TMeshUV[count];
			for (int i = 0; i < count; i++)
			{
				tmeshUV_0[i] = new TMeshUV();
			}
		}
		if ((flags & 4) != 0)
		{
			uint_0 = new uint[count];
		}
	}

	public void SetFaceCount(int count)
	{
		int_0 = null;
		uint_2 = (uint)count;
		if (count >= 0)
		{
			int_0 = new int[count * 3];
		}
	}

	public uint VertexCount()
	{
		return uint_1;
	}

	public Vector3[] VertexStream()
	{
		return vector3_0;
	}

	public Vector3[] NormalStream()
	{
		return JkiyaUhCknI;
	}

	public TMeshUV[] UVStream()
	{
		return tmeshUV_0;
	}

	public uint[] PrelightStream()
	{
		return uint_0;
	}

	public int[] Indices()
	{
		return int_0;
	}

	public uint FaceCount()
	{
		return uint_2;
	}

	public void MakeNormals(bool buildAsFlatFaces = false)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Unknown result type (might be due to invalid IL or missing references)
		if (NormalStream() == null || (uint_3 & 1) == 0)
		{
			return;
		}
		Vector3[] array = (Vector3[])(object)new Vector3[FaceCount()];
		for (uint num = 0u; num < FaceCount(); num++)
		{
			Vector3 val = VertexStream()[Indices()[num * 3]];
			Vector3 val2 = VertexStream()[Indices()[num * 3 + 1]];
			Vector3 val3 = VertexStream()[Indices()[num * 3 + 2]];
			Vector3 val4 = val - val2;
			val3 -= val2;
			Vector3 val5 = Vector3.Normalize(val4);
			val3 = Vector3.Normalize(val3);
			val2 = Vector3.Cross(val5, val3);
			val2 = Vector3.Normalize(val2);
			array[num] = val2;
		}
		if (!buildAsFlatFaces)
		{
			Vector3 val6 = default(Vector3);
			((Vector3)(ref val6))..ctor(0f, 0f, 0f);
			for (uint num = 0u; num < VertexCount(); num++)
			{
				NormalStream()[num] = val6;
			}
			for (uint num = 0u; num < FaceCount(); num++)
			{
				ref Vector3 reference = ref NormalStream()[Indices()[num * 3]];
				reference += array[num];
				ref Vector3 reference2 = ref NormalStream()[Indices()[num * 3 + 1]];
				reference2 += array[num];
				ref Vector3 reference3 = ref NormalStream()[Indices()[num * 3 + 2]];
				reference3 += array[num];
			}
			for (uint num = 0u; num < VertexCount(); num++)
			{
				Vector3 val7 = NormalStream()[num];
				val7 = Vector3.Normalize(val7);
				NormalStream()[num] = val7;
			}
			return;
		}
		Vector3[] array2 = (Vector3[])(object)new Vector3[FaceCount() * 3];
		TMeshUV[] array3 = new TMeshUV[FaceCount() * 3];
		uint[] array4 = new uint[FaceCount() * 3];
		int[] array5 = new int[FaceCount() * 3];
		int num2 = 0;
		for (uint num = 0u; num < FaceCount(); num++)
		{
			array2[num2] = vector3_0[int_0[num2]];
			array2[num2 + 1] = vector3_0[int_0[num2 + 1]];
			array2[num2 + 2] = vector3_0[int_0[num2 + 2]];
			array5[num2] = num2;
			array5[num2 + 1] = num2 + 1;
			array5[num2 + 2] = num2 + 2;
			if ((uint_3 & 2) != 0)
			{
				array3[num2] = tmeshUV_0[int_0[num2]];
				array3[num2 + 1] = tmeshUV_0[int_0[num2 + 1]];
				array3[num2 + 2] = tmeshUV_0[int_0[num2 + 2]];
			}
			if ((uint_3 & 4) != 0)
			{
				array4[num2] = uint_0[int_0[num2]];
				array4[num2 + 1] = uint_0[int_0[num2 + 1]];
				array4[num2 + 2] = uint_0[int_0[num2 + 2]];
			}
			num2 += 3;
		}
		SetVertexCount((int)(FaceCount() * 3), uint_3);
		array2.CopyTo(vector3_0, 0);
		array5.CopyTo(int_0, 0);
		if ((uint_3 & 2) != 0)
		{
			array3.CopyTo(tmeshUV_0, 0);
		}
		int num3;
		if ((uint_3 & 4) == 0)
		{
			num3 = 0;
		}
		else
		{
			array4.CopyTo(uint_0, 0);
			num3 = 0;
		}
		num2 = num3;
		for (uint num = 0u; num < FaceCount(); num++)
		{
			JkiyaUhCknI[num2++] = array[num];
			JkiyaUhCknI[num2++] = array[num];
			JkiyaUhCknI[num2++] = array[num];
		}
	}

	public void Rebuild()
	{
		uint num = 12u;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		if ((uint_3 & 1) != 0)
		{
			num += 12;
			flag = true;
		}
		if ((uint_3 & 2) != 0)
		{
			num += 8;
			flag2 = true;
		}
		if ((uint_3 & 4) != 0)
		{
			num += 4;
			flag3 = true;
		}
		uint_4 = num;
		MemoryStream memoryStream = new MemoryStream((int)(uint_4 * VertexCount()));
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		int_1 = new int[FaceCount() * 3];
		for (int i = 0; i < VertexCount(); i++)
		{
			binaryWriter.Write(vector3_0[i].X);
			binaryWriter.Write(vector3_0[i].Y);
			binaryWriter.Write(vector3_0[i].Z);
			if (flag)
			{
				binaryWriter.Write(JkiyaUhCknI[i].X);
				binaryWriter.Write(JkiyaUhCknI[i].Y);
				binaryWriter.Write(JkiyaUhCknI[i].Z);
			}
			if (flag3)
			{
				binaryWriter.Write(uint_0[i]);
			}
			if (flag2)
			{
				binaryWriter.Write(tmeshUV_0[i].u);
				binaryWriter.Write(tmeshUV_0[i].v);
			}
		}
		for (int i = 0; i < FaceCount() * 3; i++)
		{
			int_1[i] = int_0[i];
		}
		byte[] array = memoryStream.ToArray();
		D3D11_BUFFER_DESC desc = new D3D11_BUFFER_DESC
		{
			ByteWidth = (uint)array.SizeOf(),
			Usage = D3D11_USAGE.D3D11_USAGE_IMMUTABLE,
			BindFlags = 1u,
			CPUAccessFlags = 0u,
			MiscFlags = 0u,
			StructureByteStride = 0u
		};
		GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
		D3D11_SUBRESOURCE_DATA value = new D3D11_SUBRESOURCE_DATA
		{
			pSysMem = gCHandle.AddrOfPinnedObject(),
			SysMemPitch = 0u,
			SysMemSlicePitch = 0u
		};
		icomObject_0 = dxdevice_0.Device.CreateBuffer(desc, value);
		gCHandle.Free();
		D3D11_BUFFER_DESC desc2 = new D3D11_BUFFER_DESC
		{
			ByteWidth = (uint)int_1.SizeOf(),
			Usage = D3D11_USAGE.D3D11_USAGE_IMMUTABLE,
			BindFlags = 2u,
			CPUAccessFlags = 0u,
			MiscFlags = 0u,
			StructureByteStride = 0u
		};
		gCHandle = GCHandle.Alloc(int_1, GCHandleType.Pinned);
		D3D11_SUBRESOURCE_DATA value2 = new D3D11_SUBRESOURCE_DATA
		{
			pSysMem = gCHandle.AddrOfPinnedObject(),
			SysMemPitch = 0u,
			SysMemSlicePitch = 0u
		};
		icomObject_1 = dxdevice_0.Device.CreateBuffer(desc2, value2);
		gCHandle.Free();
	}

	public void SetTexture(Texture tex, int index = 0)
	{
		texture_0 = tex;
	}

	static CVMesh()
	{
		Class72.smethod_20();
	}
}
