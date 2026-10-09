using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Management;

[Serializable]
public enum GroupOfRestStatus : byte
{
	[Description("Not rested (Has not slept in the last three days).")]
	NotRestedHasNotSleptInTheLastThreeDays,
	[Description("Has slept an average of 1 hour per day in the last three days.")]
	HasSleptAnAverageOf1HourPerDayInTheLastThreeDays,
	[Description("Has slept an average of 2 hours per day in the last three days.")]
	HasSleptAnAverageOf2HoursPerDayInTheLastThreeDays,
	[Description("Has slept an average of 3 hours per day in the last three days.")]
	HasSleptAnAverageOf3HoursPerDayInTheLastThreeDays,
	[Description("Has slept an average of 4 hours per day in the last three days.")]
	HasSleptAnAverageOf4HoursPerDayInTheLastThreeDays,
	[Description("Has slept an average of 5 hours per day in the last three days.")]
	HasSleptAnAverageOf5HoursPerDayInTheLastThreeDays,
	[Description("Has slept an average of 6 hours per day in the last three days.")]
	HasSleptAnAverageOf6HoursPerDayInTheLastThreeDays,
	[Description("Has slept an average of 7 hours per day in the last three days.")]
	HasSleptAnAverageOf7HoursPerDayInTheLastThreeDays,
	[Description("Fully rested (Has slept an average of 8 hours per day in the last three days).")]
	FullyRestedHasSleptAnAverageOf8HoursPerDayInTheLastThreeDays
}
