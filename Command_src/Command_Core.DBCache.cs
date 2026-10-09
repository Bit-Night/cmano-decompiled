using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class DBCache
{
	public interface I_CacheableRow
	{
		void setValuesFromDataTableTyped(DataTableTyped sourceDataTable, DtrRow sourceRow);
	}

	private static ConcurrentDictionary<int, ConcurrentDictionary<int, object>> concurrentDictionary_0;

	private static ConcurrentDictionary<int, ConcurrentDictionary<int, DataTable>> concurrentDictionary_1;

	private static ConcurrentDictionary<int, ConcurrentDictionary<int, DataTableTyped>> concurrentDictionary_2;

	private static ConcurrentDictionary<int, ConcurrentDictionary<int, string>> concurrentDictionary_3;

	static DBCache()
	{
		Class72.smethod_20();
		concurrentDictionary_0 = new ConcurrentDictionary<int, ConcurrentDictionary<int, object>>();
		concurrentDictionary_1 = new ConcurrentDictionary<int, ConcurrentDictionary<int, DataTable>>();
		concurrentDictionary_2 = new ConcurrentDictionary<int, ConcurrentDictionary<int, DataTableTyped>>();
		concurrentDictionary_3 = new ConcurrentDictionary<int, ConcurrentDictionary<int, string>>();
	}

	public static void ClearCache()
	{
		concurrentDictionary_0.Clear();
		concurrentDictionary_1.Clear();
		concurrentDictionary_2.Clear();
		concurrentDictionary_3.Clear();
	}

	public static DataTable GetDatatable(SQLiteHelper theHelper, string theQuery)
	{
		DataTable result = default(DataTable);
		try
		{
			ConcurrentDictionary<int, DataTable> value = null;
			int hashCode = theHelper.theConnection.GetHashCode();
			if (!concurrentDictionary_1.TryGetValue(hashCode, out value))
			{
				value = new ConcurrentDictionary<int, DataTable>();
				concurrentDictionary_1.TryAdd(hashCode, value);
			}
			DataTable value2 = null;
			int hashCode2 = theQuery.GetHashCode();
			if (!value.TryGetValue(hashCode2, out value2))
			{
				value2 = theHelper.ExecuteDataTable(theQuery);
				value.TryAdd(hashCode2, value2);
			}
			result = value2;
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static DataTableTyped GetDatatableTyped(SQLiteHelper theHelper, string theQuery, bool StoreToCache = true)
	{
		DataTableTyped value = null;
		DataTableTyped result = default(DataTableTyped);
		try
		{
			if (StoreToCache)
			{
				ConcurrentDictionary<int, DataTableTyped> value2 = null;
				int hashCode = theHelper.theConnection.GetHashCode();
				if (!concurrentDictionary_2.TryGetValue(hashCode, out value2))
				{
					value2 = new ConcurrentDictionary<int, DataTableTyped>();
					concurrentDictionary_2.TryAdd(hashCode, value2);
				}
				int hashCode2 = theQuery.GetHashCode();
				if (!value2.TryGetValue(hashCode2, out value))
				{
					value = theHelper.ExecuteDataTableTyped(theQuery);
					value2.TryAdd(hashCode2, value);
				}
			}
			else
			{
				value = theHelper.ExecuteDataTableTyped(theQuery);
			}
			result = value;
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (theHelper != null && (theHelper.theConnection == null || theHelper.theConnection.State != ConnectionState.Open))
			{
				throw;
			}
			theHelper.CloseConnection();
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string GetScalar(SQLiteHelper theHelper, string theQuery)
	{
		string result = default(string);
		try
		{
			if (!string.IsNullOrEmpty(theQuery))
			{
				int hashCode = theHelper.theConnection.GetHashCode();
				if (!concurrentDictionary_3.TryGetValue(hashCode, out var value))
				{
					value = new ConcurrentDictionary<int, string>();
					concurrentDictionary_3.TryAdd(hashCode, value);
				}
				int hashCode2 = theQuery.GetHashCode();
				if (!value.TryGetValue(hashCode2, out var value2))
				{
					value2 = theHelper.ExecuteScalar(theQuery);
					if (!string.IsNullOrEmpty(value2))
					{
						value.TryAdd(hashCode2, value2);
					}
				}
				result = value2;
			}
			else if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ex2?.Data.Add("Error at 200083", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			string value2 = theHelper.ExecuteScalar(theQuery);
			result = value2;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static object GetCustomObject(SQLiteHelper theHelper, string theQuery)
	{
		ConcurrentDictionary<int, object> value = null;
		int hashCode = theHelper.theConnection.GetHashCode();
		if (!concurrentDictionary_0.TryGetValue(hashCode, out value))
		{
			value = new ConcurrentDictionary<int, object>();
			concurrentDictionary_0.TryAdd(hashCode, value);
		}
		int hashCode2 = theQuery.GetHashCode();
		if (value.TryGetValue(hashCode2, out var value2))
		{
			return value2;
		}
		return null;
	}

	public static void SetCustomObject(SQLiteHelper theHelper, string theKey, object theResult)
	{
		ConcurrentDictionary<int, object> value = null;
		int hashCode = theHelper.theConnection.GetHashCode();
		if (!concurrentDictionary_0.TryGetValue(hashCode, out value))
		{
			value = new ConcurrentDictionary<int, object>();
			concurrentDictionary_0.TryAdd(hashCode, value);
		}
		value.TryAdd(theKey.GetHashCode(), RuntimeHelpers.GetObjectValue(theResult));
	}

	public static string GetString(SQLiteHelper theHelper, string theQuery)
	{
		ConcurrentDictionary<int, object> value = null;
		int hashCode = theHelper.theConnection.GetHashCode();
		if (!concurrentDictionary_0.TryGetValue(hashCode, out value))
		{
			value = new ConcurrentDictionary<int, object>();
			concurrentDictionary_0.TryAdd(hashCode, value);
		}
		int hashCode2 = theQuery.GetHashCode();
		if (value.ContainsKey(hashCode2))
		{
			return Conversions.ToString(value[hashCode2]);
		}
		return null;
	}

	public static void SetString(SQLiteHelper theHelper, string theKey, string theResult)
	{
		ConcurrentDictionary<int, object> value = null;
		int hashCode = theHelper.theConnection.GetHashCode();
		if (!concurrentDictionary_0.TryGetValue(hashCode, out value))
		{
			value = new ConcurrentDictionary<int, object>();
			concurrentDictionary_0.TryAdd(hashCode, value);
		}
		value.TryAdd(theKey.GetHashCode(), theResult);
	}

	public static void SetValueIfDataTableHasFieldOfCorrectType<T>(DataTableTyped sourceDataTable, DtrRow sourceRow, ref T destination, string fieldName)
	{
		if (!sourceDataTable.Columns.Contains(fieldName))
		{
			return;
		}
		if (sourceRow[fieldName] is T)
		{
			destination = Conversion.CTypeDynamic<T>(RuntimeHelpers.GetObjectValue(sourceRow[fieldName]));
		}
		else
		{
			if (!Debugger.IsAttached)
			{
				return;
			}
			switch (fieldName)
			{
			case "MastHeight":
			case "Weight":
			case "BurnoutWeight":
				if ((Operators.CompareString(fieldName, "MastHeight", false) != 0 || !(sourceRow[fieldName] is double)) && (Operators.CompareString(fieldName, "Weight", false) != 0 || !(sourceRow[fieldName] is long)) && (Operators.CompareString(fieldName, "BurnoutWeight", false) != 0 || !(sourceRow[fieldName] is long)))
				{
					Debugger.Break();
				}
				break;
			}
			if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(sourceRow[fieldName])))
			{
				return;
			}
			try
			{
				destination = Conversion.CTypeDynamic<T>(RuntimeHelpers.GetObjectValue(sourceRow[fieldName]));
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public static List<T> BuildCacheableQueryResult<T>(SQLiteHelper theHelper, string theQuery, bool StoreToCache = true) where T : struct, I_CacheableRow
	{
		DataTableTyped datatableTyped = GetDatatableTyped(theHelper, theQuery, StoreToCache: false);
		List<T> list = new List<T>();
		foreach (DtrRow row in datatableTyped.Rows)
		{
			T item = new T();
			item.setValuesFromDataTableTyped(datatableTyped, row);
			list.Add(item);
		}
		if (StoreToCache)
		{
			SetCustomObject(theHelper, theQuery, list);
		}
		return list;
	}

	public static List<T> GetOrBuildCachedQueryResult<T>(SQLiteHelper theHelper, string theQuery, bool StoreToCache = true) where T : struct, I_CacheableRow
	{
		try
		{
			object objectValue = RuntimeHelpers.GetObjectValue(GetCustomObject(theHelper, theQuery));
			return (objectValue == null) ? BuildCacheableQueryResult<T>(theHelper, theQuery) : ((List<T>)objectValue);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return null;
	}

	public static List<T> GetOrBuildCachedSingleFieldQueryResult<T>(SQLiteHelper theHelper, string theQuery, string fieldName, bool StoreToCache = true)
	{
		try
		{
			object objectValue = RuntimeHelpers.GetObjectValue(GetCustomObject(theHelper, theQuery));
			if (objectValue != null)
			{
				return (List<T>)objectValue;
			}
			List<T> list = new List<T>();
			DataTableTyped datatableTyped = GetDatatableTyped(theHelper, theQuery, StoreToCache: false);
			T destination = default(T);
			foreach (DtrRow row in datatableTyped.Rows)
			{
				SetValueIfDataTableHasFieldOfCorrectType(datatableTyped, row, ref destination, fieldName);
				list.Add(destination);
			}
			if (StoreToCache)
			{
				SetCustomObject(theHelper, theQuery, list);
			}
			return list;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return null;
	}
}
