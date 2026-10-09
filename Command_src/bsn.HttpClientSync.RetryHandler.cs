using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace bsn.HttpClientSync;

public class RetryHandler : DelegatingHandler
{
	private class Class70 : HttpContent
	{
		private MemoryStream memoryStream_0;

		[CompilerGenerated]
		private readonly HttpContent httpContent_0;

		public Class70(HttpContent httpContent_1)
		{
			httpContent_0 = httpContent_1;
			foreach (KeyValuePair<string, IEnumerable<string>> item in (HttpHeaders)httpContent_1.Headers)
			{
				((HttpHeaders)((HttpContent)this).Headers).Add(item.Key, item.Value);
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public HttpContent method_0()
		{
			return httpContent_0;
		}

		public async ValueTask method_1()
		{
			if (memoryStream_0 == null)
			{
				memoryStream_0 = new MemoryStream();
				await method_0().CopyToAsync((Stream)memoryStream_0, (TransportContext)null).ConfigureAwait(continueOnCapturedContext: false);
				memoryStream_0.Seek(0L, SeekOrigin.Begin);
			}
		}

		protected override async Task<Stream> CreateContentReadStreamAsync()
		{
			await method_1().ConfigureAwait(continueOnCapturedContext: false);
			return memoryStream_0;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				memoryStream_0?.Dispose();
				method_0().Dispose();
			}
			((HttpContent)this).Dispose(disposing);
		}

		public void Reset()
		{
			memoryStream_0?.Seek(0L, SeekOrigin.Begin);
		}

		protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
		{
			await method_1().ConfigureAwait(continueOnCapturedContext: false);
			await stream.WriteAsync(memoryStream_0.GetBuffer(), 0, (int)memoryStream_0.Length).ConfigureAwait(continueOnCapturedContext: false);
		}

		protected override bool TryComputeLength(out long length)
		{
			if (memoryStream_0 == null)
			{
				length = 0L;
				return false;
			}
			length = memoryStream_0.Length;
			return true;
		}

		static Class70()
		{
			Class72.smethod_20();
		}
	}

	private readonly int int_0;

	private static bool smethod_0(Exception exception_0)
	{
		if (exception_0 is SocketException)
		{
			return true;
		}
		if (exception_0.InnerException != null)
		{
			return smethod_0(exception_0.InnerException);
		}
		return false;
	}

	public RetryHandler(int retryCount, HttpMessageHandler innerHandler)
		: base(innerHandler)
	{
		int_0 = retryCount;
	}

	private ValueTask Delay(bool sync, int milliseconds, CancellationToken cancellationToken)
	{
		if (sync)
		{
			cancellationToken.WaitHandle.WaitOne(milliseconds);
			return default(ValueTask);
		}
		return new ValueTask(Task.Delay(milliseconds, cancellationToken));
	}

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		Class70 retryableHttpContent = null;
		try
		{
			if (request.Content != null)
			{
				retryableHttpContent = (Class70)(object)(request.Content = (HttpContent)(object)new Class70(request.Content));
				await retryableHttpContent.method_1().ConfigureAwait(continueOnCapturedContext: false);
			}
			HttpResponseMessage response = null;
			bool sync = HttpClientSyncExtensions.IsSynchronous(request);
			int retries = int_0;
			do
			{
				try
				{
					response = await method_0(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (retries-- <= 0)
					{
						_ = response.IsSuccessStatusCode;
						break;
					}
					switch (response.StatusCode)
					{
					case HttpStatusCode.ServiceUnavailable:
						await Delay(sync, 5000, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						break;
					default:
						return response;
					case HttpStatusCode.TooManyRequests:
						await Delay(sync, 1000, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						break;
					}
					response.Dispose();
					retryableHttpContent?.Reset();
				}
				catch (Exception ex) when (smethod_0(ex))
				{
					await Delay(sync, 2000, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			while (!cancellationToken.IsCancellationRequested);
			cancellationToken.ThrowIfCancellationRequested();
			return response;
		}
		finally
		{
			request.Content = retryableHttpContent?.method_0();
		}
	}

	[CompilerGenerated]
	private Task<HttpResponseMessage> method_0(HttpRequestMessage httpRequestMessage_0, CancellationToken cancellationToken_0)
	{
		return ((DelegatingHandler)this).SendAsync(httpRequestMessage_0, cancellationToken_0);
	}

	static RetryHandler()
	{
		Class72.smethod_20();
	}
}
