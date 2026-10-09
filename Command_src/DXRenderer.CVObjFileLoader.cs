using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace DXRenderer;

public class CVObjFileLoader
{
	private enum Enum12 : uint
	{

	}

	public class TObjLoadFace
	{
		public int vIndex;

		public int tIndex;

		public int nIndex;

		public uint flags;

		public bool HasUV()
		{
			return (flags & 1) != 0;
		}

		public bool HasNormal()
		{
			return (flags & 2) != 0;
		}

		static TObjLoadFace()
		{
			Class72.smethod_20();
		}
	}

	public struct TObjLoadMaterial
	{
		public string name;

		public Texture diffuse;
	}

	public class TObjLoadMap
	{
		public Vector3 v;

		public Vector3 n;

		public Vector2 uv;

		public int vOriginal;

		public int tOriginal;

		public int nOriginal;

		public int map;

		public uint flags;

		public bool HasUV()
		{
			return (flags & 1) != 0;
		}

		public bool HasNormal()
		{
			return (flags & 2) != 0;
		}

		static TObjLoadMap()
		{
			Class72.smethod_20();
		}
	}

	private CVFrame cvframe_0;

	private int int_0;

	private DXDevice dxdevice_0;

	private CVFrame cvframe_1;

	private List<TObjLoadFace> list_0 = new List<TObjLoadFace>();

	private int int_1;

	private string string_0;

	private List<Vector3> list_1 = new List<Vector3>();

	private List<Vector2> list_2 = new List<Vector2>();

	private List<Vector3> list_3 = new List<Vector3>();

	private List<TObjLoadMaterial> list_4 = new List<TObjLoadMaterial>();

	private string[] string_1 = new string[11]
	{
		"o", "g", "v", "f", "vn", "vt", "usemtl", "mtllib", "newmtl", "map_kd",
		""
	};

	public CVObjFileLoader(string filename, DXDevice drawArgs)
	{
		dxdevice_0 = drawArgs;
		try
		{
			StreamReader streamReader = new StreamReader(filename);
			ParseObjFormat(streamReader);
			streamReader.Close();
		}
		catch (Exception arg)
		{
			Console.WriteLine("General loader {0} Exception caught.", arg);
		}
		dxdevice_0 = null;
	}

	public CVFrame GetRoot()
	{
		return cvframe_0;
	}

	private string method_0(ref string string_2, bool bool_0 = false)
	{
		int num = 0;
		string text = "";
		int i;
		for (i = 0; i < string_2.Length && (string_2[i] == ' ' || string_2[i] == '\t'); i++)
		{
		}
		for (; i < string_2.Length && (string_2[i] != ' ' || bool_0) && string_2[i] != '\t' && string_2[i] != '\n' && string_2[i] != '\r'; i++)
		{
			num++;
			text += string_2[i];
		}
		for (; i < string_2.Length && (string_2[i] == ' ' || string_2[i] == '\t' || string_2[i] == '\n' || string_2[i] == '\r'); i++)
		{
		}
		string_2 = string_2.Substring(i);
		if (bool_0)
		{
			text = text.TrimEnd(Array.Empty<char>());
		}
		return text;
	}

	private Enum12 method_1(string string_2)
	{
		for (uint num = 0u; num < 10; num++)
		{
			if (string.Compare(string_2, string_1[num], ignoreCase: true) == 0)
			{
				return (Enum12)num;
			}
		}
		return (Enum12)10u;
	}

	private void Error(string formatString, params dynamic[] args)
	{
	}

	private void method_2(string string_2)
	{
		if (cvframe_0 == null)
		{
			cvframe_0 = new CVFrame();
		}
		method_3();
		cvframe_1 = new CVFrame(cvframe_0);
		cvframe_1.mName = string_2;
	}

