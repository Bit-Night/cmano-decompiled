using System;
using System.Runtime.CompilerServices;

namespace Gameloop.Vdf;

public abstract class VdfReader : IDisposable
{
	protected internal enum State
	{
		Start,
		Property,
		Object,
		Conditional,
		Finished,
		Closed
	}

	protected const int MaximumTokenSize = 4096;

	[CompilerGenerated]
	private readonly VdfSerializerSettings vdfSerializerSettings_0;

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private string string_0;

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

	public bool CloseInput
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

	public string Value
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

	protected VdfReader()
		: this(VdfSerializerSettings.Default)
	{
	}

	protected VdfReader(VdfSerializerSettings settings)
	{
		vdfSerializerSettings_0 = settings;
		CurrentState = State.Start;
		Value = null;
		CloseInput = true;
	}

	public abstract bool ReadToken();

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
		Value = null;
	}

	static VdfReader()
	{
		Class72.smethod_20();
	}
}
