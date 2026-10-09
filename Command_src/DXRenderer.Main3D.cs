using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CSMaterial;
using DirectN;
using Efundies;

namespace DXRenderer;

public class Main3D : Main3DBaseClass
{
	private enum Enum11
	{

	}

	public static Main3D Instance;

	private uint OrvyaqYbwfE;

	private uint uint_0;

	private uint lnjyaoUnxRV;

	private uint uint_1;

	internal const float PI = (float)Math.PI;

	private Vector4 vector4_0 = new Vector4(0f, 0f, 0f, 1f);

	private Vector4 vector4_1 = new Vector4(1f, 0f, 0f, 1f);

	private Vector4 vector4_2 = new Vector4(0f, 0f, 1f, 1f);

	private static readonly Color color_0;

	public static readonly UnsafeColor TRANSPARENT_UNSAFE;

	public static readonly Color SHADOW;

	public const float EARTH_MEAN_RADIUS = 6378137f;

	internal Interface0 RenderEventHandler;

	private readonly string string_0;

	private readonly int int_0;

	private readonly int int_1;

	private readonly int int_2;

	private readonly int BcOyafhxed2;

	internal int ScreenWidth;

	public int ScreenHeight;

	public bool Ready;

	public bool Drawing;

	public string AdapterDescription;

	private ID3DUserDefinedAnnotation id3DUserDefinedAnnotation_0;

	private IComObject<ID2D1Factory1> icomObject_0;

	private IComObject<ID3D11InputLayout> icomObject_1;

	public IComObject<ID3D11InputLayout> MeshInputLayout;

	private int int_3 = -1;

	private uint uint_2;

	private IComObject<ID2D1RenderTarget> icomObject_2;

	private IComObject<IDWriteFactory> icomObject_3;

	private DrawParameters drawParameters_0;

	private DrawParameters drawParameters_1;

	internal uint TesselationLevel = 8u;

	private Matrix4x4 matrix4x4_0;

	public bool Initialized;

	public int Frame;

	public IComObject<ID3D11Device> Device => DXDevice.Device;

	public IComObject<ID3D11DeviceContext> Context => DXDevice.Context;

	public ShaderManager ShaderManager => DXDevice.ShaderManager;

	public void SetSolidRasterizer()
	{
		DXDevice.SetRasterizerState(OrvyaqYbwfE);
		DXDevice.SetDepthStencilState(lnjyaoUnxRV);
	}

	public void SetWireframeRasterizer()
	{
		DXDevice.SetRasterizerState(uint_0);
		DXDevice.SetDepthStencilState(uint_1);
	}