	private void method_3()
	{
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		if (cvframe_1 != null && list_0.Count > 0)
		{
			List<TObjLoadMap> list = new List<TObjLoadMap>();
			int num = list_0.Count / 3;
			for (int i = 0; i < num * 3; i++)
			{
				int num2 = -1;
				int count = list.Count;
				int num3 = 0;
				while (num2 == -1 && num3 < count)
				{
					if (list[num3].vOriginal == list_0[i].vIndex)
					{
						bool flag = false;
						if (list_0[i].HasUV() && list[num3].tOriginal != list_0[i].tIndex)
						{
							flag = true;
						}
						if (list_0[i].HasNormal() && list[num3].nOriginal != list_0[i].nIndex)
						{
							flag = true;
						}
						if (!flag)
						{
							num2 = num3;
						}
					}
					num3++;
				}
				if (num2 == -1)
				{
					TObjLoadMap tObjLoadMap = new TObjLoadMap();
					tObjLoadMap.flags = list_0[i].flags;
					tObjLoadMap.vOriginal = list_0[i].vIndex;
					tObjLoadMap.tOriginal = list_0[i].tIndex;
					tObjLoadMap.nOriginal = list_0[i].nIndex;
					tObjLoadMap.map = list.Count;
					tObjLoadMap.v = list_1[tObjLoadMap.vOriginal - 1];
					if (list_0[i].HasNormal())
					{
						tObjLoadMap.n = list_3[tObjLoadMap.nOriginal - 1];
					}
					if (list_0[i].HasUV())
					{
						tObjLoadMap.uv = list_2[tObjLoadMap.tOriginal - 1];
					}
					list.Add(tObjLoadMap);
					num2 = tObjLoadMap.map;
				}
				list_0[i].vIndex = num2;
			}
			CVMesh cVMesh = new CVMesh(dxdevice_0);
			cVMesh.SetVertexCount(list.Count, 7u);
			cVMesh.SetFaceCount(num);
			for (int i = 0; i < cVMesh.VertexCount(); i++)
			{
				list[i].v.Z *= -1f;
				cVMesh.VertexStream()[i] = list[i].v;
				cVMesh.UVStream()[i].u = 0f;
				cVMesh.UVStream()[i].v = 0f;
				if (list[i].HasUV())
				{
					cVMesh.UVStream()[i].u = list[i].uv.X;
					cVMesh.UVStream()[i].v = 1f - list[i].uv.Y;
				}
				if (cVMesh.PrelightStream() != null)
				{
					cVMesh.PrelightStream()[i] = uint.MaxValue;
				}
			}
			for (int i = 0; i < num; i++)
			{
				cVMesh.Indices()[i * 3] = list_0[i * 3].vIndex;
				cVMesh.Indices()[i * 3 + 1] = list_0[i * 3 + 2].vIndex;
				cVMesh.Indices()[i * 3 + 2] = list_0[i * 3 + 1].vIndex;
			}
			cVMesh.MakeNormals(buildAsFlatFaces: true);
			cVMesh.Rebuild();
			if (int_1 != -1 && list_4[int_1].diffuse != null)
			{
				cVMesh.SetTexture(list_4[int_1].diffuse);
			}
			else if (list_4.Count == 0)
			{
				cvframe_1.SetMesh(cVMesh);
			}
		}
		list_0.Clear();
		cvframe_1 = null;
		int_1 = -1;
	}

	public void LoadMaterialFile(string filename)
	{
		string path = string_0 + "/" + filename;
		try
		{
			StreamReader streamReader = new StreamReader(path);
			ParseObjFormat(streamReader, 1u);
			streamReader.Close();
		}
		catch
		{
		}
	}

