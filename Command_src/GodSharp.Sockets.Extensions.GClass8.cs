using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace GodSharp.Sockets.Extensions;

public static class GClass8
{
	public static IPEndPoint As(this IPAddress address, int port)
	{
		return new IPEndPoint(address, port);
	}

	public static IEnumerable<IPEndPoint> As(this IPAddress[] address, int port)
	{
		return address?.Select((IPAddress x) => new IPEndPoint(x, port));
	}

	static GClass8()
	{
		Class72.smethod_20();
	}
}
