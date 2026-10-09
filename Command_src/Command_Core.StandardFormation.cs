using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class StandardFormation
{
	public enum FormationType : byte
	{
		RelativeToLead,
		RelativeToPrevious,
		MultiSided,
		RelativeToFirstStation
	}

	public static List<StandardFormation> StandardFormationList;

	protected string _Name;

	protected FormationType _Type;

	protected List<ActiveUnit_Navigator.FormationStation> _Stations;

	public string Name => _Name;

	public FormationType Type => _Type;

	static StandardFormation()
	{
		Class72.smethod_20();
		StandardFormationList = new List<StandardFormation>();
	}

	public StandardFormation()
	{
		_Stations = new List<ActiveUnit_Navigator.FormationStation>();
	}

	public static void LoadStandardFormations()
	{
		StandardFormationList.Clear();
		string path = Path.Combine(GameGeneral.ResourcesFolderPath, "Formation\\StandardFormations.txt");
		List<string> list = new List<string>();
		if (!File.Exists(path))
		{
			return;
		}
		try
		{
			FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			StreamReader streamReader = new StreamReader(stream);
			while (!streamReader.EndOfStream)
			{
				list.Add(streamReader.ReadLine());
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error loading group formation data", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			ProjectData.ClearProjectError();
			return;
		}
		if (list.Count <= 1 || !int.TryParse(list[0], out var result))
		{
			return;
		}
		int num = result;
		for (int i = 1; i <= num; i++)
		{
			StandardFormation standardFormation = new StandardFormation();
			if (standardFormation.LoadText(list[i]))
			{
				StandardFormationList.Add(standardFormation);
			}
		}
	}

	public static string SetFormation(ActiveUnit theGroup, string formationName, float baseHeading, float baseDistance, int spacingUnit, bool teleportToStations)
	{
		if (theGroup == null)
		{
			return "Invalid group or unit is not a group";
		}
		if (theGroup.IsGroup)
		{
			Group obj = (Group)theGroup;
			int num = 0;
			if (!string.IsNullOrEmpty(formationName))
			{
				if (StandardFormationList.Count == 0)
				{
					LoadStandardFormations();
				}
				StandardFormation standardFormation;
				if (!formationName.StartsWith("Custom:", ignoreCase: true, null))
				{
					using (List<StandardFormation>.Enumerator enumerator = StandardFormationList.GetEnumerator())
					{
						while (enumerator.MoveNext() && string.Compare(enumerator.Current.Name, formationName, ignoreCase: true) != 0)
						{
							num++;
						}
					}
					if (num >= StandardFormationList.Count)
					{
						return "Invalid formation";
					}
					standardFormation = StandardFormationList[num];
				}
				else
				{
					StandardFormation standardFormation2 = new StandardFormation();
					if (!standardFormation2.LoadText(formationName))
					{
						return "Invalid custom formation";
					}
					standardFormation = standardFormation2;
				}
				float baseDistance2 = baseDistance;
				if (spacingUnit == 0)
				{
					baseDistance2 = (float)((double)baseDistance * 0.000539957);
				}
				int num2;
				if ((object)baseHeading == null)
				{
					num2 = 0;
				}
				else
				{
					obj.GroupLead.set_DesiredHeading(ActiveUnit.TurnRate.Max, baseHeading);
					num2 = 0;
				}
				int num3 = num2;
				int num4 = obj.Units.Count - 1;
				for (int i = 0; i <= num4; i++)
				{
					standardFormation.SetFormationStation(obj.Units.Values.ElementAtOrDefault(i), num3, baseDistance2);
					if (obj.Units.Values.ElementAtOrDefault(i) != obj.GroupLead)
					{
						num3++;
					}
				}
				if (teleportToStations)
				{
					obj.GroupLead.CurrentHeading = obj.GroupLead.DesiredHeading;
					int num5 = obj.Units.Count - 1;
					for (int j = 0; j <= num5; j++)
					{
						ActiveUnit activeUnit = obj.Units.Values.ElementAtOrDefault(j);
						if (activeUnit != obj.GroupLead)
						{
							activeUnit.CurrentHeading = obj.GroupLead.CurrentHeading;
							(double, double) tuple = activeUnit.Navigator.UnitFormationStation.get_ValidatedLatitudeAndLongitude(activeUnit, obj.GroupLead);
							activeUnit.Teleport(ref activeUnit.ParentScen, tuple.Item2, tuple.Item1);
						}
					}
				}
				obj.LastFormationSet = standardFormation.Name;
				obj.LastFormationSpacing = baseDistance;
				obj.LastFormationSpacingUnits = (byte)spacingUnit;
				return "Ok";
			}
			return "Invalid formation";
		}
		return "Unit is not a group";
	}

	internal ActiveUnit GetPreceedingUnitInGroupFormation(ActiveUnit au, int stepsBack)
	{
		bool flag = false;
		int num = 1;
		int num2 = au.get_ParentGroup(UsingMissionPlanner: false).Units.Count - 1;
		while (true)
		{
			if (num2 >= 0)
			{
				if (au.get_ParentGroup(UsingMissionPlanner: false).Units.Values.ElementAtOrDefault(num2) == au)
				{
					flag = true;
				}
				else if (flag && au.get_ParentGroup(UsingMissionPlanner: false).Units.Values.ElementAtOrDefault(num2) != au.get_ParentGroup(UsingMissionPlanner: false).GroupLead)
				{
					if (num == stepsBack)
					{
						break;
					}
					num++;
				}
				num2 += -1;
				continue;
			}
			return null;
		}
		return au.get_ParentGroup(UsingMissionPlanner: false).Units.Values.ElementAtOrDefault(num2);
	}

	public void SetFormationStation(ActiveUnit au, int myIndex, float baseDistance)
	{
		if (au.get_ParentGroup(UsingMissionPlanner: false) == null || au.IsGroupLead())
		{
			return;
		}
		ActiveUnit groupLead = au.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
		ActiveUnit activeUnit = null;
		int count = au.get_ParentGroup(UsingMissionPlanner: false).Units.Count;
		int index = myIndex % _Stations.Count;
		int num = 1 + myIndex / _Stations.Count;
		ActiveUnit_Navigator.FormationStation formationStation = new ActiveUnit_Navigator.FormationStation();
		if (_Type == FormationType.MultiSided)
		{
			int num2 = count - 1;
			int num4;
			int num5;
			if (num2 < _Stations.Count)
			{
				int num3 = 1;
				num4 = 2;
				num5 = 1;
			}
			else
			{
				int num3 = num2 / _Stations.Count;
				num4 = 2 * num3;
				if (num3 * _Stations.Count < num2)
				{
					int num6 = 0;
					if ((count & (count - 1)) == 0)
					{
						num6 = 1;
					}
					num4 += num2 - num6 - num3 * _Stations.Count;
					if (num4 % 2 == 1)
					{
						num4++;
					}
				}
				if (num4 / 2 == num3 && num2 % 2 == 0)
				{
					num4 += 2;
					num5 = 1;
				}
				else
				{
					num5 = 1;
				}
			}
			num = num5;
			if (myIndex < num4)
			{
				index = myIndex % 2;
				activeUnit = ((myIndex >= 2) ? GetPreceedingUnitInGroupFormation(au, 2) : groupLead);
			}
			else
			{
				index = 2 + myIndex % 2;
				activeUnit = GetPreceedingUnitInGroupFormation(au, 2);
			}
		}
		else if (myIndex > 0)
		{
			if (_Type == FormationType.RelativeToPrevious)
			{
				activeUnit = GetPreceedingUnitInGroupFormation(au, 1);
				if (activeUnit == null)
				{
					activeUnit = groupLead;
				}
			}
			else if (_Type == FormationType.RelativeToFirstStation && _Stations.Count > 1)
			{
				index = 1 + (myIndex - 1) % (_Stations.Count - 1);
				num = 1 + (myIndex - 1) / (_Stations.Count - 1);
				if (count > 1)
				{
					activeUnit = au.get_ParentGroup(UsingMissionPlanner: false).Units.Values.ElementAtOrDefault(1);
				}
				if (activeUnit == null)
				{
					activeUnit = groupLead;
				}
			}
		}
		formationStation.BearingType = _Stations[index].BearingType;
		if (activeUnit == null)
		{
			formationStation.Bearing = _Stations[index].Bearing;
			formationStation.Distance = baseDistance * _Stations[index].Distance * (float)num;
		}
		else
		{
			float num7 = _Stations[index].Bearing;
			float num8 = baseDistance * _Stations[index].Distance;
			if (formationStation.BearingType == ReferencePoint.OrientationType.Rotating)
			{
				num7 = Math2.NormalizeBearing(num7 + groupLead.CurrentHeading);
			}
			if (_Type == FormationType.RelativeToFirstStation)
			{
				num8 *= (float)num;
			}
			(double, double) tuple = activeUnit.Navigator.UnitFormationStation.get_LatitudeAndLongitude(activeUnit, groupLead);
			double out_lon = default(double);
			double out_lat = default(double);
			Geodesic_EdWilliams.CalcPoint_Williams(tuple.Item2, tuple.Item1, ref out_lon, ref out_lat, num8, num7);
			formationStation.Distance = Module_Unit.RangeToPoint_Horiz(groupLead, out_lat, out_lon);
			num7 = Math2.CalcAzimuth(groupLead.get_Latitude((GlobalVariables.BooleanObject)null), groupLead.get_Longitude((GlobalVariables.BooleanObject)null), out_lat, out_lon);
			if (formationStation.BearingType == ReferencePoint.OrientationType.Rotating)
			{
				formationStation.Bearing = Math2.NormalizeBearing(num7 - groupLead.CurrentHeading);
			}
			else
			{
				formationStation.Bearing = num7;
			}
		}
		au.Navigator.UnitFormationStation = formationStation;
	}

	internal bool LoadText(string data)
	{
		if (!string.IsNullOrEmpty(data))
		{
			string[] array = data.Split(new char[1] { '\t' });
			if (array.Count() > 3)
			{
				_Name = array[0];
				_Type = (FormationType)Conversions.ToByte(array[1]);
				int num = Conversions.ToInteger(array[2]) - 1;
				for (int i = 0; i <= num; i++)
				{
					ActiveUnit_Navigator.FormationStation formationStation = new ActiveUnit_Navigator.FormationStation();
					formationStation.BearingType = (ReferencePoint.OrientationType)Conversions.ToByte(array[3 + i * 3]);
					formationStation.Bearing = Conversions.ToSingle(array[3 + i * 3 + 1]);
					formationStation.Distance = Conversions.ToSingle(array[3 + i * 3 + 2]);
					_Stations.Add(formationStation);
				}
			}
			return _Stations.Count > 0;
		}
		return false;
	}
}