	public Main3D(string topLevelWriteableRoot, Control control, int clientRectangleTopMargin, int clientRectangleBottomMargin)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		Instance = this;
		string_0 = topLevelWriteableRoot;
		int_0 = 0;
		int_1 = 0;
		BcOyafhxed2 = int_0;
		ScreenWidth = control.ClientRectangle.Width;
		ScreenHeight = control.ClientRectangle.Height - int_0 - int_1;
		Init();
		Ready = method_0(control);
		drawParameters_0.Projection = Projection.Globe;
		drawParameters_0.Topology = D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST;
		drawParameters_0.Disposable = false;
		drawParameters_1 = drawParameters_0;
		drawParameters_1.ShaderResourceView = method_7(string_0 + "/WW/Data/Earth/BmngBathy/world.topo.bathy.200407.jpg", bool_0: true);
		drawParameters_1.Layer = Layer.BaseEarth;
		Initialized = true;
	}

	private bool method_0(Control control_0)
	{
		if (Device == null)
		{
			return false;
		}
		id3DUserDefinedAnnotation_0 = (ID3DUserDefinedAnnotation)Context.Object;
		DXDevice.CreateSwapChainAndBackBuffers(control_0);
		D3D11_VIEWPORT d3D11_VIEWPORT = new D3D11_VIEWPORT
		{
			Width = ScreenWidth,
			Height = ScreenHeight,
			MinDepth = 0f,
			MaxDepth = 1f,
			TopLeftX = int_2,
			TopLeftY = BcOyafhxed2
		};
		Context.Object.RSSetViewports(1, new D3D11_VIEWPORT[1] { d3D11_VIEWPORT });
		if (method_1())
		{
			if (method_3())
			{
				if (jjByapMyUqP())
				{
					icomObject_3 = DWriteFunctions.DWriteCreateFactory();
					if (icomObject_3 != null)
					{
						icomObject_0 = D2D1Functions.D2D1CreateFactory1(D2D1_FACTORY_TYPE.D2D1_FACTORY_TYPE_MULTI_THREADED, default(D2D1_FACTORY_OPTIONS));
						if (icomObject_0 == null)
						{
							return false;
						}
						D2D1_RENDER_TARGET_PROPERTIES properties = new D2D1_RENDER_TARGET_PROPERTIES
						{
							pixelFormat = new D2D1_PIXEL_FORMAT
							{
								alphaMode = D2D1_ALPHA_MODE.D2D1_ALPHA_MODE_PREMULTIPLIED
							}
						};
						IComObject<IDXGISurface> buffer = DXDevice.SwapChain.GetBuffer<IDXGISurface>(0u);
						if (buffer != null)
						{
							icomObject_2 = icomObject_0.CreateDxgiSurfaceRenderTarget(buffer, properties);
							buffer.Dispose();
							if (icomObject_2 != null)
							{
								return true;
							}
							return false;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	private bool method_1()
	{
		D3D11_RASTERIZER_DESC desc = new D3D11_RASTERIZER_DESC
		{
			FillMode = D3D11_FILL_MODE.D3D11_FILL_SOLID,
			CullMode = D3D11_CULL_MODE.D3D11_CULL_BACK
		};
		OrvyaqYbwfE = DXDevice.CreateRasterizerState(desc);
		desc.FillMode = D3D11_FILL_MODE.D3D11_FILL_WIREFRAME;
		uint_0 = DXDevice.CreateRasterizerState(desc);
		D3D11_DEPTH_STENCIL_DESC desc2 = new D3D11_DEPTH_STENCIL_DESC
		{
			DepthEnable = true,
			DepthWriteMask = D3D11_DEPTH_WRITE_MASK.D3D11_DEPTH_WRITE_MASK_ALL,
			DepthFunc = D3D11_COMPARISON_FUNC.D3D11_COMPARISON_LESS,
			StencilEnable = false
		};
		lnjyaoUnxRV = DXDevice.CreateDepthStencilState(desc2);
		desc2.DepthFunc = D3D11_COMPARISON_FUNC.D3D11_COMPARISON_LESS_EQUAL;
		uint_1 = DXDevice.CreateDepthStencilState(desc2);
		return true;
	}

	private Mesh method_2()
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		List<Vertex> list = new List<Vertex>();
		List<uint> list2 = new List<uint>();
		Vector3 val = default(Vector3);
		foreach (string item2 in File.ReadLines(string_0 + "/Models/FixedWing.F-16.obj"))
		{
			if (!item2.IsEmpty())
			{
				switch (item2[0])
				{
				case 'v':
				{
					string[] array2 = item2.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
					((Vector3)(ref val))..ctor(Convert.ToSingle(array2[1]), Convert.ToSingle(array2[2]), Convert.ToSingle(array2[3]));
					val *= 1000000f;
					Vertex item = new Vertex(val, vector4_1, default(Vector2));
					list.Add(item);
					break;
				}
				case 'f':
				{
					string[] array = item2.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
					list2.Add(Convert.ToUInt32(array[1]) - 1);
					list2.Add(Convert.ToUInt32(array[2]) - 1);
					list2.Add(Convert.ToUInt32(array[3]) - 1);
					break;
				}
				}
			}
		}
		return new Mesh
		{
			vertices = list.ToArray(),
			indices = list2.ToArray()
		};
	}

	private bool method_3()
	{
		return method_4(method_2(), ref drawParameters_0);
	}

	private bool jjByapMyUqP()
	{
		int_3 = ShaderManager.LoadShader("shaders3D.hlsl", "vs_main", "ps_main");
		D3D11_SAMPLER_DESC desc = new D3D11_SAMPLER_DESC
		{
			Filter = D3D11_FILTER.D3D11_FILTER_ANISOTROPIC,
			MaxAnisotropy = 4u,
			AddressU = D3D11_TEXTURE_ADDRESS_MODE.D3D11_TEXTURE_ADDRESS_CLAMP,
			AddressV = D3D11_TEXTURE_ADDRESS_MODE.D3D11_TEXTURE_ADDRESS_CLAMP,
			AddressW = D3D11_TEXTURE_ADDRESS_MODE.D3D11_TEXTURE_ADDRESS_CLAMP
		};
		IComObject<ID3D11SamplerState> comObject = Device.CreateSamplerState(desc);
		Context.Object.PSSetSamplers(0u, 1, new ID3D11SamplerState[1] { comObject.Object });
		return true;
	}

	private bool method_4(Mesh mesh_0, ref DrawParameters drawParameters_2)
	{
		int num = 2;
		if (drawParameters_2.Topology == D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST)
		{
			num = 3;
		}
		int result;
		if (mesh_0.vertices == null)
		{
			result = 0;
		}
		else if (mesh_0.vertices.Length >= num)
		{
			if (mesh_0.indices == null)
			{
				result = 0;
			}
			else
			{
				if (mesh_0.indices.Length >= num)
				{
					D3D11_BUFFER_DESC desc = new D3D11_BUFFER_DESC
					{
						ByteWidth = (uint)mesh_0.vertices.SizeOf(),
						Usage = D3D11_USAGE.D3D11_USAGE_IMMUTABLE,
						BindFlags = 1u,
						CPUAccessFlags = 0u,
						MiscFlags = 0u,
						StructureByteStride = 0u
					};
					GCHandle gCHandle = GCHandle.Alloc(mesh_0.vertices, GCHandleType.Pinned);
					D3D11_SUBRESOURCE_DATA value = new D3D11_SUBRESOURCE_DATA
					{
						pSysMem = gCHandle.AddrOfPinnedObject(),
						SysMemPitch = 0u,
						SysMemSlicePitch = 0u
					};
					drawParameters_2.VertexBuffer = Device.CreateBuffer(desc, value);
					gCHandle.Free();
					if (drawParameters_2.VertexBuffer != null)
					{
						D3D11_BUFFER_DESC desc2 = new D3D11_BUFFER_DESC
						{
							ByteWidth = (uint)mesh_0.indices.SizeOf(),
							Usage = D3D11_USAGE.D3D11_USAGE_IMMUTABLE,
							BindFlags = 2u,
							CPUAccessFlags = 0u,
							MiscFlags = 0u,
							StructureByteStride = 0u
						};
						gCHandle = GCHandle.Alloc(mesh_0.indices, GCHandleType.Pinned);
						D3D11_SUBRESOURCE_DATA value2 = new D3D11_SUBRESOURCE_DATA
						{
							pSysMem = gCHandle.AddrOfPinnedObject(),
							SysMemPitch = 0u,
							SysMemSlicePitch = 0u
						};
						drawParameters_2.IndexBuffer = Device.CreateBuffer(desc2, value2);
						gCHandle.Free();
						drawParameters_2.NumberIndices = (uint)mesh_0.indices.Length;
						if (drawParameters_2.IndexBuffer != null)
						{
							return true;
						}
						return false;
					}
					return false;
				}
				result = 0;
			}
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	private Mesh method_5()
	{
		return method_6(0f);
	}

	private Mesh method_6(float float_0)
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		uint num = (uint)Math.Pow(2.0, TesselationLevel);
		if (num < 2)
		{
			return default(Mesh);
		}
		uint num2 = num * 2;
		uint num3 = 2 + (num - 1) * (num2 + 1);
		float num4 = 6378137f + float_0;
		float num5 = (float)Math.PI / (float)num;
		float num6 = (float)Math.PI * 2f / (float)num2;
		Vertex vertex = new Vertex(new Vector3(0f, num4, 0f), vector4_2, new Vector2(0.5f, 0f));
		Vertex vertex2 = new Vertex(new Vector3(0f, 0f - num4, 0f), vector4_1, new Vector2(0.5f, 1f));
		Vertex[] array = new Vertex[num3];
		uint num7 = 0u;
		num7 = 1u;
		array[0] = vertex;
		Vector3 p = default(Vector3);
		for (uint num8 = 1u; num8 < num; num8++)
		{
			float num9 = (float)num8 * num5;
			for (uint num10 = 0u; num10 <= num2; num10++)
			{
				float num11 = (float)num10 * num6;
				((Vector3)(ref p))..ctor(num4 * (float)(Math.Sin(num9) * Math.Cos(num11 + (float)Math.PI / 2f)), num4 * (float)Math.Cos(num9), num4 * (float)(Math.Sin(num9) * Math.Sin(num11 + (float)Math.PI / 2f)));
				Vertex vertex3 = new Vertex(p, vector4_0, new Vector2(num11 / ((float)Math.PI * 2f), num9 / (float)Math.PI));
				array[num7++] = vertex3;
			}
		}
		array[num7++] = vertex2;
		uint[] array2 = new uint[((num - 2) * num2 * 2 + num2 * 2) * 3];
		uint num12 = 0u;
		for (uint num13 = 1u; num13 <= num2; num13++)
		{
			array2[num12++] = 0u;
			array2[num12++] = num13 + 1;
			array2[num12++] = num13;
		}
		uint num14 = 1u;
		uint num15 = num2 + 1;
		for (uint num16 = 0u; num16 < num - 2; num16++)
		{
			for (uint num17 = 0u; num17 < num2; num17++)
			{
				array2[num12++] = num14 + num16 * num15 + num17;
				array2[num12++] = num14 + num16 * num15 + num17 + 1;
				array2[num12++] = num14 + (num16 + 1) * num15 + num17;
				array2[num12++] = num14 + (num16 + 1) * num15 + num17;
				array2[num12++] = num14 + num16 * num15 + num17 + 1;
				array2[num12++] = num14 + (num16 + 1) * num15 + num17 + 1;
			}
		}
		uint num18 = num7 - 1;
		num14 = num18 - num15;
		for (uint num19 = 0u; num19 < num2; num19++)
		{
			array2[num12++] = num18;
			array2[num12++] = num14 + num19;
			array2[num12++] = num14 + num19 + 1;
		}
		return new Mesh
		{
			vertices = array,
			indices = array2
		};
	}

	private IComObject<ID3D11ShaderResourceView> method_7(string string_1, bool bool_0)
	{
		return method_8(string_1, bool_0, bool_1: false);
	}

	private IComObject<ID3D11ShaderResourceView> method_8(string string_1, bool bool_0, bool bool_1)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		if (!DXDevice.TextureCache.ShaderResourceViews.ContainsKey(string_1))
		{
			if (File.Exists(string_1))
			{
				try
				{
					Bitmap bitmap_ = new Bitmap(string_1);
					return method_9(string_1, bitmap_, bool_0, bool_1);
				}
				catch
				{
					return null;
				}
			}
			return null;
		}
		return DXDevice.TextureCache.ShaderResourceViews[string_1];
	}

	private IComObject<ID3D11ShaderResourceView> method_9(string string_1, Bitmap bitmap_0, bool bool_0, bool bool_1)
	{
		if (!DXDevice.TextureCache.ShaderResourceViews.ContainsKey(string_1))
		{
			int height = ((Image)bitmap_0).Height;
			int width = ((Image)bitmap_0).Width;
			uint[] array = new uint[height * width];
			LockBitmap lockBitmap = new LockBitmap(bitmap_0);
			lockBitmap.LockBits();
			int num = 0;
			int depth = lockBitmap.Depth;
			int width2 = lockBitmap.Width;
			byte[] pixels = lockBitmap.Pixels;
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					UnsafeColor unsafeColor = lockBitmap.GetPixel_UnsafeColor(j, i, depth, width2, pixels);
					if (bool_1 && unsafeColor.Equals(TRANSPARENT_UNSAFE))
					{
						unsafeColor = new UnsafeColor(SHADOW);
					}
					array[num++] = (uint)((unsafeColor.A << 24) | (unsafeColor.R << 16) | (unsafeColor.G << 8) | unsafeColor.B);
				}
			}
			lockBitmap.UnlockBits();
			D3D11_TEXTURE2D_DESC desc = new D3D11_TEXTURE2D_DESC
			{
				Width = (uint)width,
				Height = (uint)height,
				MipLevels = 1u,
				ArraySize = 1u,
				Format = DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM,
				Usage = D3D11_USAGE.D3D11_USAGE_IMMUTABLE,
				BindFlags = 8u
			};
			desc.SampleDesc.Count = 1u;
			GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
			D3D11_SUBRESOURCE_DATA initialData = new D3D11_SUBRESOURCE_DATA
			{
				pSysMem = gCHandle.AddrOfPinnedObject(),
				SysMemPitch = (uint)(width * 4)
			};
			if (bool_0)
			{
				IComObject<ID3D11Texture2D> resource = Device.CreateTexture2D<ID3D11Texture2D>(desc, initialData);
				gCHandle.Free();
				DXDevice.TextureCache.ShaderResourceViews.Add(string_1, Device.CreateShaderResourceView(resource));
				return DXDevice.TextureCache.ShaderResourceViews[string_1];
			}
			return null;
		}
		return DXDevice.TextureCache.ShaderResourceViews[string_1];
	}

	public void SetProjection(float longitude, float latitude, float altitude)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		latitude = Math.Min(89.9f, latitude);
		latitude = Math.Max(-89.9f, latitude);
		matrix4x4_0 = method_10(longitude, latitude, altitude);
	}

	private Matrix4x4 method_10(float float_0, float float_1, float float_2)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		float num = 6378137f;
		float num2 = num + float_2;
		Math.Sqrt((double)(num2 * num2) - 40680631590769.0);
		CurrentCameraAltitude = float_2;
		Matrix4x4 identity = Matrix4x4.Identity;
		float num3 = method_12(float_0);
		float num4 = method_11(float_1);
		float num5 = (float)ScreenWidth / (float)ScreenHeight;
		float num6 = float_2 * 0.01f;
		Matrix4x4 val = Matrix4x4.CreatePerspectiveFieldOfView(FieldOfView, num5, num6, num2);
		val.M33 *= -1f;
		val.M34 *= -1f;
		float num7 = (float)((double)num2 * Math.Sin(num4) * Math.Cos(num3));
		float num8 = (float)((double)num2 * Math.Sin(num4) * Math.Sin(num3));
		float num9 = (float)((double)num2 * Math.Cos(num4));
		Vector3 val2 = new Vector3(num7, num9, num8);
		Vector3 zero = Vector3.Zero;
		Vector3 val3 = default(Vector3);
		((Vector3)(ref val3))..ctor(0f, 1f, 0f);
		Matrix4x4 val4 = Matrix4x4.CreateLookAt(val2, zero, val3);
		val4.M11 *= -1f;
		val4.M13 *= -1f;
		val4.M21 *= -1f;
		val4.M23 *= -1f;
		val4.M31 *= -1f;
		val4.M33 *= -1f;
		val4.M41 *= -1f;
		val4.M43 *= -1f;
		DXDevice.ViewMatrix = val4;
		DXDevice.ProjMatrix = val;
		return identity * val4 * val;
	}

	private float method_11(float float_0)
	{
		float_0 += 90f;
		float_0.Clamp(2.938736E-39f, 180f);
		return (1f - float_0 / 180f) * (float)Math.PI;
	}

	private float method_12(float float_0)
	{
		float_0 += 180f;
		float_0.Clamp(2.938736E-39f, 180f);
		return (0.5f + float_0 / 360f * 2f) * (float)Math.PI;
	}

	public void BeginDrawing()
	{
		id3DUserDefinedAnnotation_0.BeginEvent("BeginDrawing");
		RenderEventHandler?.Handle(RenderEvent.BeginDrawing);
		Context.Object.OMSetRenderTargets(1, new ID3D11RenderTargetView[1] { DXDevice.RenderTargetView.Object }, DXDevice.DepthStencilView.Object);
		D3D11_VIEWPORT d3D11_VIEWPORT = new D3D11_VIEWPORT
		{
			Width = ScreenWidth,
			Height = ScreenHeight,
			MinDepth = 0f,
			MaxDepth = 1f,
			TopLeftX = int_2,
			TopLeftY = BcOyafhxed2
		};
		Context.Object.RSSetViewports(1, new D3D11_VIEWPORT[1] { d3D11_VIEWPORT });
		float[] array = new float[4];
		((Vector4)(ref vector4_0)).CopyTo(array);
		ID3D11RenderTargetView pRenderTargetView = DXDevice.RenderTargetView.Object;
		Context.Object.ClearRenderTargetView(pRenderTargetView, array);
		Context.Object.ClearDepthStencilView(DXDevice.DepthStencilView.Object, 3u, 1f, 0);
		SetSolidRasterizer();
		Context.Object.IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
		icomObject_2.BeginDraw();
		id3DUserDefinedAnnotation_0.BeginEvent("DrawBackground");
		method_13(drawParameters_1);
		id3DUserDefinedAnnotation_0.EndEvent();
		Render();
		Drawing = true;
		RenderEventHandler?.Handle(RenderEvent.DrawingEnabled);
	}

	public void FinishDrawing()
	{
		RenderEventHandler?.Handle(RenderEvent.Present);
		Drawing = false;
		id3DUserDefinedAnnotation_0.BeginEvent("Draw2DEnd");
		icomObject_2.EndDraw();
		id3DUserDefinedAnnotation_0.EndEvent();
		_ = DXDevice.SwapChain.Object.Present(0u, 0u).IsOk;
		Context.Object.OMSetRenderTargets(1, new ID3D11RenderTargetView[1] { DXDevice.RenderTargetView.Object }, DXDevice.DepthStencilView.Object);
		Frame++;
		RenderEventHandler?.Handle(RenderEvent.FinishedDrawing);
		id3DUserDefinedAnnotation_0.EndEvent();
	}

	private void method_13(DrawParameters drawParameters_2)
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		Context.Object.IASetVertexBuffers(0u, 1, new ID3D11Buffer[1] { drawParameters_2.VertexBuffer.Object }, new uint[1] { 36u }, new uint[1] { 0u });
		if (drawParameters_2.Disposable)
		{
			drawParameters_2.VertexBuffer.Dispose();
		}
		Context.Object.IASetIndexBuffer(drawParameters_2.IndexBuffer.Object, DXGI_FORMAT.DXGI_FORMAT_R32_UINT, 0u);
		if (drawParameters_2.Disposable)
		{
			drawParameters_2.IndexBuffer.Dispose();
		}
		CVMesh.VS_TRANSFORM_CONSTANT_BUFFER buffer = default(CVMesh.VS_TRANSFORM_CONSTANT_BUFFER);
		if (drawParameters_2.Projection == Projection.Globe)
		{
			buffer.WorldViewProj = matrix4x4_0;
		}
		buffer.u = drawParameters_2.u;
		buffer.v = drawParameters_2.v;
		buffer.uWidth = drawParameters_2.uWidth;
		buffer.vWidth = drawParameters_2.vWidth;
		buffer.Row = drawParameters_2.Row;
		buffer.Level = drawParameters_2.Level;
		buffer.Layer = (int)drawParameters_2.Layer;
		buffer.Hint = drawParameters_2.Hint;
		DXDevice.UpdateConstantBuffer(2147483649u, 0u, buffer);
		Context.Object.IASetPrimitiveTopology(drawParameters_2.Topology);
		if (drawParameters_2.ShaderResourceView != null)
		{
			Context.Object.PSSetShaderResources(0u, 1, new ID3D11ShaderResourceView[1] { drawParameters_2.ShaderResourceView.Object });
		}
		ShaderManager.SetShader(int_3);
		Context.Object.DrawIndexed(drawParameters_2.NumberIndices, 0u, 0);
		Context.Object.OMSetDepthStencilState(null, 0u);
	}

	static Main3D()
	{
		Class72.smethod_20();
		color_0 = Color.FromArgb(0, 255, 255, 255);
		TRANSPARENT_UNSAFE = new UnsafeColor(0, byte.MaxValue, byte.MaxValue, byte.MaxValue);
		SHADOW = Color.FromArgb(127, 0, 0, 0);
	}
}
