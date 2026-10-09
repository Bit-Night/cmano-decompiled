using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Text;
using Newtonsoft.Json;

namespace CommandNetcode.RT;

internal static class RealtimeSerializer
{
	private static object object_0;

	private static JsonSerializerSettings jsonSerializerSettings_0;

	private static JsonSerializerSettings jsonSerializerSettings_1;

	private static byte[] smethod_0(byte[] byte_0)
	{
		MemoryStream stream = RCMS.recyclableMemoryStreamManager_0.GetStream(byte_0);
		using (stream)
		{
			using GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress);
			byte[] buffer = new byte[4096];
			using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
			int num = 0;
			do
			{
				num = gZipStream.Read(buffer, 0, 4096);
				if (num > 0)
				{
					memoryStream.Write(buffer, 0, num);
				}
			}
			while (num > 0);
			return memoryStream.ToArray();
		}
	}

	public static byte[] Compress(byte[] raw)
	{
		using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
		using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, leaveOpen: true))
		{
			gZipStream.Write(raw, 0, raw.Length);
		}
		return memoryStream.ToArray();
	}

	public static byte[] Serialize(object o)
	{
		string s = JsonConvert.SerializeObject(o, jsonSerializerSettings_1);
		return Compress(Encoding.UTF8.GetBytes(s));
	}

	public static object Deserialize(byte[] b)
	{
		b = smethod_0(b);
		return JsonConvert.DeserializeObject(Encoding.UTF8.GetString(b), jsonSerializerSettings_1);
	}

	public static T Deserialize<T>(byte[] b)
	{
		return (T)Deserialize(b);
	}

	private static JsonSerializerSettings smethod_1()
	{
		if (jsonSerializerSettings_0 == null)
		{
			lock (object_0)
			{
				if (jsonSerializerSettings_0 == null)
				{
					jsonSerializerSettings_0 = new JsonSerializerSettings
					{
						TypeNameHandling = TypeNameHandling.All,
						TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
						Culture = new CultureInfo("en-US")
					};
				}
			}
		}
		return jsonSerializerSettings_0;
	}

	static RealtimeSerializer()
	{
		Class72.smethod_20();
		object_0 = new object();
		jsonSerializerSettings_0 = null;
		jsonSerializerSettings_1 = smethod_1();
	}
}
