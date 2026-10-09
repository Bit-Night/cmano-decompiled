using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace bsn.HttpClientSync;

public class HttpClientSyncHandler : HttpClientHandler
{
	private readonly Func<HttpClientHandler, HttpRequestMessage, HttpWebRequest> func_0 = ReflectionHelper<HttpClientHandler>.GetPrivateMethod<Func<HttpClientHandler, HttpRequestMessage, HttpWebRequest>>("CreateAndPrepareWebRequest");

	private readonly Func<HttpClientHandler, HttpWebResponse, HttpRequestMessage, HttpResponseMessage> func_1 = ReflectionHelper<HttpClientHandler>.GetPrivateMethod<Func<HttpClientHandler, HttpWebResponse, HttpRequestMessage, HttpResponseMessage>>("CreateResponseMessage");

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage, CancellationToken cancellationToken)
	{
		if (requestMessage != null)
		{
			HttpResponseMessage val;
			if (!HttpClientSyncExtensions.IsSynchronous(requestMessage))
			{
				val = await method_0(requestMessage, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			else
			{
				HttpWebRequest httpWebRequest = func_0((HttpClientHandler)(object)this, requestMessage);
				WindowsIdentity windowsIdentity = null;
				if (ExecutionContext.IsFlowSuppressed())
				{
					IWebProxy webProxy = null;
					if (((HttpClientHandler)this).UseProxy)
					{
						webProxy = ((HttpClientHandler)this).Proxy ?? WebRequest.DefaultWebProxy;
					}
					if (((HttpClientHandler)this).UseDefaultCredentials || ((HttpClientHandler)this).Credentials != null || (webProxy != null && webProxy.Credentials != null))
					{
						windowsIdentity = WindowsIdentity.GetCurrent();
					}
				}
				if (requestMessage.Content != null)
				{
					HttpContent content = requestMessage.Content;
					if (requestMessage.Headers.TransferEncodingChunked != true)
					{
						Stream stream = HttpClientSyncExtensions.ReadAsStream(content);
						httpWebRequest.ContentLength = content.Headers.ContentLength ?? stream.Length;
						WindowsImpersonationContext val2 = windowsIdentity?.Impersonate();
						Stream requestStream;
						try
						{
							requestStream = httpWebRequest.GetRequestStream();
						}
						finally
						{
							((IDisposable)val2)?.Dispose();
						}
						stream.CopyTo(requestStream);
					}
					else
					{
						httpWebRequest.SendChunked = true;
					}
				}
				else
				{
					httpWebRequest.ContentLength = 0L;
				}
				HttpWebResponse httpWebResponse;
				try
				{
					httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				}
				catch (WebException ex)
				{
					httpWebResponse = (HttpWebResponse)ex.Response;
				}
				if (httpWebResponse == null)
				{
					return null;
				}
				val = func_1((HttpClientHandler)(object)this, httpWebResponse, requestMessage);
				val.Content = (HttpContent)(object)SyncStreamContent.FromStreamContent((StreamContent)val.Content);
			}
			return val;
		}
		throw new ArgumentNullException("requestMessage", "A request message must be provided. It cannot be null.");
	}

	[CompilerGenerated]
	private Task<HttpResponseMessage> method_0(HttpRequestMessage httpRequestMessage_0, CancellationToken cancellationToken_0)
	{
		return ((HttpClientHandler)this).SendAsync(httpRequestMessage_0, cancellationToken_0);
	}

	static HttpClientSyncHandler()
	{
		Class72.smethod_20();
	}
}
