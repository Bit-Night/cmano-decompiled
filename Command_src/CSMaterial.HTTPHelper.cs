using System;
using System.Collections.Specialized;
using System.IO;
using System.Net.Http;
using System.Runtime.Caching;
using bsn.HttpClientSync;

namespace CSMaterial;

public static class HTTPHelper
{
	private static MemoryCache memoryCache_0;

	private static CacheItemPolicy cacheItemPolicy_0;

	private static CacheItemPolicy smethod_0()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		if (cacheItemPolicy_0 == null)
		{
			cacheItemPolicy_0 = new CacheItemPolicy
			{
				SlidingExpiration = new TimeSpan(0, 0, 15)
			};
		}
		return cacheItemPolicy_0;
	}

	public static byte[] DownloadTile(string theUri)
	{
		if (((ObjectCache)memoryCache_0).Get(theUri, (string)null) != null)
		{
			return null;
		}
		try
		{
			return DownloadAsByteArray(theUri);
		}
		catch (Exception)
		{
			((ObjectCache)memoryCache_0).Add(theUri, (object)true, smethod_0(), (string)null);
			return null;
		}
	}

	public static bool DownloadFile(string uri, string filePath)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		HttpClient val = new HttpClient((HttpMessageHandler)(object)new HttpClientSyncHandler());
		try
		{
			HttpRequestMessage val2 = new HttpRequestMessage(HttpMethod.Get, uri);
			try
			{
				HttpResponseMessage val3 = HttpClientSyncExtensions.Send(val, val2);
				try
				{
					if (val3.IsSuccessStatusCode)
					{
						byte[] bytes = HttpClientSyncExtensions.ReadAsByteArray(val3.Content);
						File.WriteAllBytes(filePath, bytes);
						return true;
					}
					_ = val3.StatusCode;
					return false;
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static byte[] DownloadAsByteArray(string uri)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		HttpClient val = new HttpClient((HttpMessageHandler)(object)new HttpClientSyncHandler());
		try
		{
			HttpRequestMessage val2 = new HttpRequestMessage(HttpMethod.Get, uri);
			try
			{
				HttpResponseMessage val3 = HttpClientSyncExtensions.Send(val, val2);
				try
				{
					if (!val3.IsSuccessStatusCode)
					{
						_ = val3.StatusCode;
						return null;
					}
					return HttpClientSyncExtensions.ReadAsByteArray(val3.Content);
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	static HTTPHelper()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		Class72.smethod_20();
		memoryCache_0 = new MemoryCache("Bad Tile URLs Cache", (NameValueCollection)null);
	}
}
