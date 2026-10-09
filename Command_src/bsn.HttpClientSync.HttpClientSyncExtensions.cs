using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace bsn.HttpClientSync;

public static class HttpClientSyncExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HttpResponseMessage Send(this HttpClient that, HttpRequestMessage request)
	{
		return Send(that, request, (HttpCompletionOption)0, default(CancellationToken));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HttpResponseMessage Send(this HttpClient that, HttpRequestMessage request, CancellationToken cancellationToken)
	{
		return Send(that, request, (HttpCompletionOption)0, cancellationToken);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HttpResponseMessage Send(this HttpClient that, HttpRequestMessage request, HttpCompletionOption completionOption)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return Send(that, request, completionOption, default(CancellationToken));
	}

	public static HttpResponseMessage Send(this HttpClient that, HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		request.Properties["Synchronous"] = true;
		return that.SendAsync(request, completionOption, cancellationToken).GetAwaiter().GetResult();
	}

	public static Stream ReadAsStream(this HttpContent that, TransportContext context = null)
	{
		return that.ReadAsStreamAsync().GetAwaiter().GetResult();
	}

	public static string ReadAsString(this HttpContent that, TransportContext context = null)
	{
		Encoding encoding = Encoding.UTF8;
		MediaTypeHeaderValue contentType = that.Headers.ContentType;
		if (contentType != null && contentType.CharSet != null)
		{
			try
			{
				encoding = Encoding.GetEncoding(that.Headers.ContentType.CharSet);
			}
			catch (ArgumentException innerException)
			{
				throw new InvalidOperationException("Invalid charset in HttpContent header", innerException);
			}
		}
		using Stream stream = ReadAsStream(that, context);
		using StreamReader streamReader = new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks: true);
		return streamReader.ReadToEnd();
	}

	public static byte[] ReadAsByteArray(this HttpContent that, TransportContext context = null)
	{
		using Stream stream = ReadAsStream(that, context);
		MemoryStream memoryStream2;
		if (!(stream is MemoryStream memoryStream))
		{
			using (memoryStream2 = new MemoryStream())
			{
				stream.CopyTo(memoryStream2);
				return memoryStream2.ToArray();
			}
		}
		return memoryStream.ToArray();
	}

	public static void CopyTo(this HttpContent that, Stream stream, TransportContext context = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		using (Stream stream2 = ReadAsStream(that, context))
		{
			byte[] array = new byte[81920];
			while (!cancellationToken.IsCancellationRequested)
			{
				int num = stream2.Read(array, 0, array.Length);
				if (num != 0 && !cancellationToken.IsCancellationRequested)
				{
					stream.Write(array, 0, num);
					continue;
				}
				break;
			}
		}
		cancellationToken.ThrowIfCancellationRequested();
	}

	public static bool IsSynchronous(this HttpRequestMessage that)
	{
		if (!that.Properties.TryGetValue("Synchronous", out var value))
		{
			return false;
		}
		return true.Equals(value);
	}

	static HttpClientSyncExtensions()
	{
		Class72.smethod_20();
	}
}
