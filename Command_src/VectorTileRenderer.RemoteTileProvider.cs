using System;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Net;
using Command_Core;
using ThreadSafeCollections;

namespace VectorTileRenderer;

public class RemoteTileProvider : ITileProvider
{
	private readonly string string_0;

	private readonly string string_1;

	private readonly int int_0;

	private TDictionary<string, SQLiteConnection> tdictionary_0 = new TDictionary<string, SQLiteConnection>();

	private string string_2 = Path.Combine(GameGeneral.GISFolderPath, "OSM_Vector");

	public RemoteTileProvider(string urlTemplate, string cacheDirectory = null, int timeoutMs = 10000)
	{
		if (urlTemplate != null)
		{
			string_0 = urlTemplate;
			string_1 = cacheDirectory;
			int_0 = timeoutMs;
			if (string_1 != null && !Directory.Exists(string_1))
			{
				Directory.CreateDirectory(string_1);
			}
			return;
		}
		throw new ArgumentNullException("urlTemplate");
	}

	public byte[] GetTileData(int x, int y, int zoom)
	{
		byte[] array = LoadLocalTileFromPerZoomLevelPack(zoom, x, y);
		if (array != null)
		{
			return array;
		}
		string text = method_2(x, y, zoom);
		if (text != null && File.Exists(text))
		{
			try
			{
				return File.ReadAllBytes(text);
			}
			catch (Exception)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
		}
		byte[] array2 = method_1(x, y, zoom);
		if (array2 == null)
		{
			return null;
		}
		if (text != null)
		{
			try
			{
				string directoryName = Path.GetDirectoryName(text);
				if (!Directory.Exists(directoryName))
				{
					Directory.CreateDirectory(directoryName);
				}
				File.WriteAllBytes(text, array2);
			}
			catch
			{
			}
		}
		return array2;
	}

	internal byte[] LoadLocalTileFromPerZoomLevelPack(int ZoomLevel, int ColumnValue, int RowValue)
	{
		string text = Path.Combine(string_2, ZoomLevel + ".db");
		if (FileExistsNative.FileExistsFast_CheckOnlyOnce(text))
		{
			try
			{
				if (!tdictionary_0.TryGetValue(text, out var value))
				{
					value = method_0(text);
					try
					{
						tdictionary_0.AddIfNotExists(text, value);
					}
					catch
					{
					}
				}
				byte[] result = null;
				using (DbCommand dbCommand = value.CreateCommand())
				{
					dbCommand.CommandText = $"SELECT data FROM tiles WHERE x = {ColumnValue} and y = {RowValue} and z = {ZoomLevel};";
					result = dbCommand.ExecuteScalar() as byte[];
				}
				return result;
			}
			catch (Exception)
			{
				return null;
			}
		}
		return null;
	}

	private SQLiteConnection method_0(string string_3)
	{
		try
		{
			SQLiteConnection sQLiteConnection = new SQLiteConnection($"Data Source={string_3};Version=3;Read Only=True;");
			sQLiteConnection.Open();
			return sQLiteConnection;
		}
		catch (Exception innerException)
		{
			throw new Exception("Exception while opening SQLiteConnection for " + string_3, innerException);
		}
	}

	private byte[] method_1(int int_1, int int_2, int int_3)
	{
		string requestUriString = string_0.Replace("{x}", int_1.ToString()).Replace("{y}", int_2.ToString()).Replace("{z}", int_3.ToString());
		try
		{
			HttpWebRequest obj = (HttpWebRequest)WebRequest.Create(requestUriString);
			obj.Timeout = int_0;
			obj.UserAgent = "VectorTileRenderer/1.0";
			obj.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			using HttpWebResponse httpWebResponse = (HttpWebResponse)obj.GetResponse();
			if (httpWebResponse.StatusCode == HttpStatusCode.OK)
			{
				using MemoryStream memoryStream = new MemoryStream();
				httpWebResponse.GetResponseStream().CopyTo(memoryStream);
				return memoryStream.ToArray();
			}
			return null;
		}
		catch (WebException ex)
		{
			if (!(ex.Response is HttpWebResponse { StatusCode: HttpStatusCode.NotFound }))
			{
				throw new TileProviderException($"Network error fetching tile z={int_3} x={int_1} y={int_2}: {ex.Message}", ex);
			}
			return null;
		}
	}

	private string method_2(int int_1, int int_2, int int_3)
	{
		if (string_1 == null)
		{
			return null;
		}
		return Path.Combine(string_1, int_3.ToString(), int_1.ToString(), int_2 + ".pbf");
	}

	public void ClearCache()
	{
		if (string_1 == null || !Directory.Exists(string_1))
		{
			return;
		}
		string[] files = Directory.GetFiles(string_1, "*.pbf", SearchOption.AllDirectories);
		foreach (string path in files)
		{
			try
			{
				File.Delete(path);
			}
			catch
			{
			}
		}
	}

	static RemoteTileProvider()
	{
		Class72.smethod_20();
	}
}
