using System;
using System.Collections.Generic;
using System.Linq;

namespace Command_Core;

public sealed class StoredCourse
{
	public List<TravelWaypoint> Waypoints;

	private int int_0;

	private int int_1;

	private float float_0;

	private double double_0;

	public StoredCourse()
	{
		int_0 = 0;
		int_1 = 0;
		float_0 = 0f;
		double_0 = 0.0;
		Waypoints = new List<TravelWaypoint>();
	}

	internal bool IsEmpty()
	{
		if (Waypoints.Count > 0)
		{
			return false;
		}
		return true;
	}

	private void method_0(Geopoint_Struct geopoint_Struct_0, DateTime dateTime_0, float float_1, float float_2)
	{
		Waypoints.Add(new TravelWaypoint(geopoint_Struct_0, dateTime_0, float_1, float_2));
	}

	public void AddWaypoint(TravelWaypoint Waypoint, bool RefreshDistanceTraveled = true)
	{
		Waypoints.Add(Waypoint);
		ComputeTotalDistance();
		ComputeTotalTimeElapsed();
	}

	internal float ComputeDistanceBetweenPoints(int Index1, int Index2)
	{
		return Math2.CalcDist(Waypoints[Index1].position.ToGeoPoint(), Waypoints[Index2].position.ToGeoPoint());
	}

	internal double ComputeElapsedTimeBetweenPoints(int Index1, int Index2)
	{
		if (Waypoints.Count - 1 >= Index1 && Waypoints.Count - 1 >= Index2)
		{
			return (Waypoints[Index2].TimeStamp - Waypoints[Index1].TimeStamp).TotalSeconds;
		}
		return 0.0;
	}

	internal float ComputeTotalDistance(bool ComputeFromScratch = false)
	{
		if (Waypoints.Count >= 2 && (ComputeFromScratch || int_1 <= Waypoints.Count - 2))
		{
			if (ComputeFromScratch)
			{
				float_0 = 0f;
				int num = Waypoints.Count - 2;
				for (int i = 0; i <= num; i++)
				{
					float_0 += ComputeDistanceBetweenPoints(i, i + 1);
				}
			}
			else
			{
				int num2 = int_1;
				int num3 = Waypoints.Count - 2;
				for (int j = num2; j <= num3; j++)
				{
					float_0 += ComputeDistanceBetweenPoints(j, j + 1);
				}
			}
			int_1 = Waypoints.Count - 2;
			return float_0;
		}
		return 0f;
	}

	internal double ComputeTotalTimeElapsed(bool ComputeFromScratch = false)
	{
		if (Waypoints.Count >= 2 && (ComputeFromScratch || int_0 <= Waypoints.Count - 2))
		{
			if (!ComputeFromScratch)
			{
				int num = int_0;
				int num2 = Waypoints.Count - 2;
				for (int i = num; i <= num2; i++)
				{
					double_0 += ComputeElapsedTimeBetweenPoints(i, i + 1);
				}
			}
			else
			{
				float_0 = 0f;
				int num3 = Waypoints.Count - 2;
				for (int j = 0; j <= num3; j++)
				{
					double_0 += ComputeElapsedTimeBetweenPoints(j, j + 1);
				}
			}
			int_0 = Waypoints.Count - 2;
			return double_0;
		}
		return 0.0;
	}

	internal StoredCourse GetInterpolatedJourney(float Factor)
	{
		if (Factor != 1f && Factor != 0f)
		{
			StoredCourse storedCourse = new StoredCourse();
			float num = Factor;
			foreach (TravelWaypoint waypoint in Waypoints)
			{
				num -= 1f;
				if (num == 0f)
				{
					storedCourse.AddWaypoint(waypoint);
					num = Factor;
				}
			}
			return storedCourse;
		}
		return this;
	}

	public void CopyWaypointDataToWeapon(ref Weapon TargetObject, int WaypointIndex)
	{
		if (WaypointIndex <= Waypoints.Count - 1 && WaypointIndex >= 0)
		{
			Waypoints.ElementAt(WaypointIndex).CopyDataToWeapon(ref TargetObject);
		}
	}

	public void CopyWaypointDataToContact(ref Contact TargetObject, int WaypointIndex)
	{
		if (WaypointIndex <= Waypoints.Count - 1 && WaypointIndex >= 0)
		{
			Waypoints.ElementAt(WaypointIndex).CopyDataToContact(ref TargetObject);
		}
	}

	internal int LookForBeginningTime(DateTime StartTime)
	{
		int num = Waypoints.Count - 1;
		int num2 = 0;
		while (true)
		{
			if (num2 <= num)
			{
				if (DateTime.Compare(Waypoints.ElementAt(num2).TimeStamp, StartTime) == 0)
				{
					break;
				}
				num2++;
				continue;
			}
			return -1;
		}
		return num2;
	}

	internal Trajectory_Str ComputeMeanTrajectory(int range)
	{
		if (Waypoints.Count >= range && range != 0)
		{
			Trajectory_Str trajectory_Str = new Trajectory_Str();
			int num = Waypoints.Count - 1;
			int num2 = Waypoints.Count - 1 - range;
			int num3 = num;
			for (int i = num2; i <= num3; i++)
			{
				trajectory_Str.MeanSpeed += Waypoints.ElementAt(i).CurrentSpeed;
				trajectory_Str.MeanHeading += Waypoints.ElementAt(i).CurrentHeading;
			}
			if (trajectory_Str.MeanSpeed != 0f && trajectory_Str.MeanHeading != 0f)
			{
				trajectory_Str.MeanSpeed /= range;
				trajectory_Str.MeanHeading /= range;
				trajectory_Str.AltitudeDeltaPerSecond = (float)((double)(Waypoints.ElementAt(num).position.Altitude - Waypoints.ElementAt(num2).position.Altitude) / ComputeElapsedTimeBetweenPoints(num2, num));
				return trajectory_Str;
			}
			return null;
		}
		return null;
	}

	internal Trajectory_Str PredictMeanTrajectory(int range, int SecondsAhead)
	{
		Trajectory_Str trajectory_Str = ComputeMeanTrajectory(range);
		trajectory_Str.AltitudeDeltaPerSecond *= SecondsAhead;
		return trajectory_Str;
	}

	internal bool IsValidWaypointIndex(int Index)
	{
		int result;
		if (Index <= Waypoints.Count - 1)
		{
			if (Waypoints.Count > 0)
			{
				return true;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	static StoredCourse()
	{
		Class72.smethod_20();
	}
}
