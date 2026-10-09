using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace bsn.HttpClientSync;

public class SyncStreamContent : StreamContent
{
	internal static SyncStreamContent FromStreamContent(StreamContent content)
	{
		if (!(content is SyncStreamContent result))
		{
			SyncStreamContent syncStreamContent = ReflectionHelper<SyncStreamContent>.CreateUninitialized();
			ReflectionHelper<StreamContent>.CopyFields(content, (StreamContent)(object)syncStreamContent);
			return syncStreamContent;
		}
		return result;
	}

	public SyncStreamContent(Stream content)
		: base(content)
	{
	}

	public SyncStreamContent(Stream content, int bufferSize)
		: base(content, bufferSize)
	{
	}

	protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
	{
		using (Stream stream2 = ((HttpContent)this).CreateContentReadStreamAsync().Result)
		{
			stream2.CopyTo(stream);
		}
		return Task.CompletedTask;
	}

	static SyncStreamContent()
	{
		Class72.smethod_20();
	}
}
