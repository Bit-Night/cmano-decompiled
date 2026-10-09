using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.MyServices.Internal;

namespace Command_Core.My;

[StandardModule]
[GeneratedCode("MyTemplate", "11.0.0.0")]
[HideModuleName]
internal sealed class MyProject
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
	internal sealed class MyWebServices
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object o)
		{
			return base.Equals(RuntimeHelpers.GetObjectValue(o));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal new Type GetType()
		{
			return typeof(MyWebServices);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}

		private static T smethod_0<T>(T gparam_0) where T : new()
		{
			if (gparam_0 == null)
			{
				return new T();
			}
			return gparam_0;
		}

		private void method_0<T>(ref T gparam_0)
		{
			gparam_0 = default(T);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MyWebServices()
		{
		}

		static MyWebServices()
		{
			Class72.smethod_20();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(false)]
	internal sealed class ThreadSafeObjectProvider<T> where T : new()
	{
		private readonly ContextValue<T> contextValue_0;

		internal static object object_0;

		internal T GetInstance
		{
			get
			{
				T val = contextValue_0.Value;
				if (val == null)
				{
					val = new T();
					contextValue_0.Value = val;
				}
				return val;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ThreadSafeObjectProvider()
		{
			contextValue_0 = new ContextValue<T>();
		}

		static ThreadSafeObjectProvider()
		{
			Class72.smethod_20();
		}

		internal static bool smethod_0()
		{
			return object_0 == null;
		}

		internal static object smethod_1()
		{
			return object_0;
		}
	}

	private static readonly ThreadSafeObjectProvider<MyComputer> threadSafeObjectProvider_0;

	private static readonly ThreadSafeObjectProvider<MyApplication> threadSafeObjectProvider_1;

	private static readonly ThreadSafeObjectProvider<User> threadSafeObjectProvider_2;

	private static readonly ThreadSafeObjectProvider<MyWebServices> threadSafeObjectProvider_3;

	[HelpKeyword("My.Computer")]
	internal static MyComputer Computer => threadSafeObjectProvider_0.GetInstance;

	[HelpKeyword("My.Application")]
	internal static MyApplication Application => threadSafeObjectProvider_1.GetInstance;

	[HelpKeyword("My.User")]
	internal static User User => threadSafeObjectProvider_2.GetInstance;

	[HelpKeyword("My.WebServices")]
	internal static MyWebServices WebServices => threadSafeObjectProvider_3.GetInstance;

	static MyProject()
	{
		Class72.smethod_20();
		threadSafeObjectProvider_0 = new ThreadSafeObjectProvider<MyComputer>();
		threadSafeObjectProvider_1 = new ThreadSafeObjectProvider<MyApplication>();
		threadSafeObjectProvider_2 = new ThreadSafeObjectProvider<User>();
		threadSafeObjectProvider_3 = new ThreadSafeObjectProvider<MyWebServices>();
	}
}
