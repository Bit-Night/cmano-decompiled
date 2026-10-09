using System;
using System.Runtime.CompilerServices;
using Gameloop.Vdf.Linq;

namespace Gameloop.Vdf;

public abstract class VdfWriter : IDisposable
{
	protected internal enum State
	{
		Start,
		Key,
		Value,
		ObjectStart,
		ObjectEnd,
		Finished,
		Closed
	}

	[CompilerGenerated]
	private readonly VdfSerializerSettings vdfSerializerSettings_0;

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private State state_0;

	public VdfSerializerSettings Settings
	{
		[CompilerGenerated]
		get
		{
			return vdfSerializerSettings_0;
		}
	}

	public bool CloseOutput
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	protected internal State CurrentState
	{
		[CompilerGenerated]
		get
		{
			return state_0;
		}
		[CompilerGenerated]
		protected set
		{
			state_0 = value;
		}
	}

	protected VdfWriter()
		: this(VdfSerializerSettings.Default)
	{
	}

	protected VdfWriter(VdfSerializerSettings settings)
	{
		vdfSerializerSettings_0 = settings;
		CurrentState = State.Start;
		CloseOutput = true;
	}

	public abstract void WriteObjectStart();

	public abstract void WriteObjectEnd();

	public abstract void WriteKey(string key);

	public abstract void WriteValue(VValue value);

	void IDisposable.Dispose()
	{
		if (CurrentState != State.Closed)
		{
			Close();
		}
	}

	public virtual void Close()
	{
		CurrentState = State.Closed;
	}

	static VdfWriter()
	{
		Class72.smethod_20();
	}
}
