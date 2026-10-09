using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace GodSharp.Sockets;

public class SocketAggregateException : Exception
{
	[CompilerGenerated]
	private ICollection<Exception> icollection_0;

	[CompilerGenerated]
	private readonly ReadOnlyCollection<Exception> readOnlyCollection_0;

	public int Count
	{
		get
		{
			if (InnerExceptions == null)
			{
				return 0;
			}
			return InnerExceptions.Count;
		}
	}

	public ReadOnlyCollection<Exception> InnerExceptions
	{
		[CompilerGenerated]
		get
		{
			return readOnlyCollection_0;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private ICollection<Exception> method_0()
	{
		return icollection_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_1(ICollection<Exception> icollection_1)
	{
		icollection_0 = icollection_1;
	}

	public SocketAggregateException()
	{
	}

	public SocketAggregateException(string message)
		: this(message, (Exception[])null)
	{
	}

	public SocketAggregateException(string message, params Exception[] exceptions)
		: base(message)
	{
		if (exceptions != null && exceptions.Length != 0)
		{
			readOnlyCollection_0 = new ReadOnlyCollection<Exception>(exceptions);
		}
	}

	static SocketAggregateException()
	{
		Class72.smethod_20();
	}
}
