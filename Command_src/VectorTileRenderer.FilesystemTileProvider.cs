using System;
using System.IO;

namespace VectorTileRenderer;

public class FilesystemTileProvider : ITileProvider
{
	private readonly string string_0;

	private readonly FilesystemTileLayout filesystemTileLayout_0;

	private readonly string string_1;

	public string RootDirectory => string_0;

	public FilesystemTileLayout Layout => filesystemTileLayout_0;

	public FilesystemTileProvider(string rootDirectory, FilesystemTileLayout layout = FilesystemTileLayout.SlippyMap, string extension = ".pbf")
	{
		if (rootDirectory != null)
		{
			if (!Directory.Exists(rootDirectory))
			{
				throw new DirectoryNotFoundException("Tile root directory not found: " + rootDirectory);
			}
			string_0 = rootDirectory;
			filesystemTileLayout_0 = layout;
			string_1 = (extension.StartsWith(".") ? extension : ("." + extension));
			return;
		}
		throw new ArgumentNullException("rootDirectory");
	}

	public byte[] GetTileData(int x, int y, int zoom)
	{
		string tilePath = GetTilePath(x, y, zoom);
		if (File.Exists(tilePath))
		{
			try
			{
				return File.ReadAllBytes(tilePath);
			}
			catch (Exception ex)
			{
				throw new TileProviderException("Failed to read tile file '" + tilePath + "': " + ex.Message, ex);
			}
		}
		return null;
	}

	public string GetTilePath(int x, int y, int zoom)
	{
		return filesystemTileLayout_0 switch
		{
			FilesystemTileLayout.SlippyMap => Path.Combine(string_0, zoom.ToString(), x.ToString(), y + string_1), 
			FilesystemTileLayout.Flat => Path.Combine(string_0, $"{zoom}_{x}_{y}{string_1}"), 
			_ => throw new InvalidOperationException($"Unknown layout: {filesystemTileLayout_0}"), 
		};
	}

	public bool TileExists(int x, int y, int zoom)
	{
		return File.Exists(GetTilePath(x, y, zoom));
	}

	static FilesystemTileProvider()
	{
		Class72.smethod_20();
	}
}
