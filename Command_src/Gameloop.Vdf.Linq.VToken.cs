using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Gameloop.Vdf.Utilities;

namespace Gameloop.Vdf.Linq;

public abstract class VToken : IVEnumerable<VToken>, IEnumerable<VToken>, IEnumerable, IDynamicMetaObjectProvider
{
	[CompilerGenerated]
	private VToken vtoken_0;

	[CompilerGenerated]
	private VToken dgOyqNvMtav;

	[CompilerGenerated]
	private VToken vtoken_1;

	public VToken Parent
	{
		[CompilerGenerated]
		get
		{
			return vtoken_0;
		}
		[CompilerGenerated]
		internal set
		{
			vtoken_0 = value;
		}
	}

	public VToken Previous
	{
		[CompilerGenerated]
		get
		{
			return dgOyqNvMtav;
		}
		[CompilerGenerated]
		internal set
		{
			dgOyqNvMtav = value;
		}
	}

	public VToken Next
	{
		[CompilerGenerated]
		get
		{
			return vtoken_1;
		}
		[CompilerGenerated]
		internal set
		{
			vtoken_1 = value;
		}
	}

	IVEnumerable<VToken> IVEnumerable<VToken>.this[object key] => this[key];

	public virtual VToken this[object key]
	{
		get
		{
			throw new InvalidOperationException($"Cannot access child value on {GetType()}.");
		}
		set
		{
			throw new InvalidOperationException($"Cannot set child value on {GetType()}.");
		}
	}

	public abstract void WriteTo(VdfWriter writer);

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable<VToken>)this).GetEnumerator();
	}

	IEnumerator<VToken> IEnumerable<VToken>.GetEnumerator()
	{
		return Children().GetEnumerator();
	}

	public virtual T Value<T>(object key)
	{
		VToken vToken = this[key];
		if (vToken != null)
		{
			return Extensions.Convert<VToken, T>(vToken);
		}
		return default(T);
	}

	public virtual IEnumerable<VProperty> Children()
	{
		return Enumerable.Empty<VProperty>();
	}

	public IEnumerable<T> Children<T>() where T : VToken
	{
		return Children().OfType<T>();
	}

	protected virtual DynamicMetaObject GetMetaObject(Expression parameter)
	{
		return new DynamicProxyMetaObject<VToken>(parameter, this, new DynamicProxy<VToken>());
	}

	DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
	{
		return GetMetaObject(parameter);
	}

	public override string ToString()
	{
		using StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
		VdfTextWriter writer = new VdfTextWriter(stringWriter);
		WriteTo(writer);
		return stringWriter.ToString();
	}

	static VToken()
	{
		Class72.smethod_20();
	}
}
