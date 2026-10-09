using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using Command_Core;

namespace VectorTileRenderer;

public class VectorTileSource : IDisposable
{
	private readonly ITileProvider itileProvider_0;

	private readonly TileRenderer tileRenderer_0;

	private bool bool_0;

	private TwoTierDictionaryCache<(int, int, int), byte[]> twoTierDictionaryCache_0 = new TwoTierDictionaryCache<(int, int, int), byte[]>();

	public int TileSize
	{
		get
		{
			return tileRenderer_0.TileSize;
		}
		set
		{
			tileRenderer_0.TileSize = value;
		}
	}

	public IMapStyle Style
	{
		get
		{
			return tileRenderer_0.Style;
		}
		set
		{
			tileRenderer_0.Style = value;
			twoTierDictionaryCache_0.Clear();
		}
	}

	public ITileProvider Provider => itileProvider_0;

	public VectorTileSource(ITileProvider provider)
	{
		itileProvider_0 = provider ?? throw new ArgumentNullException("provider");
		tileRenderer_0 = new TileRenderer();
	}

	public static VectorTileSource FromUrl(string urlTemplate, string cacheDirectory = null, int timeoutMs = 10000)
	{
		return new VectorTileSource(new RemoteTileProvider(urlTemplate, cacheDirectory, timeoutMs));
	}

	public static VectorTileSource FromDirectory(string rootDirectory, FilesystemTileLayout layout = FilesystemTileLayout.SlippyMap, string extension = ".pbf")
	{
		return new VectorTileSource(new FilesystemTileProvider(rootDirectory, layout, extension));
	}

	public Bitmap GetTile(int x, int y, int zoom)
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("VectorTileSource");
		}
		(int, int, int) key = (x, y, zoom);
		byte[] value = null;
		Bitmap val;
		if (twoTierDictionaryCache_0.TryGet(key, ref value))
		{
			val = method_1(value);
		}
		else
		{
			byte[] tileData = itileProvider_0.GetTileData(x, y, zoom);
			if (tileData == null || tileData.Length == 0)
			{
				return method_2();
			}
			tileData = smethod_0(tileData);
			DecodedTile tile = MvtDecoder.Decode(tileData);
			val = tileRenderer_0.Render(tile, zoom);
			value = method_0(val);
			twoTierDictionaryCache_0.SetItem(key, value, new TimeSpan(0, 0, 300));
		}
		return val;
	}

	private byte[] method_0(Bitmap bitmap_0)
	{
		using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
		((Image)bitmap_0).Save((Stream)memoryStream, ImageFormat.Png);
		return memoryStream.ToArray();
	}

	private Bitmap method_1(byte[] byte_0)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream(byte_0);
		Bitmap val = new Bitmap((Stream)memoryStream);
		try
		{
			return new Bitmap((Image)(object)val);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private static byte[] smethod_0(byte[] byte_0)
	{
		if (byte_0 != null && byte_0.Length >= 2)
		{
			if (byte_0[0] == 31 && byte_0[1] == 139)
			{
				using (MemoryStream stream = new MemoryStream(byte_0))
				{
					using GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress);
					using MemoryStream memoryStream = new MemoryStream();
					gZipStream.CopyTo(memoryStream);
					return memoryStream.ToArray();
				}
			}
			return byte_0;
		}
		return byte_0;
	}

	public Bitmap RenderFromBytes(byte[] pbfData, int zoom)
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("VectorTileSource");
		}
		if (pbfData != null && pbfData.Length != 0)
		{
			DecodedTile tile = MvtDecoder.Decode(pbfData);
			return tileRenderer_0.Render(tile, zoom);
		}
		return method_2();
	}

	public Bitmap RenderTile(DecodedTile tile, int zoom)
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("VectorTileSource");
		}
		return tileRenderer_0.Render(tile, zoom);
	}

	public static DecodedTile DecodeTile(byte[] pbfData)
	{
		return MvtDecoder.Decode(pbfData);
	}

	public void Dispose()
	{
		bool_0 = true;
	}

	private Bitmap method_2()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		Bitmap val = new Bitmap(TileSize, TileSize);
		Graphics val2 = Graphics.FromImage((Image)(object)val);
		try
		{
			val2.Clear(tileRenderer_0.Style.BackgroundColor);
			return val;
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
	}

	static VectorTileSource()
	{
		Class72.smethod_20();
	}
}
