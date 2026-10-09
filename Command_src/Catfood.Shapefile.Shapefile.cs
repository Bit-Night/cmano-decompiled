using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

namespace Catfood.Shapefile;

public sealed class Shapefile : IDisposable, IEnumerator<Shape>, IEnumerator, IEnumerable<Shape>, IEnumerable
{
	public const string ConnectionStringTemplateJet = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=dBase IV";

	public const string ConnectionStringTemplateAce = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=dBase IV";

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private int int_0 = -1;

	private int int_1;

	private RectangleD rectangleD_0;

	private ShapeType shapeType_0;

	private string string_0;

	private string string_1;

	private string aaEeeJtdfvu;

	private string string_2;

	private FileStream fileStream_0;

	private FileStream fileStream_1;

	private Header header_0;

	private Header header_1;

	private string string_3;

	public string ConnectionStringTemplate
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public bool RawMetadataOnly
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public int Count
	{
		get
		{
			if (!bool_0)
			{
				if (!bool_1)
				{
					throw new InvalidOperationException("Shapefile not open.");
				}
				return int_1;
			}
			throw new ObjectDisposedException("Shapefile");
		}
	}

	public RectangleD BoundingBox
	{
		get
		{
			if (bool_0)
			{
				throw new ObjectDisposedException("Shapefile");
			}
			if (!bool_1)
			{
				throw new InvalidOperationException("Shapefile not open.");
			}
			return rectangleD_0;
		}
	}

	public ShapeType Type
	{
		get
		{
			if (bool_0)
			{
				throw new ObjectDisposedException("Shapefile");
			}
			if (!bool_1)
			{
				throw new InvalidOperationException("Shapefile not open.");
			}
			return shapeType_0;
		}
	}

	public Shape Current
	{
		get
		{
			if (bool_0)
			{
				throw new ObjectDisposedException("Shapefile");
			}
			if (!bool_1)
			{
				throw new InvalidOperationException("Shapefile not open.");
			}
			StringDictionary metadata = null;
			int num;
			if (RawMetadataOnly)
			{
				num = 8;
			}
			else
			{
				metadata = new StringDictionary();
				num = 8;
			}
			byte[] array = new byte[num];
			fileStream_1.Seek(100 + int_0 * 8, SeekOrigin.Begin);
			fileStream_1.Read(array, 0, array.Length);
			int num2 = EndianBitConverter.ToInt32(array, 0, ProvidedOrder.Big);
			int num3 = EndianBitConverter.ToInt32(array, 4, ProvidedOrder.Big) * 2 + 8;
			byte[] array2 = new byte[num3];
			fileStream_0.Seek(num2 * 2, SeekOrigin.Begin);
			fileStream_0.Read(array2, 0, num3);
			return ShapeFactory.ParseShape(array2, metadata, null);
		}
	}

	object IEnumerator.Current
	{
		get
		{
			if (bool_0)
			{
				throw new ObjectDisposedException("Shapefile");
			}
			if (!bool_1)
			{
				throw new InvalidOperationException("Shapefile not open.");
			}
			return Current;
		}
	}

	public Shapefile()
		: this(null, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=dBase IV")
	{
	}

	public Shapefile(string path)
		: this(path, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=dBase IV")
	{
	}

	public Shapefile(string path, string connectionStringTemplate)
	{
		if (connectionStringTemplate == null)
		{
			throw new ArgumentNullException("connectionStringTemplate");
		}
		ConnectionStringTemplate = connectionStringTemplate;
		if (path != null)
		{
			Open(path);
		}
	}

	public void Open(string path)
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("Shapefile");
		}
		if (path == null)
		{
			throw new ArgumentNullException("path");
		}
		if (path.Length <= 0)
		{
			throw new ArgumentException("path parameter is empty", "path");
		}
		string_0 = Path.ChangeExtension(path, "shp");
		string_1 = Path.ChangeExtension(path, "shx");
		aaEeeJtdfvu = Path.ChangeExtension(path, "dbf");
		if (FileExistsNative.FileExistsFast(string_0))
		{
			if (FileExistsNative.FileExistsFast(string_1))
			{
				if (FileExistsNative.FileExistsFast(aaEeeJtdfvu))
				{
					fileStream_0 = File.Open(string_0, FileMode.Open, FileAccess.Read, FileShare.Read);
					fileStream_1 = File.Open(string_1, FileMode.Open, FileAccess.Read, FileShare.Read);
					if (fileStream_0.Length < 100L)
					{
						throw new InvalidOperationException("Shapefile main file does not contain a valid header");
					}
					if (fileStream_1.Length < 100L)
					{
						throw new InvalidOperationException("Shapefile index file does not contain a valid header");
					}
					byte[] array = new byte[100];
					fileStream_0.Read(array, 0, 100);
					header_0 = new Header(array);
					fileStream_1.Read(array, 0, 100);
					header_1 = new Header(array);
					shapeType_0 = header_0.ShapeType;
					rectangleD_0 = new RectangleD(header_0.XMin, header_0.YMin, header_0.XMax, header_0.YMax);
					int_1 = (header_1.FileLength - 50) / 4;
					method_0();
					bool_1 = true;
					return;
				}
				throw new FileNotFoundException("Shapefile dBase file not found", aaEeeJtdfvu);
			}
			throw new FileNotFoundException("Shapefile index file not found", string_1);
		}
		throw new FileNotFoundException("Shapefile main file not found", string_0);
	}

	public void Close()
	{
		Dispose();
	}

	private void method_0()
	{
	}

	private void method_1()
	{
	}

	~Shapefile()
	{
		method_2(bool_3: false);
	}

	public void Dispose()
	{
		method_2(bool_3: true);
		GC.SuppressFinalize(this);
	}

	private void method_2(bool bool_3)
	{
		if (bool_0)
		{
			return;
		}
		if (bool_3)
		{
			if (fileStream_0 != null)
			{
				fileStream_0.Close();
				fileStream_0 = null;
			}
			if (fileStream_1 != null)
			{
				fileStream_1.Close();
				fileStream_1 = null;
			}
			method_1();
		}
		bool_0 = true;
		bool_1 = false;
	}

	public bool MoveNext()
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("Shapefile");
		}
		if (!bool_1)
		{
			throw new InvalidOperationException("Shapefile not open.");
		}
		if (int_0++ < int_1 - 1)
		{
			return true;
		}
		return false;
	}

	public void Reset()
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("Shapefile");
		}
		if (!bool_1)
		{
			throw new InvalidOperationException("Shapefile not open.");
		}
		method_1();
		method_0();
		int_0 = -1;
	}

	public IEnumerator<Shape> GetEnumerator()
	{
		return this;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this;
	}

	static Shapefile()
	{
		Class72.smethod_20();
	}
}
