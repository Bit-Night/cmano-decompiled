using System.Collections.Generic;
using System.Text;

namespace Command_Core;

public class AggregateGroundUnit_Engagment
{
	public List<AggregateGroundUnit> Bluefor;

	public List<AggregateGroundUnit> Opfor;

	public AggregateGroundUnit OpforFocalPoint;

	public Geopoint_Struct BlueforPoint;

	public Geopoint_Struct OpforPoint;

	private StringBuilder stringBuilder_0;

	public AggregateGroundUnit_Engagment(AggregateGroundUnit _Opfor)
	{
		stringBuilder_0 = new StringBuilder();
		Bluefor = new List<AggregateGroundUnit>();
		Opfor = new List<AggregateGroundUnit>();
		OpforFocalPoint = _Opfor;
	}

	public override string ToString()
	{
		return ToString(Detailed: true);
	}

	public string ToString(bool Detailed)
	{
		stringBuilder_0.Clear();
		if (!Detailed)
		{
			stringBuilder_0.Append("Engagement between ");
			foreach (AggregateGroundUnit item in Bluefor)
			{
				stringBuilder_0.Append(item.ToString());
				stringBuilder_0.Append(", ");
			}
			stringBuilder_0.Append(" and ");
			stringBuilder_0.Append(Opfor.ToString());
		}
		else
		{
			method_0("OpFor", Opfor);
			stringBuilder_0.AppendLine("Vs");
			method_0("BlueFor", Bluefor);
		}
		return stringBuilder_0.ToString();
	}

	private void method_0(string string_0, List<AggregateGroundUnit> list_0)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		foreach (AggregateGroundUnit item in list_0)
		{
			foreach (KeyValuePair<string, (ActiveUnit, int)> item2 in item.GetActualRoster_Readonly())
			{
				if (!(item2.Value.Item1 is IMobileGroundUnit) || !(item2.Value.Item1 is ICargoClient))
				{
					continue;
				}
				IMobileGroundUnit obj = (IMobileGroundUnit)item2.Value.Item1;
				_ = (ICargoClient)item2.Value.Item1;
				IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = obj.MobileUnitCategory;
				if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Armor && mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Armor_Recon)
				{
					if (mobileUnitCategory >= IMobileGroundUnit._MobileUnitCategory.Artillery_Gun && mobileUnitCategory <= IMobileGroundUnit._MobileUnitCategory.Artillery_SSM)
					{
						num3 += (float)item2.Value.Item2;
					}
					else if (mobileUnitCategory >= IMobileGroundUnit._MobileUnitCategory.MechAirborne && mobileUnitCategory <= IMobileGroundUnit._MobileUnitCategory.Motorized_Infantry)
					{
						num2 += (float)item2.Value.Item2;
					}
				}
				else
				{
					num4 += (float)item2.Value.Item2;
				}
				if (!item2.Value.Item1.IsVehicle)
				{
					if (item2.Value.Item1.IsFacility)
					{
						num += (float)(((Facility)item2.Value.Item1).Crew * item2.Value.Item2);
					}
				}
				else
				{
					num += (float)(((Vehicle)item2.Value.Item1).Crew * item2.Value.Item2);
				}
			}
		}
		stringBuilder_0.AppendLine(string_0);
		if (num > 0f)
		{
			stringBuilder_0.AppendLine(num + " PP");
		}
		if (num4 > 0f)
		{
			stringBuilder_0.AppendLine(num4 + " TK");
		}
		if (num2 > 0f)
		{
			stringBuilder_0.AppendLine(num2 + " IFV");
		}
		if (num3 > 0f)
		{
			stringBuilder_0.AppendLine(num3 + " ART");
		}
	}

	public void ComputeIntermediatePoints()
	{
		int num = Bluefor.Count - 1;
		double num3 = default(double);
		int index = default(int);
		for (int i = 0; i <= num; i++)
		{
			double num2 = Geodesic_Haversine.Distance_Horiz_Approx_nm(((ActiveUnit)Bluefor[i]).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)Bluefor[i]).get_Longitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)OpforFocalPoint).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)OpforFocalPoint).get_Longitude((GlobalVariables.BooleanObject)null));
			if (i == 0)
			{
				num3 = num2;
				index = i;
			}
			else if (num2 < num3)
			{
				num3 = num2;
				index = i;
			}
		}
		AggregateGroundUnit aggregateGroundUnit = Bluefor[index];
		float bearing = Module_Unit.BearingToUnit_True(aggregateGroundUnit, OpforFocalPoint);
		double num4 = Geodesic_Haversine.Distance_Horiz_Approx_nm(((ActiveUnit)aggregateGroundUnit).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)aggregateGroundUnit).get_Longitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)OpforFocalPoint).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)OpforFocalPoint).get_Longitude((GlobalVariables.BooleanObject)null));
		double out_lon = default(double);
		double out_lat = default(double);
		Geodesic_EdWilliams.CalcPoint_Williams(((ActiveUnit)aggregateGroundUnit).get_Longitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)aggregateGroundUnit).get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, num4 * 0.4000000059604645, bearing);
		BlueforPoint = new Geopoint_Struct(out_lon, out_lat);
		Geodesic_EdWilliams.CalcPoint_Williams(((ActiveUnit)aggregateGroundUnit).get_Longitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)aggregateGroundUnit).get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, num4 * 0.5, bearing);
		OpforPoint = new Geopoint_Struct(out_lon, out_lat);
	}

	public void ComputeAxis()
	{
	}

	static AggregateGroundUnit_Engagment()
	{
		Class72.smethod_20();
	}
}
