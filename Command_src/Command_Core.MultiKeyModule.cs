using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class MultiKeyModule
{
	public enum FieldType : byte
	{
		None,
		Field,
		Property
	}

	public class MultiKeyedCollection<TValue, TKey1> : IEnumerable, IEnumerable<TValue>, IDisposable where TValue : new()
	{
		public struct ThreadSafeEnumerator : IEnumerator<TValue>, IDisposable, IEnumerator
		{
			private MultiKeyedCollection<TValue, TKey1> multiKeyedCollection_0;

			private Dictionary<TKey1, TValue>.Enumerator enumerator_0;

			private TValue gparam_0;

			private int int_0;

			public TValue Current => gparam_0;

			object IEnumerator.Current1 => gparam_0;

			internal ThreadSafeEnumerator(MultiKeyedCollection<TValue, TKey1> multiKeyedCollection_1)
			{
				this = default(ThreadSafeEnumerator);
				multiKeyedCollection_0 = multiKeyedCollection_1;
				enumerator_0 = multiKeyedCollection_1._Index1.GetEnumerator();
				gparam_0 = default(TValue);
			}

			internal bool MoveNext()
			{
				if (gparam_0 != null)
				{
					if (!enumerator_0.MoveNext())
					{
						multiKeyedCollection_0._PrimaryMutex.ReleaseMutex();
						return false;
					}
					gparam_0 = enumerator_0.Current.Value;
					return true;
				}
				multiKeyedCollection_0._PrimaryMutex.WaitOne();
				if (!enumerator_0.MoveNext())
				{
					multiKeyedCollection_0._PrimaryMutex.ReleaseMutex();
					return false;
				}
				gparam_0 = enumerator_0.Current.Value;
				return true;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			public void Dispose()
			{
			}

			private void Reset()
			{
				enumerator_0 = multiKeyedCollection_0._Index1.GetEnumerator();
				gparam_0 = default(TValue);
				multiKeyedCollection_0._PrimaryMutex.ReleaseMutex();
			}

			void IEnumerator.Reset()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Reset
				this.Reset();
			}

			static ThreadSafeEnumerator()
			{
				Class72.smethod_20();
			}

			internal static bool smethod_0()
			{
				return true;
			}

			internal static object smethod_1()
			{
				return null;
			}
		}

		protected Mutex _PrimaryMutex;

		protected Dictionary<TKey1, TValue> _Index1;

		protected FieldInfo[] _Fields;

		protected PropertyInfo[] _Properties;

		protected FieldType[] _FieldTypes;

		protected string[] _FieldNames;

		private bool bool_0;

		private static object object_0;

		public int Count
		{
			get
			{
				_PrimaryMutex.WaitOne();
				int count = _Index1.Count;
				_PrimaryMutex.ReleaseMutex();
				return count;
			}
		}

		public TValue this[TKey1 primaryKey]
		{
			get
			{
				_PrimaryMutex.WaitOne();
				if (!_Index1.TryGetValue(primaryKey, out var value))
				{
					_PrimaryMutex.ReleaseMutex();
					throw new KeyNotFoundException("Primary key not found!");
				}
				_PrimaryMutex.ReleaseMutex();
				return value;
			}
		}

		public MultiKeyedCollection(string Key1FieldName)
		{
			_Index1 = new Dictionary<TKey1, TValue>();
			_Fields = new FieldInfo[1];
			_Properties = new PropertyInfo[1];
			_FieldTypes = new FieldType[1];
			_FieldNames = new string[1];
			bool_0 = false;
			Type typeFromHandle = typeof(TValue);
			_Fields[0] = typeFromHandle.GetField(Key1FieldName);
			if ((object)_Fields[0] == null)
			{
				_Properties[0] = typeFromHandle.GetProperty(Key1FieldName);
				if ((object)_Properties[0] == null)
				{
					throw new ArgumentException("Field 1 name is not accessible in the value object");
				}
				if (!_Properties[0].CanRead)
				{
					throw new ArgumentException("Field 1 is a non-readable property");
				}
				_FieldTypes[0] = FieldType.Property;
			}
			else
			{
				_FieldTypes[0] = FieldType.Field;
			}
			_FieldNames[0] = Key1FieldName;
			_PrimaryMutex = new Mutex(initiallyOwned: true);
			_PrimaryMutex.ReleaseMutex();
		}

		private T method_0<T>(int int_0, TValue gparam_0)
		{
			if (_FieldTypes[int_0] == FieldType.Field)
			{
				return (T)_Fields[int_0].GetValue(gparam_0);
			}
			return (T)_Properties[int_0].GetValue(gparam_0, null);
		}

		public void Add(TValue Value)
		{
			if (Value == null)
			{
				throw new ArgumentNullException("Cannot add a null reference!");
			}
			_PrimaryMutex.WaitOne();
			int num = 0;
			do
			{
				if (num == 0)
				{
					TKey1 key = method_0<TKey1>(0, Value);
					if (_Index1.ContainsKey(key))
					{
						_PrimaryMutex.ReleaseMutex();
						throw new ArgumentException("Object with this primary key already exists!");
					}
					_Index1.Add(key, Value);
				}
				num++;
			}
			while (num <= 0);
			_PrimaryMutex.ReleaseMutex();
		}

		public void Clear()
		{
			_PrimaryMutex.WaitOne();
			int num = 0;
			do
			{
				if (num == 0)
				{
					_Index1.Clear();
				}
				num++;
			}
			while (num <= 0);
			_PrimaryMutex.ReleaseMutex();
		}

		internal bool ContainsKey1(TKey1 key)
		{
			_PrimaryMutex.WaitOne();
			bool result = _Index1.ContainsKey(key);
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool ContainsValue(TValue value)
		{
			bool result;
			if (value == null)
			{
				result = false;
			}
			else
			{
				TKey1 key = method_0<TKey1>(0, value);
				_PrimaryMutex.WaitOne();
				result = _Index1.ContainsKey(key);
				_PrimaryMutex.ReleaseMutex();
			}
			return result;
		}

		internal bool Remove(TKey1 primaryKey)
		{
			_PrimaryMutex.WaitOne();
			bool result = _Index1.Remove(primaryKey);
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool Remove(TValue value)
		{
			bool result;
			if (value == null)
			{
				result = false;
			}
			else
			{
				_PrimaryMutex.WaitOne();
				TKey1 key = method_0<TKey1>(0, value);
				result = _Index1.Remove(key);
				_PrimaryMutex.ReleaseMutex();
			}
			return result;
		}

		internal bool TryGetValue(TKey1 primaryKey, out TValue value)
		{
			_PrimaryMutex.WaitOne();
			bool result = _Index1.TryGetValue(primaryKey, out value);
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal IEnumerator<TValue> GetEnumerator()
		{
			return new ThreadSafeEnumerator(this);
		}

		IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
			return this.GetEnumerator();
		}

		internal IEnumerator GetEnumerator1()
		{
			return new ThreadSafeEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator1
			return this.GetEnumerator1();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!bool_0 && disposing)
			{
				_PrimaryMutex.Close();
			}
			bool_0 = true;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		static MultiKeyedCollection()
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

	public class MultiKeyedCollection<TValue, TKey1, TKey2> : IEnumerable, IEnumerable<TValue>, IDisposable where TValue : new()
	{
		public struct ThreadSafeEnumerator : IEnumerator<TValue>, IDisposable, IEnumerator
		{
			private MultiKeyedCollection<TValue, TKey1, TKey2> ocNypnfnrHp;

			private Dictionary<TKey1, TValue>.Enumerator enumerator_0;

			private TValue gparam_0;

			private int int_0;

			public TValue Current => gparam_0;

			object IEnumerator.Current1 => gparam_0;

			internal ThreadSafeEnumerator(MultiKeyedCollection<TValue, TKey1, TKey2> multiKeyedCollection_0)
			{
				this = default(ThreadSafeEnumerator);
				ocNypnfnrHp = multiKeyedCollection_0;
				enumerator_0 = multiKeyedCollection_0._Index1.GetEnumerator();
				gparam_0 = default(TValue);
			}

			internal bool MoveNext()
			{
				if (gparam_0 == null)
				{
					ocNypnfnrHp._PrimaryMutex.WaitOne();
					if (enumerator_0.MoveNext())
					{
						gparam_0 = enumerator_0.Current.Value;
						return true;
					}
					ocNypnfnrHp._PrimaryMutex.ReleaseMutex();
					return false;
				}
				if (!enumerator_0.MoveNext())
				{
					ocNypnfnrHp._PrimaryMutex.ReleaseMutex();
					return false;
				}
				gparam_0 = enumerator_0.Current.Value;
				return true;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			public void Dispose()
			{
			}

			private void Reset()
			{
				enumerator_0 = ocNypnfnrHp._Index1.GetEnumerator();
				gparam_0 = default(TValue);
				ocNypnfnrHp._PrimaryMutex.ReleaseMutex();
			}

			void IEnumerator.Reset()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Reset
				this.Reset();
			}

			static ThreadSafeEnumerator()
			{
				Class72.smethod_20();
			}

			internal static bool smethod_0()
			{
				return true;
			}

			internal static object smethod_1()
			{
				return null;
			}
		}

		protected Type _T;

		protected Mutex _PrimaryMutex;

		protected Dictionary<TKey1, TValue> _Index1;

		protected Dictionary<TKey2, Dictionary<TKey1, TValue>> _NIndex2;

		protected FieldInfo[] _Fields;

		protected PropertyInfo[] _Properties;

		protected FieldType[] _FieldTypes;

		protected bool[] _IsMutable;

		protected string[] _FieldNames;

		private bool bool_0;

		private static object object_0;

		public int Count
		{
			get
			{
				_PrimaryMutex.WaitOne();
				int count = _Index1.Count;
				_PrimaryMutex.ReleaseMutex();
				return count;
			}
		}

		public TValue this[TKey1 primaryKey]
		{
			get
			{
				_PrimaryMutex.WaitOne();
				if (!_Index1.TryGetValue(primaryKey, out var value))
				{
					_PrimaryMutex.ReleaseMutex();
					throw new KeyNotFoundException("Primary key not found!");
				}
				_PrimaryMutex.ReleaseMutex();
				return value;
			}
		}

		public TValue[] ItemsByKey2
		{
			get
			{
				_PrimaryMutex.WaitOne();
				if (_NIndex2.TryGetValue(key2, out var value))
				{
					TValue[] array = new TValue[value.Count - 1 + 1];
					int num = 0;
					foreach (KeyValuePair<TKey1, TValue> item in value)
					{
						array[num] = item.Value;
						num++;
					}
					_PrimaryMutex.ReleaseMutex();
					return array;
				}
				_PrimaryMutex.ReleaseMutex();
				throw new KeyNotFoundException("Key 2 not found!");
			}
		}

		private void method_0(int int_0, string string_0, bool bool_1)
		{
			_Fields[int_0] = _T.GetField(string_0);
			if ((object)_Fields[int_0] == null)
			{
				_Properties[int_0] = _T.GetProperty(string_0);
				if ((object)_Properties[int_0] == null)
				{
					throw new ArgumentException("Field " + (int_0 + 1) + " name is not accessible in the value object");
				}
				if (!_Properties[1].CanRead)
				{
					throw new ArgumentException("Field " + (int_0 + 1) + " is a non-readable property");
				}
				_FieldTypes[1] = FieldType.Property;
				if (bool_1 && !_Properties[int_0].CanWrite)
				{
					throw new ArgumentException("Field " + (int_0 + 1) + " is a readonly property and cannot be mutable");
				}
				_IsMutable[int_0] = bool_1;
			}
			else
			{
				_FieldTypes[int_0] = FieldType.Field;
				_IsMutable[int_0] = bool_1;
			}
			_FieldNames[int_0] = string_0;
			_IsMutable[int_0] = bool_1;
		}

		private void method_1(string string_0)
		{
			_Fields[0] = _T.GetField(string_0);
			if ((object)_Fields[0] != null)
			{
				_FieldTypes[0] = FieldType.Field;
			}
			else
			{
				_Properties[0] = _T.GetProperty(string_0);
				if ((object)_Properties[0] == null)
				{
					throw new ArgumentException("Field 1 name is not accessible in the value object");
				}
				if (!_Properties[0].CanRead)
				{
					throw new ArgumentException("Field 1 is a non-readable property");
				}
				_FieldTypes[0] = FieldType.Property;
			}
			_FieldNames[0] = string_0;
		}

		public MultiKeyedCollection(string Key1FieldName, string Key2FieldName, bool IsKey2Mutable = false)
		{
			_T = typeof(TValue);
			_Index1 = new Dictionary<TKey1, TValue>();
			_NIndex2 = new Dictionary<TKey2, Dictionary<TKey1, TValue>>();
			_Fields = new FieldInfo[2];
			_Properties = new PropertyInfo[2];
			_FieldTypes = new FieldType[2];
			_IsMutable = new bool[2];
			_FieldNames = new string[2];
			bool_0 = false;
			method_1(Key1FieldName);
			method_0(1, Key2FieldName, IsKey2Mutable);
			_PrimaryMutex = new Mutex(initiallyOwned: true);
			_PrimaryMutex.ReleaseMutex();
		}

		private T method_2<T>(int int_0, TValue gparam_0)
		{
			if (_FieldTypes[int_0] == FieldType.Field)
			{
				return (T)_Fields[int_0].GetValue(gparam_0);
			}
			return (T)_Properties[int_0].GetValue(gparam_0, null);
		}

		private void method_3<T>(int int_0, TValue gparam_0, T gparam_1)
		{
			if (!_IsMutable[int_0])
			{
				throw new ArgumentException("Cannot update an immutable field!");
			}
			if (_FieldTypes[int_0] == FieldType.Field)
			{
				_Fields[int_0].SetValue(gparam_0, gparam_1);
			}
			else
			{
				_Properties[int_0].SetValue(gparam_0, gparam_1, null);
			}
		}

		public void UpdateKey2(TValue obj, TKey2 newKey2)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("Cannot update a null object!");
			}
			_PrimaryMutex.WaitOne();
			TKey1 key = method_2<TKey1>(0, obj);
			if (!_Index1.ContainsKey(key))
			{
				_PrimaryMutex.ReleaseMutex();
				throw new ArgumentException("Object is not part of the collection!");
			}
			TKey2 key2 = method_2<TKey2>(1, obj);
			Dictionary<TKey1, TValue> value = _NIndex2[key2];
			value.Remove(key);
			if (value.Count == 0)
			{
				_NIndex2.Remove(key2);
			}
			method_3(1, obj, newKey2);
			if (_NIndex2.TryGetValue(newKey2, out value))
			{
				value.Add(key, obj);
			}
			else
			{
				value = new Dictionary<TKey1, TValue>();
				value.Add(key, obj);
				_NIndex2.Add(newKey2, value);
			}
			_PrimaryMutex.ReleaseMutex();
		}

		public void Add(TValue Value)
		{
			if (Value == null)
			{
				throw new ArgumentNullException("Cannot add a null reference!");
			}
			_PrimaryMutex.WaitOne();
			int num = 0;
			TKey1 key2 = default(TKey1);
			do
			{
				switch (num)
				{
				case 0:
					key2 = method_2<TKey1>(0, Value);
					if (!_Index1.ContainsKey(key2))
					{
						_Index1.Add(key2, Value);
						break;
					}
					_PrimaryMutex.ReleaseMutex();
					throw new ArgumentException("Object with this primary key already exists!");
				case 1:
				{
					TKey2 key = method_2<TKey2>(1, Value);
					if (_NIndex2.TryGetValue(key, out var value))
					{
						value.Add(key2, Value);
						break;
					}
					value = new Dictionary<TKey1, TValue>();
					value.Add(key2, Value);
					_NIndex2.Add(key, value);
					break;
				}
				}
				num++;
			}
			while (num <= 1);
			_PrimaryMutex.ReleaseMutex();
		}

		public void Clear()
		{
			_PrimaryMutex.WaitOne();
			int num = 0;
			do
			{
				switch (num)
				{
				case 0:
					_Index1.Clear();
					break;
				case 1:
					_NIndex2.Clear();
					break;
				}
				num++;
			}
			while (num <= 1);
			_PrimaryMutex.ReleaseMutex();
		}

		internal bool ContainsKey1(TKey1 key)
		{
			_PrimaryMutex.WaitOne();
			bool result = _Index1.ContainsKey(key);
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool ContainsKey2(TKey2 key)
		{
			_PrimaryMutex.WaitOne();
			bool result = _NIndex2.ContainsKey(key);
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool ContainsValue(TValue value)
		{
			bool result;
			if (value == null)
			{
				result = false;
			}
			else
			{
				TKey1 key = method_2<TKey1>(0, value);
				_PrimaryMutex.WaitOne();
				result = _Index1.ContainsKey(key);
				_PrimaryMutex.ReleaseMutex();
			}
			return result;
		}

		internal bool Remove(TKey1 primaryKey)
		{
			_PrimaryMutex.WaitOne();
			bool result;
			if (_Index1.TryGetValue(primaryKey, out var value))
			{
				TKey2 key = method_2<TKey2>(1, value);
				Dictionary<TKey1, TValue> dictionary = _NIndex2[key];
				dictionary.Remove(primaryKey);
				if (dictionary.Count == 0)
				{
					_NIndex2.Remove(key);
				}
				_Index1.Remove(primaryKey);
				result = true;
			}
			else
			{
				result = false;
			}
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool Remove(TValue value)
		{
			bool result;
			if (value == null)
			{
				result = false;
			}
			else
			{
				_PrimaryMutex.WaitOne();
				TKey1 key = method_2<TKey1>(0, value);
				if (_Index1.TryGetValue(key, out value))
				{
					TKey2 key2 = method_2<TKey2>(1, value);
					Dictionary<TKey1, TValue> dictionary = _NIndex2[key2];
					dictionary.Remove(key);
					if (dictionary.Count == 0)
					{
						_NIndex2.Remove(key2);
					}
					_Index1.Remove(key);
					result = true;
				}
				else
				{
					result = false;
				}
				_PrimaryMutex.ReleaseMutex();
			}
			return result;
		}

		internal bool TryGetValue(TKey1 primaryKey, out TValue value)
		{
			_PrimaryMutex.WaitOne();
			bool result = _Index1.TryGetValue(primaryKey, out value);
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool TryGetValuesByKey2(TKey2 key2, out TValue[] value)
		{
			_PrimaryMutex.WaitOne();
			bool result;
			if (_NIndex2.TryGetValue(key2, out var value2))
			{
				value = new TValue[value2.Count - 1 + 1];
				int num = 0;
				foreach (KeyValuePair<TKey1, TValue> item in value2)
				{
					value[num] = item.Value;
					num++;
				}
				result = true;
			}
			else
			{
				value = null;
				result = false;
			}
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal IEnumerator<TValue> GetEnumerator()
		{
			return new ThreadSafeEnumerator(this);
		}

		IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
			return this.GetEnumerator();
		}

		internal IEnumerator GetEnumerator1()
		{
			return new ThreadSafeEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator1
			return this.GetEnumerator1();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!bool_0 && disposing)
			{
				_PrimaryMutex.Close();
			}
			bool_0 = true;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		static MultiKeyedCollection()
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

	public class MultiKeyedCollection<TValue, TKey1, TKey2, TKey3> : IEnumerable, IEnumerable<TValue>, IDisposable where TValue : new()
	{
		public struct ThreadSafeEnumerator : IEnumerator<TValue>, IDisposable, IEnumerator
		{
			private MultiKeyedCollection<TValue, TKey1, TKey2, TKey3> multiKeyedCollection_0;

			private Dictionary<TKey1, TValue>.Enumerator enumerator_0;

			private TValue gparam_0;

			private int int_0;

			public TValue Current => gparam_0;

			object IEnumerator.Current1 => gparam_0;

			internal ThreadSafeEnumerator(MultiKeyedCollection<TValue, TKey1, TKey2, TKey3> multiKeyedCollection_1)
			{
				this = default(ThreadSafeEnumerator);
				multiKeyedCollection_0 = multiKeyedCollection_1;
				enumerator_0 = multiKeyedCollection_1._Index1.GetEnumerator();
				gparam_0 = default(TValue);
			}

			internal bool MoveNext()
			{
				if (gparam_0 == null)
				{
					multiKeyedCollection_0._PrimaryMutex.WaitOne();
					if (enumerator_0.MoveNext())
					{
						gparam_0 = enumerator_0.Current.Value;
						return true;
					}
					multiKeyedCollection_0._PrimaryMutex.ReleaseMutex();
					return false;
				}
				if (!enumerator_0.MoveNext())
				{
					multiKeyedCollection_0._PrimaryMutex.ReleaseMutex();
					return false;
				}
				gparam_0 = enumerator_0.Current.Value;
				return true;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			public void Dispose()
			{
			}

			private void Reset()
			{
				enumerator_0 = multiKeyedCollection_0._Index1.GetEnumerator();
				gparam_0 = default(TValue);
				multiKeyedCollection_0._PrimaryMutex.ReleaseMutex();
			}

			void IEnumerator.Reset()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Reset
				this.Reset();
			}

			static ThreadSafeEnumerator()
			{
				Class72.smethod_20();
			}

			internal static bool smethod_0()
			{
				return true;
			}

			internal static object smethod_1()
			{
				return null;
			}
		}

		protected Type _T;

		protected Mutex _PrimaryMutex;

		protected Dictionary<TKey1, TValue> _Index1;

		protected Dictionary<TKey2, Dictionary<TKey1, TValue>> _NIndex2;

		protected Dictionary<TKey3, Dictionary<TKey1, TValue>> _NIndex3;

		protected FieldInfo[] _Fields;

		protected PropertyInfo[] _Properties;

		protected FieldType[] _FieldTypes;

		protected bool[] _IsMutable;

		protected string[] _FieldNames;

		private bool bool_0;

		private static object object_0;

		public int Count
		{
			get
			{
				_PrimaryMutex.WaitOne();
				int count = _Index1.Count;
				_PrimaryMutex.ReleaseMutex();
				return count;
			}
		}

		public TValue this[TKey1 primaryKey]
		{
			get
			{
				_PrimaryMutex.WaitOne();
				if (!_Index1.TryGetValue(primaryKey, out var value))
				{
					_PrimaryMutex.ReleaseMutex();
					throw new KeyNotFoundException("Primary key not found!");
				}
				_PrimaryMutex.ReleaseMutex();
				return value;
			}
		}

		public TValue[] ItemsByKey2
		{
			get
			{
				_PrimaryMutex.WaitOne();
				if (_NIndex2.TryGetValue(key2, out var value))
				{
					TValue[] array = new TValue[value.Count - 1 + 1];
					int num = 0;
					foreach (KeyValuePair<TKey1, TValue> item in value)
					{
						array[num] = item.Value;
						num++;
					}
					_PrimaryMutex.ReleaseMutex();
					return array;
				}
				_PrimaryMutex.ReleaseMutex();
				throw new KeyNotFoundException("Key 2 not found!");
			}
		}

		public TValue[] ItemsByKey3
		{
			get
			{
				_PrimaryMutex.WaitOne();
				if (_NIndex3.TryGetValue(key3, out var value))
				{
					TValue[] array = new TValue[value.Count - 1 + 1];
					int num = 0;
					foreach (KeyValuePair<TKey1, TValue> item in value)
					{
						array[num] = item.Value;
						num++;
					}
					_PrimaryMutex.ReleaseMutex();
					return array;
				}
				_PrimaryMutex.ReleaseMutex();
				throw new KeyNotFoundException("Key 3 not found!");
			}
		}

		private void method_0(int int_0, string string_0, bool bool_1)
		{
			_Fields[int_0] = _T.GetField(string_0);
			if ((object)_Fields[int_0] == null)
			{
				_Properties[int_0] = _T.GetProperty(string_0);
				if ((object)_Properties[int_0] == null)
				{
					throw new ArgumentException("Field " + (int_0 + 1) + " name is not accessible in the value object");
				}
				if (!_Properties[1].CanRead)
				{
					throw new ArgumentException("Field " + (int_0 + 1) + " is a non-readable property");
				}
				_FieldTypes[1] = FieldType.Property;
				if (bool_1 && !_Properties[int_0].CanWrite)
				{
					throw new ArgumentException("Field " + (int_0 + 1) + " is a readonly property and cannot be mutable");
				}
				_IsMutable[int_0] = bool_1;
			}
			else
			{
				_FieldTypes[int_0] = FieldType.Field;
				_IsMutable[int_0] = bool_1;
			}
			_FieldNames[int_0] = string_0;
			_IsMutable[int_0] = bool_1;
		}

		private void method_1(string string_0)
		{
			_Fields[0] = _T.GetField(string_0);
			if ((object)_Fields[0] != null)
			{
				_FieldTypes[0] = FieldType.Field;
			}
			else
			{
				_Properties[0] = _T.GetProperty(string_0);
				if ((object)_Properties[0] == null)
				{
					throw new ArgumentException("Field 1 name is not accessible in the value object");
				}
				if (!_Properties[0].CanRead)
				{
					throw new ArgumentException("Field 1 is a non-readable property");
				}
				_FieldTypes[0] = FieldType.Property;
			}
			_FieldNames[0] = string_0;
		}

		public MultiKeyedCollection(string Key1FieldName, string Key2FieldName, string Key3FieldName, bool IsKey2Mutable = false, bool IsKey3Mutable = false)
		{
			_T = typeof(TValue);
			_Index1 = new Dictionary<TKey1, TValue>();
			_NIndex2 = new Dictionary<TKey2, Dictionary<TKey1, TValue>>();
			_NIndex3 = new Dictionary<TKey3, Dictionary<TKey1, TValue>>();
			_Fields = new FieldInfo[3];
			_Properties = new PropertyInfo[3];
			_FieldTypes = new FieldType[3];
			_IsMutable = new bool[3];
			_FieldNames = new string[3];
			bool_0 = false;
			method_1(Key1FieldName);
			method_0(1, Key2FieldName, IsKey2Mutable);
			method_0(2, Key3FieldName, IsKey3Mutable);
			_PrimaryMutex = new Mutex(initiallyOwned: true);
			_PrimaryMutex.ReleaseMutex();
		}

		private T method_2<T>(int int_0, TValue gparam_0)
		{
			if (_FieldTypes[int_0] == FieldType.Field)
			{
				return (T)_Fields[int_0].GetValue(gparam_0);
			}
			return (T)_Properties[int_0].GetValue(gparam_0, null);
		}

		private void method_3<T>(int int_0, TValue gparam_0, T gparam_1)
		{
			if (!_IsMutable[int_0])
			{
				throw new ArgumentException("Cannot update an immutable field!");
			}
			if (_FieldTypes[int_0] == FieldType.Field)
			{
				_Fields[int_0].SetValue(gparam_0, gparam_1);
			}
			else
			{
				_Properties[int_0].SetValue(gparam_0, gparam_1, null);
			}
		}

		public void UpdateKey2(TValue obj, TKey2 newKey2)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("Cannot update a null object!");
			}
			_PrimaryMutex.WaitOne();
			TKey1 key = method_2<TKey1>(0, obj);
			if (!_Index1.ContainsKey(key))
			{
				_PrimaryMutex.ReleaseMutex();
				throw new ArgumentException("Object is not part of the collection!");
			}
			TKey2 key2 = method_2<TKey2>(1, obj);
			Dictionary<TKey1, TValue> value = _NIndex2[key2];
			value.Remove(key);
			if (value.Count == 0)
			{
				_NIndex2.Remove(key2);
			}
			method_3(1, obj, newKey2);
			if (_NIndex2.TryGetValue(newKey2, out value))
			{
				value.Add(key, obj);
			}
			else
			{
				value = new Dictionary<TKey1, TValue>();
				value.Add(key, obj);
				_NIndex2.Add(newKey2, value);
			}
			_PrimaryMutex.ReleaseMutex();
		}

		public void UpdateKey3(TValue obj, TKey3 newKey3)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("Cannot update a null object!");
			}
			_PrimaryMutex.WaitOne();
			TKey1 key = method_2<TKey1>(0, obj);
			if (!_Index1.ContainsKey(key))
			{
				_PrimaryMutex.ReleaseMutex();
				throw new ArgumentException("Object is not part of the collection!");
			}
			TKey3 key2 = method_2<TKey3>(2, obj);
			Dictionary<TKey1, TValue> value = _NIndex3[key2];
			value.Remove(key);
			if (value.Count == 0)
			{
				_NIndex3.Remove(key2);
			}
			method_3(2, obj, newKey3);
			if (_NIndex3.TryGetValue(newKey3, out value))
			{
				value.Add(key, obj);
			}
			else
			{
				value = new Dictionary<TKey1, TValue>();
				value.Add(key, obj);
				_NIndex3.Add(newKey3, value);
			}
			_PrimaryMutex.ReleaseMutex();
		}

		public void Add(TValue Value)
		{
			if (Value == null)
			{
				throw new ArgumentNullException("Cannot add a null reference!");
			}
			_PrimaryMutex.WaitOne();
			int num = 0;
			while (true)
			{
				TKey1 key = method_2<TKey1>(0, Value);
				if (_Index1.ContainsKey(key))
				{
					break;
				}
				_Index1.Add(key, Value);
				while (true)
				{
					num++;
					if (num <= 2)
					{
						switch (num)
						{
						case 1:
						{
							TKey2 key3 = method_2<TKey2>(1, Value);
							if (_NIndex2.TryGetValue(key3, out var value2))
							{
								value2.Add(key, Value);
								continue;
							}
							value2 = new Dictionary<TKey1, TValue>();
							value2.Add(key, Value);
							_NIndex2.Add(key3, value2);
							continue;
						}
						case 2:
						{
							TKey3 key2 = method_2<TKey3>(2, Value);
							if (_NIndex3.TryGetValue(key2, out var value))
							{
								value.Add(key, Value);
								continue;
							}
							value = new Dictionary<TKey1, TValue>();
							value.Add(key, Value);
							_NIndex3.Add(key2, value);
							continue;
						}
						default:
							continue;
						case 0:
							break;
						}
						break;
					}
					_PrimaryMutex.ReleaseMutex();
					return;
				}
			}
			_PrimaryMutex.ReleaseMutex();
			throw new ArgumentException("Object with this primary key already exists!");
		}

		public void Clear()
		{
			_PrimaryMutex.WaitOne();
			int num = 0;
			do
			{
				switch (num)
				{
				case 0:
					_Index1.Clear();
					break;
				case 1:
					_NIndex2.Clear();
					break;
				}
				num++;
			}
			while (num <= 2);
			_PrimaryMutex.ReleaseMutex();
		}

		internal bool ContainsKey1(TKey1 key)
		{
			_PrimaryMutex.WaitOne();
			bool result = _Index1.ContainsKey(key);
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool ContainsKey2(TKey2 key)
		{
			_PrimaryMutex.WaitOne();
			bool result = _NIndex2.ContainsKey(key);
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool ContainsKey3(TKey3 key)
		{
			_PrimaryMutex.WaitOne();
			bool result = _NIndex3.ContainsKey(key);
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool ContainsValue(TValue value)
		{
			bool result;
			if (value == null)
			{
				result = false;
			}
			else
			{
				TKey1 key = method_2<TKey1>(0, value);
				_PrimaryMutex.WaitOne();
				result = _Index1.ContainsKey(key);
				_PrimaryMutex.ReleaseMutex();
			}
			return result;
		}

		internal bool Remove(TKey1 primaryKey)
		{
			_PrimaryMutex.WaitOne();
			bool result;
			if (_Index1.TryGetValue(primaryKey, out var value))
			{
				TKey2 key = method_2<TKey2>(1, value);
				Dictionary<TKey1, TValue> dictionary = _NIndex2[key];
				dictionary.Remove(primaryKey);
				if (dictionary.Count == 0)
				{
					_NIndex2.Remove(key);
				}
				TKey3 key2 = method_2<TKey3>(2, value);
				Dictionary<TKey1, TValue> dictionary2 = _NIndex3[key2];
				dictionary2.Remove(primaryKey);
				if (dictionary2.Count == 0)
				{
					_NIndex3.Remove(key2);
				}
				_Index1.Remove(primaryKey);
				result = true;
			}
			else
			{
				result = false;
			}
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool Remove(TValue value)
		{
			bool result;
			if (value == null)
			{
				result = false;
			}
			else
			{
				_PrimaryMutex.WaitOne();
				TKey1 key = method_2<TKey1>(0, value);
				if (_Index1.TryGetValue(key, out value))
				{
					TKey2 key2 = method_2<TKey2>(1, value);
					Dictionary<TKey1, TValue> dictionary = _NIndex2[key2];
					dictionary.Remove(key);
					if (dictionary.Count == 0)
					{
						_NIndex2.Remove(key2);
					}
					TKey3 key3 = method_2<TKey3>(2, value);
					Dictionary<TKey1, TValue> dictionary2 = _NIndex3[key3];
					dictionary2.Remove(key);
					if (dictionary2.Count == 0)
					{
						_NIndex3.Remove(key3);
					}
					_Index1.Remove(key);
					result = true;
				}
				else
				{
					result = false;
				}
				_PrimaryMutex.ReleaseMutex();
			}
			return result;
		}

		internal bool TryGetValue(TKey1 primaryKey, out TValue value)
		{
			_PrimaryMutex.WaitOne();
			bool result = _Index1.TryGetValue(primaryKey, out value);
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool TryGetValuesByKey2(TKey2 key2, out TValue[] value)
		{
			_PrimaryMutex.WaitOne();
			bool result;
			if (_NIndex2.TryGetValue(key2, out var value2))
			{
				value = new TValue[value2.Count - 1 + 1];
				int num = 0;
				foreach (KeyValuePair<TKey1, TValue> item in value2)
				{
					value[num] = item.Value;
					num++;
				}
				result = true;
			}
			else
			{
				value = null;
				result = false;
			}
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal bool TryGetValuesByKey3(TKey3 key3, out TValue[] value)
		{
			_PrimaryMutex.WaitOne();
			bool result;
			if (_NIndex3.TryGetValue(key3, out var value2))
			{
				value = new TValue[value2.Count - 1 + 1];
				int num = 0;
				foreach (KeyValuePair<TKey1, TValue> item in value2)
				{
					value[num] = item.Value;
					num++;
				}
				result = true;
			}
			else
			{
				value = null;
				result = false;
			}
			_PrimaryMutex.ReleaseMutex();
			return result;
		}

		internal IEnumerator<TValue> GetEnumerator()
		{
			return new ThreadSafeEnumerator(this);
		}

		IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
			return this.GetEnumerator();
		}

		internal IEnumerator GetEnumerator1()
		{
			return new ThreadSafeEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator1
			return this.GetEnumerator1();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!bool_0 && disposing)
			{
				_PrimaryMutex.Close();
			}
			bool_0 = true;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		static MultiKeyedCollection()
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

	static MultiKeyModule()
	{
		Class72.smethod_20();
	}
}
