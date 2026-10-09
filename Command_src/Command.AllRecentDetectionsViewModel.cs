using System.Collections.ObjectModel;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscate]
public sealed class AllRecentDetectionsViewModel : CommandViewModel
{
	private ObservableCollection<RecentDetectionViewModel> observableCollection_0;

	public ObservableCollection<RecentDetectionViewModel> Items
	{
		get
		{
			return observableCollection_0;
		}
		set
		{
			SetProperty(ref observableCollection_0, value, "Items");
		}
	}

	public AllRecentDetectionsViewModel()
	{
		observableCollection_0 = new ObservableCollection<RecentDetectionViewModel>();
		Items.Add(new RecentDetectionViewModel
		{
			PlatformName = "Platform Name1",
			SensorName = "Sensor Name123",
			PlatformDBID = 133,
			SensorDBID = 1536,
			TimeSinceDetection_String = "2d 7hrs",
			DetectionRange_String = "7.5nm"
		});
		Items.Add(new RecentDetectionViewModel
		{
			PlatformName = "Platform Name2",
			SensorName = "Sensor Name456",
			PlatformDBID = 141,
			SensorDBID = 1136,
			TimeSinceDetection_String = "2d 7hrs",
			DetectionRange_String = "7.5nm"
		});
		Items.Add(new RecentDetectionViewModel
		{
			PlatformName = "Platform Name3",
			SensorName = "Sensor Name789",
			PlatformDBID = 11465,
			SensorDBID = 1136,
			TimeSinceDetection_String = "2d 7hrs",
			DetectionRange_String = "7.5nm"
		});
	}

	static AllRecentDetectionsViewModel()
	{
		Class72.smethod_20();
	}
}
