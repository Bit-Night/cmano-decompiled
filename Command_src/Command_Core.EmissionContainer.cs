using System.Data.SQLite;
using System.Linq;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EmissionContainer
{
	public float Age;

	public bool IsIllumination;

	public bool PreciseID;

	private Sensor sensor_0;

	public Sensor AssociatedSensor
	{
		get
		{
			if (sensor_0 == null && !theScen.Cache_AssociatedSensors.TryGetValue(SensorID, out sensor_0))
			{
				SQLiteConnection sqliteConnection_ = theScen.DBConnection;
				sensor_0 = DBFunctions.GetSensor(SensorID, ref sqliteConnection_);
				theScen.Cache_AssociatedSensors.TryAdd(SensorID, sensor_0);
			}
			return sensor_0;
		}
	}

	public string ID_Description
	{
		get
		{
			if (sensor_0 == null)
			{
				SQLiteConnection sqliteConnection_ = theScen.DBConnection;
				sensor_0 = DBFunctions.GetSensor(SensorID, ref sqliteConnection_);
			}
			if (sensor_0.IsOECM)
			{
				return "JAMMER";
			}
			string result = "";
			if (!PreciseID)
			{
				if (sensor_0.IsSonar)
				{
					if (sensor_0.SearchFreqs.Count() > 0)
					{
						Sensor.FrequencyBand band = sensor_0.SearchFreqs[0].Band;
						Sensor.FrequencyBand num = band - 4001L;
						if ((ulong)num <= 3uL)
						{
							switch (num)
							{
							case (Sensor.FrequencyBand)0L:
								result = "LF sonar";
								break;
							case (Sensor.FrequencyBand)1L:
								result = "MF sonar";
								break;
							case (Sensor.FrequencyBand)2L:
								result = "HF sonar";
								break;
							case (Sensor.FrequencyBand)3L:
								result = "VLF sonar";
								break;
							}
						}
					}
				}
				else
				{
					result = sensor_0.RoleDescription;
				}
			}
			else
			{
				result = sensor_0.Name;
			}
			return result;
		}
	}

	public EmissionContainer(double theAge, bool IsPainting, bool bool_0)
	{
		Age = (float)theAge;
		IsIllumination = IsPainting;
		PreciseID = bool_0;
	}

	public override string ToString()
	{
		return XmlConvert.ToString(Age) + "-" + IsIllumination + "-" + PreciseID;
	}

	public static EmissionContainer FromString(ref string SourceString)
	{
		string[] array = SourceString.Split(new char[1] { '-' });
		double theAge = XmlConvert.ToSingle(array[0]);
		bool isPainting = Conversions.ToBoolean(array[1]);
		bool bool_ = Conversions.ToBoolean(array[2]);
		return new EmissionContainer(theAge, isPainting, bool_);
	}

	static EmissionContainer()
	{
		Class72.smethod_20();
	}
}
