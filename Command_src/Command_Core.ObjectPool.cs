using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CSMaterial;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class ObjectPool
{
	public sealed class ObjectPool<T>
	{
		private ConcurrentQueue<T> concurrentQueue_0;

		private Func<T> func_0;

		private int int_0;

		private int int_1;

		internal static object object_0;

		public ObjectPool(Func<T> objectGenerator)
		{
			int_0 = CSMaterial.Misc.Environment_ProcessorCount * 2;
			if (objectGenerator == null)
			{
				throw new ArgumentNullException("objectGenerator");
			}
			concurrentQueue_0 = new ConcurrentQueue<T>();
			func_0 = objectGenerator;
		}

		internal T GetObject()
		{
			T result2;
			try
			{
				if (concurrentQueue_0.TryDequeue(out var result))
				{
					int_1--;
					result2 = result;
				}
				else
				{
					result2 = func_0();
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result2 = func_0();
				ProjectData.ClearProjectError();
			}
			return result2;
		}

		public void PutObject(T item)
		{
			if (item == null)
			{
				return;
			}
			if (int_1 < int_0)
			{
				Task.Factory.StartNew([SpecialName] () =>
				{
					concurrentQueue_0.Enqueue(item);
					int_1++;
				});
			}
			else
			{
				item = default(T);
			}
		}

		static ObjectPool()
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

	static ObjectPool()
	{
		Class72.smethod_20();
	}
}
