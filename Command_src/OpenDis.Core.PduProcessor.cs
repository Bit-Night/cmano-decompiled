using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Dis1998;
using OpenDis.Enumerations;

namespace OpenDis.Core;

public class PduProcessor
{
	public const uint PDU_LENGTH_POSITION = 8u;

	public const uint PDU_TYPE_POSITION = 2u;

	public const uint PDU_VERSION_POSITION = 0u;

	private Endian endian_0;

	private XmlSerializer xmlSerializer_0;

	public Endian Endian
	{
		get
		{
			return endian_0;
		}
		set
		{
			endian_0 = value;
		}
	}

	public PduProcessor()
	{
		endian_0 = (BitConverter.IsLittleEndian ? Endian.Little : Endian.Big);
	}

	public static Pdu ConvertByteArrayToPdu1998(byte pduType, byte[] rawPdu, Endian endian)
	{
		return UnmarshalRawPdu(pduType, rawPdu, endian);
	}

	public static StringBuilder DecodePdu(object pdu)
	{
		StringBuilder stringBuilder = new StringBuilder();
		pdu.GetType().InvokeMember("Reflection", BindingFlags.InvokeMethod, null, pdu, new object[1] { stringBuilder }, CultureInfo.InvariantCulture);
		return stringBuilder;
	}

	public List<object> ProcessPdu(byte[] buffer, Endian endian)
	{
		Endian = endian;
		return ProcessPdu(buffer);
	}

	public object ProcessPdu(Stream stream, Endian endian)
	{
		Endian = endian;
		return ProcessPdu(stream);
	}

	public void ProcessPdu(Stream stream, Endian endian, out byte[] rawPdu)
	{
		Endian = endian;
		ProcessPdu(stream, out rawPdu);
	}

	public List<byte[]> ProcessRawPdu(byte[] buffer, Endian endian)
	{
		Endian = endian;
		return ProcessRawPdu(buffer);
	}

	public void ProcessRawPdu(byte[] buffer, Endian endian, ref Queue<byte[]> dataQueue)
	{
		Endian = endian;
		foreach (byte[] item in ProcessRawPdu(buffer))
		{
			dataQueue.Enqueue(item);
		}
	}

	public static Pdu UnmarshalRawPdu(byte pduType, DataInputStream ds)
	{
		return UnmarshalRawPdu((PduType)pduType, ds);
	}

