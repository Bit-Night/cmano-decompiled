using System;
using OpenDis.Dis1995;
using OpenDis.Dis1998;
using OpenDis.Enumerations;

namespace OpenDis.Core;

public static class PduFactory
{
	public static IPdu CreatePdu(byte type, ProtocolVersion version)
	{
		return CreatePdu((PduType)type, version);
	}

	public static IPdu CreatePdu(PduType type, ProtocolVersion version)
	{
		return version switch
		{
			ProtocolVersion.Ieee1278_1_1995 => OpenDis.Dis1995.PduFactory.CreatePdu(type), 
			ProtocolVersion.Ieee1278_1A_1998 => OpenDis.Dis1998.PduFactory.CreatePdu(type), 
			_ => throw new ArgumentException("Unsupported protocol version."), 
		};
	}

	static PduFactory()
	{
		Class72.smethod_20();
	}
}
