using System.Runtime.CompilerServices;

namespace DiskQueue.Implementation;

public sealed class Operation
{
	[CompilerGenerated]
	private OperationType operationType_0;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	[CompilerGenerated]
	private int int_2;

	public OperationType Type
	{
		[CompilerGenerated]
		get
		{
			return operationType_0;
		}
		[CompilerGenerated]
		set
		{
			operationType_0 = value;
		}
	}

	public int FileNumber
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int Start
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public int Length
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public Operation(OperationType type, int fileNumber, int start, int length)
	{
		Type = type;
		FileNumber = fileNumber;
		Start = start;
		Length = length;
	}

	static Operation()
	{
		Class72.smethod_20();
	}
}