	public static Pdu UnmarshalRawPdu(PduType pduType, DataInputStream ds)
	{
		Pdu result = new Pdu();
		switch (pduType)
		{
		case PduType.EntityState:
		{
			EntityStatePdu entityStatePdu = new EntityStatePdu();
			entityStatePdu.Unmarshal(ds);
			result = entityStatePdu;
			break;
		}
		case PduType.Fire:
		{
			FirePdu firePdu = new FirePdu();
			firePdu.Unmarshal(ds);
			result = firePdu;
			break;
		}
		case PduType.Detonation:
		{
			DetonationPdu detonationPdu = new DetonationPdu();
			detonationPdu.Unmarshal(ds);
			result = detonationPdu;
			break;
		}
		case PduType.Collision:
		{
			CollisionPdu collisionPdu = new CollisionPdu();
			collisionPdu.Unmarshal(ds);
			result = collisionPdu;
			break;
		}
		case PduType.ServiceRequest:
		{
			ServiceRequestPdu serviceRequestPdu = new ServiceRequestPdu();
			serviceRequestPdu.Unmarshal(ds);
			result = serviceRequestPdu;
			break;
		}
		case PduType.ResupplyOffer:
		{
			ResupplyOfferPdu resupplyOfferPdu = new ResupplyOfferPdu();
			resupplyOfferPdu.Unmarshal(ds);
			result = resupplyOfferPdu;
			break;
		}
		case PduType.ResupplyReceived:
		{
			ResupplyReceivedPdu resupplyReceivedPdu = new ResupplyReceivedPdu();
			resupplyReceivedPdu.Unmarshal(ds);
			result = resupplyReceivedPdu;
			break;
		}
		case PduType.ResupplyCancel:
		{
			ResupplyCancelPdu resupplyCancelPdu = new ResupplyCancelPdu();
			resupplyCancelPdu.Unmarshal(ds);
			result = resupplyCancelPdu;
			break;
		}
		case PduType.RepairComplete:
		{
			RepairCompletePdu repairCompletePdu = new RepairCompletePdu();
			repairCompletePdu.Unmarshal(ds);
			result = repairCompletePdu;
			break;
		}
		case PduType.RepairResponse:
		{
			RepairResponsePdu repairResponsePdu = new RepairResponsePdu();
			repairResponsePdu.Unmarshal(ds);
			result = repairResponsePdu;
			break;
		}
		case PduType.CreateEntity:
		{
			CreateEntityPdu createEntityPdu = new CreateEntityPdu();
			createEntityPdu.Unmarshal(ds);
			result = createEntityPdu;
			break;
		}
		case PduType.RemoveEntity:
		{
			RemoveEntityPdu removeEntityPdu = new RemoveEntityPdu();
			removeEntityPdu.Unmarshal(ds);
			result = removeEntityPdu;
			break;
		}
		case PduType.StartResume:
		{
			StartResumePdu startResumePdu = new StartResumePdu();
			startResumePdu.Unmarshal(ds);
			result = startResumePdu;
			break;
		}
		case PduType.StopFreeze:
		{
			StopFreezePdu stopFreezePdu = new StopFreezePdu();
			stopFreezePdu.Unmarshal(ds);
			result = stopFreezePdu;
			break;
		}
		case PduType.Acknowledge:
		{
			AcknowledgePdu acknowledgePdu = new AcknowledgePdu();
			acknowledgePdu.Unmarshal(ds);
			result = acknowledgePdu;
			break;
		}
		case PduType.ActionRequest:
		{
			ActionRequestPdu actionRequestPdu = new ActionRequestPdu();
			actionRequestPdu.Unmarshal(ds);
			result = actionRequestPdu;
			break;
		}
		case PduType.ActionResponse:
		{
			ActionResponsePdu actionResponsePdu = new ActionResponsePdu();
			actionResponsePdu.Unmarshal(ds);
			result = actionResponsePdu;
			break;
		}
		case PduType.DataQuery:
		{
			DataQueryPdu dataQueryPdu = new DataQueryPdu();
			dataQueryPdu.Unmarshal(ds);
			result = dataQueryPdu;
			break;
		}
		case PduType.SetData:
		{
			SetDataPdu setDataPdu = new SetDataPdu();
			setDataPdu.Unmarshal(ds);
			result = setDataPdu;
			break;
		}
		case PduType.EventReport:
		{
			EventReportPdu eventReportPdu = new EventReportPdu();
			eventReportPdu.Unmarshal(ds);
			result = eventReportPdu;
			break;
		}
		case PduType.Comment:
		{
			CommentPdu commentPdu = new CommentPdu();
			commentPdu.Unmarshal(ds);
			result = commentPdu;
			break;
		}
		case PduType.Transmitter:
		{
			TransmitterPdu transmitterPdu = new TransmitterPdu();
			transmitterPdu.Unmarshal(ds);
			result = transmitterPdu;
			break;
		}
		case PduType.Signal:
		{
			SignalPdu signalPdu = new SignalPdu();
			signalPdu.Unmarshal(ds);
			result = signalPdu;
			break;
		}
		case PduType.UnderwaterAcoustic:
		{
			UaPdu uaPdu = new UaPdu();
			uaPdu.Unmarshal(ds);
			result = uaPdu;
			break;
		}
		}
		return result;
	}

	public static Pdu UnmarshalRawPdu(byte pduType, byte[] rawPdu, Endian endian)
	{
		DataInputStream ds = new DataInputStream(rawPdu, endian);
		return UnmarshalRawPdu((PduType)pduType, ds);
	}

	public static Pdu UnmarshalRawPdu(PduType pduType, byte[] rawPdu, Endian endian)
	{
		DataInputStream ds = new DataInputStream(rawPdu, endian);
		return UnmarshalRawPdu(pduType, ds);
	}

