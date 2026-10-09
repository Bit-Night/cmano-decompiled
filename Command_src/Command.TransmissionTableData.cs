using System;
using System.Runtime.CompilerServices;

namespace Command;

public class TransmissionTableData
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private string string_2;

	[CompilerGenerated]
	private string string_3;

	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private string string_4;

	public string theSenderName
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public string theCommDeviceName
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public string theCommDeviceBandwidth
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	public string theCommDeviceLatency
	{
		[CompilerGenerated]
		get
		{
			return string_3;
		}
		[CompilerGenerated]
		set
		{
			string_3 = value;
		}
	}

	public DateTime theTimeSent
	{
		[CompilerGenerated]
		get
		{
			return dateTime_0;
		}
		[CompilerGenerated]
		set
		{
			dateTime_0 = value;
		}
	}

	public string theConcatenatedFeedback
	{
		[CompilerGenerated]
		get
		{
			return string_4;
		}
		[CompilerGenerated]
		set
		{
			string_4 = value;
		}
	}

	public TransmissionTableData(string theSenderName, string theCommDeviceName, string theCOmmDeviceBandwidth, string theCommDeviceLatency, DateTime theTimeSent, string theConcatenatedFeedback)
	{
		this.theSenderName = theSenderName;
		this.theCommDeviceName = theCommDeviceName;
		theCommDeviceBandwidth = theCOmmDeviceBandwidth;
		this.theCommDeviceLatency = theCommDeviceLatency;
		this.theTimeSent = theTimeSent;
		this.theConcatenatedFeedback = theConcatenatedFeedback;
	}

	static TransmissionTableData()
	{
		Class72.smethod_20();
	}
}