	public void ParseObjFormat(StreamReader data, uint flags = 0u)
	{
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		float[] array = new float[3];
		TObjLoadFace[] array2 = new TObjLoadFace[4];
		TObjLoadMaterial tObjLoadMaterial = default(TObjLoadMaterial);
		string string_;
		Vector3 item = default(Vector3);
		Vector2 item2 = default(Vector2);
		while ((string_ = data.ReadLine()) != null)
		{
			bool flag = false;
			if (string_.Length > 0 && string_[0] == '#')
			{
				flag = true;
			}
			if (flag)
			{
				continue;
			}
			string string_2 = method_0(ref string_);
			Enum12 @enum = method_1(string_2);
			switch (@enum)
			{
			case (Enum12)0u:
				string_2 = method_0(ref string_);
				method_2(string_2);
				break;
			case (Enum12)1u:
				string_2 = method_0(ref string_);
				if (cvframe_1 == null)
				{
					method_2(string_2);
				}
				break;
			case (Enum12)3u:
			{
				int num2 = 0;
				for (int i = 0; i < 4; i++)
				{
					TObjLoadFace tObjLoadFace = new TObjLoadFace();
					tObjLoadFace.flags = 0u;
					tObjLoadFace.nIndex = 0;
					tObjLoadFace.tIndex = 0;
					string_2 = method_0(ref string_);
					if (string_2.Length == 0)
					{
						continue;
					}
					tObjLoadFace.vIndex = Convert.ToInt32(string_2);
					int num3 = string_2.IndexOf('/');
					if (num3 != -1)
					{
						if (string_2[num3 + 1] != '/')
						{
							tObjLoadFace.flags |= 1u;
							int num4 = string_2.IndexOf('/', num3 + 1);
							if (num4 != -1)
							{
								tObjLoadFace.tIndex = Convert.ToInt32(string_2.Substring(num3 + 1, num4 - (num3 + 1)));
							}
							else
							{
								tObjLoadFace.tIndex = Convert.ToInt32(string_2.Substring(num3 + 1));
							}
						}
						num3 = string_2.IndexOf('/', num3 + 1);
						if (num3 != -1)
						{
							tObjLoadFace.flags |= 2u;
							tObjLoadFace.nIndex = Convert.ToInt32(string_2.Substring(num3 + 1));
						}
					}
					array2[num2] = tObjLoadFace;
					num2++;
				}
				if (num2 >= 3)
				{
					list_0.Add(array2[0]);
					list_0.Add(array2[1]);
					list_0.Add(array2[2]);
					if (num2 == 4)
					{
						list_0.Add(array2[0]);
						list_0.Add(array2[2]);
						list_0.Add(array2[3]);
					}
				}
				break;
			}
			case (Enum12)2u:
			case (Enum12)4u:
			{
				int num;
				if (cvframe_1 != null)
				{
					num = 0;
				}
				else
				{
					method_2("object");
					num = 0;
				}
				for (int i = num; i < 3; i++)
				{
					string_2 = method_0(ref string_);
					if (string_2[0] == '\0')
					{
						Error("ObjLoad::Bad vertex or normal data: %s", string_);
					}
					array[i] = (float)Convert.ToDouble(string_2);
				}
				((Vector3)(ref item))..ctor(array[0], array[1], array[2]);
				if (@enum == (Enum12)2u)
				{
					list_1.Add(item);
				}
				else
				{
					list_3.Add(item);
				}
				break;
			}
			case (Enum12)5u:
			{
				for (int i = 0; i < 2; i++)
				{
					string_2 = method_0(ref string_);
					if (string_2[0] == '\0')
					{
						Error("ObjLoad::Bad vertex or normal data: %s", string_);
					}
					array[i] = (float)Convert.ToDouble(string_2);
				}
				((Vector2)(ref item2))..ctor(array[0], array[1]);
				list_2.Add(item2);
				break;
			}
			case (Enum12)6u:
			{
				int_1 = -1;
				string_2 = method_0(ref string_);
				if (string_2[0] == '\0')
				{
					Error("Bad usemat file: %s", string_);
					break;
				}
				for (int i = 0; i < list_4.Count; i++)
				{
					if (string.Compare(string_2, list_4[i].name, ignoreCase: true) == 0)
					{
						int_1 = i;
					}
				}
				break;
			}
			case (Enum12)7u:
				string_2 = method_0(ref string_, bool_0: true);
				if (string_2[0] == '\0')
				{
					Error("Bad mat file: %s", string_);
				}
				else
				{
					LoadMaterialFile(string_2);
				}
				break;
			case (Enum12)8u:
				string_2 = method_0(ref string_);
				if (string_2[0] == '\0')
				{
					Error("Bad material: %s", string_);
				}
				else
				{
					tObjLoadMaterial = new TObjLoadMaterial
					{
						name = string_2
					};
					list_4.Add(tObjLoadMaterial);
				}
				break;
			case (Enum12)9u:
				string_2 = method_0(ref string_, bool_0: true);
				if (string_2[0] != 0)
				{
					if (list_4.Count > 0)
					{
						_ = string_0 + "/" + string_2;
						tObjLoadMaterial = list_4[list_4.Count - 1];
						if (File.Exists(string_2))
						{
							tObjLoadMaterial.diffuse = null;
						}
						else
						{
							tObjLoadMaterial.diffuse = null;
						}
						list_4[list_4.Count - 1] = tObjLoadMaterial;
					}
					else
					{
						Error("No material defined");
					}
				}
				else
				{
					Error("Bad diffuse: %s", string_);
				}
				break;
			}
		}
		if (flags == 0)
		{
			method_3();
		}
	}

	static CVObjFileLoader()
	{
		Class72.smethod_20();
	}
}
