using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Command_Core;

public sealed class PFCache_Array
{
	private short[,] sngyGiyUnYN;

	public PFCache_Array()
	{
		sngyGiyUnYN = new short[3601, 7201];
		if (!Directory.Exists(GameGeneral.GISFolderPath))
		{
			GameGeneral.SendMessageBoxToUI("Could not find the map data directory " + GameGeneral.GISFolderPath + ". Is the simulator installed and configured correctly?", null);
			return;
		}
		using FileStream serializationStream = new FileStream(Path.Combine(GameGeneral.GISFolderPath, "Elevations"), FileMode.Open);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		sngyGiyUnYN = (short[,])binaryFormatter.Deserialize(serializationStream);
	}

	public short GetElev(double theLat, double theLon, Scenario theScen)
	{
		short num = (short)Math.Round((theLat + 90.0) / 0.05);
		short num2 = (short)Math.Round((theLon + 180.0) / 0.05);
		short num3 = sngyGiyUnYN[num, num2];
		if (num3 == 0)
		{
			short elevation = Terrain.GetElevation(theLat, theLon, RequestIsFromGUI: false, theScen);
			sngyGiyUnYN[num, num2] = elevation;
			num3 = elevation;
		}
		return num3;
	}

	public void SetElev(double theLat, double theLon, short theElev)
	{
		short num = (short)Math.Round((theLat + 90.0) / 0.05);
		short num2 = (short)Math.Round((theLon + 180.0) / 0.05);
		sngyGiyUnYN[num, num2] = theElev;
	}

	public void SaveToDisk()
	{
		using FileStream serializationStream = new FileStream(Path.Combine(GameGeneral.GISFolderPath, "Elevations"), FileMode.Create);
		new BinaryFormatter().Serialize(serializationStream, sngyGiyUnYN);
	}

	static PFCache_Array()
	{
		Class72.smethod_20();
	}
}
