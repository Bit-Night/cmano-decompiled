using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MapReduce.NET.Input;

public abstract class InputPlugin<T> : IOPlugin
{
	[CompilerGenerated]
	private object object_1;

	private uint uint_1;

	private static object object_2;

	public object Position
	{
		[CompilerGenerated]
		get
		{
			return object_1;
		}
		[CompilerGenerated]
		set
		{
			object_1 = value;
		}
	}

	public InputPlugin(object inputLocation)
	{
		base.Location = inputLocation;
	}

	internal void Close()
	{
		RaiseStatusUpdate(UpdateType.Input, uint_1);
		CloseInput();
	}

	public IEnumerable<T> Read()
	{
		uint_1 = 0u;
		T data;
		object index;
		while (ReadItem(out data, out index))
		{
			Position = index;
			if (++uint_1 % base.ReportEveryNth == 0)
			{
				RaiseStatusUpdate(UpdateType.Input, uint_1);
			}
			yield return data;
		}
	}

	protected internal abstract void Open();

	protected abstract void CloseInput();

	protected abstract bool ReadItem(out T data, out object index);

	static InputPlugin()
	{
		Class72.smethod_20();
	}

	internal static bool smethod_0()
	{
		return object_2 == null;
	}

	internal static object smethod_1()
	{
		return object_2;
	}
}
