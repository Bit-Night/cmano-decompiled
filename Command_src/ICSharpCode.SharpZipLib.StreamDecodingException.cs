using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib;

[Serializable]
public class StreamDecodingException : SharpZipBaseException
{
	public StreamDecodingException()
		: base("Input stream could not be decoded")
	{
	}

	public StreamDecodingException(string message)
		: base(message)
	{
	}

	public StreamDecodingException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected StreamDecodingException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	static StreamDecodingException()
	{
		Class72.smethod_20();
	}
}