	public StringBuilder XmlDecodePdu(object pdu)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		StringBuilder stringBuilder = new StringBuilder();
		using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
		{
			try
			{
				xmlSerializer_0 = new XmlSerializer(pdu.GetType());
				xmlSerializer_0.Serialize((TextWriter)stringWriter, pdu);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				stringBuilder.Append(stringWriter.ToString());
				stringWriter.Close();
			}
		}
		return stringBuilder;
	}

	protected virtual object ProcessPdu(Stream stream)
	{
		int num = 0;
		object obj = null;
		long position = stream.Position;
		byte[] array = new byte[10];
		stream.Read(array, 0, 10);
		try
		{
			num = smethod_0(array, endian_0);
			byte[] array2 = new byte[num];
			stream.Position = position;
			stream.Read(array2, 0, num);
			byte pduType = array2[2];
			byte pduVersion = array2[0];
			return SwitchOnType(pduVersion, pduType, array2);
		}
		catch
		{
			return null;
		}
	}

	protected virtual List<object> ProcessPdu(byte[] buffer)
	{
		List<object> list = new List<object>();
		if (buffer.Length >= 1)
		{
			int num = buffer.Length;
			int num2 = 0;
			uint num3 = 0u;
			while (num2 < num)
			{
				try
				{
					num3 = smethod_0(buffer, endian_0, (uint)(8L + num2));
					if (num3 != 0)
					{
						byte pduType = buffer[2L + num2];
						byte pduVersion = buffer[num2];
						byte[] array = new byte[num3];
						Array.Copy(buffer, num2, array, 0, (int)num3);
						list.Add(SwitchOnType(pduVersion, pduType, array));
						num2 += (int)num3;
						continue;
					}
				}
				catch
				{
				}
				break;
			}
			return list;
		}
		return list;
	}

	protected virtual void ProcessPdu(Stream stream, out byte[] rawData)
	{
		int num = 0;
		long position = stream.Position;
		byte[] array = new byte[10];
		stream.Read(array, 0, 10);
		try
		{
			num = smethod_0(array, endian_0);
			rawData = new byte[num];
			stream.Position = position;
			stream.Read(rawData, 0, num);
		}
		catch
		{
			rawData = null;
		}
	}

	protected virtual List<byte[]> ProcessRawPdu(byte[] buffer)
	{
		List<byte[]> list = new List<byte[]>();
		if (buffer.Length >= 1)
		{
			int num = buffer.Length;
			int num2 = 0;
			uint num3 = 0u;
			while (num2 < num)
			{
				try
				{
					num3 = smethod_0(buffer, endian_0);
					if (num3 != 0)
					{
						byte[] array = new byte[num3];
						Array.Copy(buffer, num2, array, 0, (int)num3);
						list.Add(array);
						num2 += (int)num3;
						continue;
					}
				}
				catch
				{
				}
				break;
			}
			return list;
		}
		return list;
	}

	protected virtual object SwitchOnType(byte pduVersion, uint pduType, byte[] ds)
	{
		object result = null;
		DataInputStream ds2 = new DataInputStream(ds, Endian);
		if (pduVersion != 5 && pduVersion == 6)
		{
			result = UnmarshalRawPdu((PduType)pduType, ds2);
		}
		return result;
	}

	private static ushort smethod_0(object object_0, Endian endian_1, uint uint_0 = 8u)
	{
		byte[] array = new byte[2];
		if (endian_1 == Endian.Big)
		{
			array[0] = ((byte[])object_0)[uint_0 + 1];
			array[1] = ((byte[])object_0)[uint_0];
		}
		else
		{
			array[0] = ((byte[])object_0)[uint_0];
			array[1] = ((byte[])object_0)[uint_0 + 1];
		}
		return BitConverter.ToUInt16(array, 0);
	}

	[Obsolete("This method used Reflection which is slow, new method 'UnmarshallRawPdu' should be used instead.")]
	private static void smethod_1(object object_0, object object_1)
	{
		object_0.GetType().InvokeMember("Unmarshal", BindingFlags.InvokeMethod, null, object_0, new object[1] { object_1 }, CultureInfo.InvariantCulture);
	}

	static PduProcessor()
	{
		Class72.smethod_20();
	}
}
