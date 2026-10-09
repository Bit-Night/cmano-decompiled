using System;
using System.Drawing;
using System.IO;
using VectorTileRenderer;

internal class UsageExamples
{
	private class Class19 : ITileProvider
	{
		public byte[] GetTileData(int x, int y, int zoom)
		{
			_ = $"{zoom}/{x}/{y}.pbf";
			throw new NotImplementedException();
		}

		static Class19()
		{
			Class72.smethod_20();
		}
	}

	private static void smethod_0()
	{
		VectorTileSource vectorTileSource = new VectorTileSource(new RemoteTileProvider("https://api.maptiler.com/tiles/v3/{z}/{x}/{y}.pbf?key=YOUR_KEY", "C:\\TileCache\\Vector"));
		VectorTileSource.FromUrl("https://api.maptiler.com/tiles/v3/{z}/{x}/{y}.pbf?key=YOUR_KEY", "C:\\TileCache\\Vector");
		((Image)vectorTileSource.GetTile(17556, 11358, 15)).Dispose();
	}

	private static void smethod_1()
	{
		VectorTileSource vectorTileSource = new VectorTileSource(new FilesystemTileProvider("D:\\MapData\\tiles"));
		VectorTileSource.FromDirectory("D:\\MapData\\tiles");
		((Image)vectorTileSource.GetTile(17556, 11358, 15)).Dispose();
	}

	private static void smethod_2()
	{
		((Image)new VectorTileSource(new FilesystemTileProvider("D:\\MapData\\flat_tiles", FilesystemTileLayout.Flat)).GetTile(17556, 11358, 15)).Dispose();
	}

	private static Bitmap smethod_3(int int_0, int int_1, int int_2)
	{
		RemoteTileProvider remoteTileProvider = new RemoteTileProvider("https://api.maptiler.com/tiles/v3/{z}/{x}/{y}.pbf?key=KEY", "C:\\TileCache");
		FilesystemTileProvider filesystemTileProvider = new FilesystemTileProvider("D:\\MapData\\tiles");
		ITileProvider[] array = new ITileProvider[2] { remoteTileProvider, filesystemTileProvider };
		foreach (ITileProvider provider in array)
		{
			try
			{
				return new VectorTileSource(provider).GetTile(int_0, int_1, int_2);
			}
			catch (TileProviderException)
			{
			}
		}
		return new VectorTileSource(filesystemTileProvider).RenderFromBytes(null, int_2);
	}

	private static void smethod_4()
	{
		((Image)new VectorTileSource(new Class19()).GetTile(17556, 11358, 15)).Dispose();
	}

	private static void smethod_5()
	{
		RemoteTileProvider remoteTileProvider = new RemoteTileProvider("https://api.maptiler.com/tiles/v3/{z}/{x}/{y}.pbf?key=KEY", "C:\\TileCache");
		VectorTileSource vectorTileSource = new VectorTileSource(remoteTileProvider);
		remoteTileProvider.ClearCache();
		((RemoteTileProvider)vectorTileSource.Provider).ClearCache();
	}

	private static void smethod_6()
	{
		FilesystemTileProvider filesystemTileProvider = new FilesystemTileProvider("D:\\MapData\\tiles");
		new VectorTileSource(filesystemTileProvider);
		bool flag = filesystemTileProvider.TileExists(17556, 11358, 15);
		Console.WriteLine($"Tile exists: {flag}");
		Console.WriteLine("Expected path: " + filesystemTileProvider.GetTilePath(17556, 11358, 15));
	}

	private static void smethod_7()
	{
		VectorTileSource vectorTileSource = VectorTileSource.FromDirectory("D:\\MapData\\tiles");
		vectorTileSource.TileSize = 512;
		((Image)vectorTileSource.GetTile(17556, 11358, 15)).Dispose();
	}

	private static void smethod_8()
	{
		foreach (TileLayer layer in VectorTileSource.DecodeTile(File.ReadAllBytes("D:\\MapData\\tiles\\15\\17556\\11358.pbf")).Layers)
		{
			Console.WriteLine($"Layer '{layer.Name}': {layer.Features.Count} features");
			foreach (TileFeature feature in layer.Features)
			{
				Console.WriteLine(string.Format("  {0}  name={1}  class={2}", feature.Type, feature.GetString("name"), feature.GetString("class")));
			}
		}
	}

	private static void Main()
	{
	}

	static UsageExamples()
	{
		Class72.smethod_20();
	}
}
