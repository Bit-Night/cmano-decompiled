using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class DictionaryStorage
{
	public static void smethod_0<TKey, TValue>(XmlWriter XW, Dictionary<TKey, TValue> Dict)
	{
		try
		{
			CultureInfo cultureInfo = new CultureInfo("en-US");
			XW.WriteStartElement("Dictionary");
			XW.WriteAttributeString("keyType", typeof(TKey).Name);
			XW.WriteAttributeString("valueType", typeof(TValue).Name);
			string name = typeof(TValue).Name;
			foreach (KeyValuePair<TKey, TValue> item in Dict)
			{
				XW.WriteStartElement(name);
				if ((object)typeof(TKey) == typeof(double))
				{
					XW.WriteAttributeString("Key", Conversions.ToDouble((object)item.Key).ToString(cultureInfo));
				}
				else
				{
					XW.WriteAttributeString("Key", item.Key.ToString());
				}
				if ((object)typeof(TValue) == typeof(double))
				{
					XW.WriteString(Conversions.ToDouble((object)item.Value).ToString(cultureInfo));
				}
				else
				{
					XW.WriteString(item.Value.ToString());
				}
				XW.WriteEndElement();
			}
			XW.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200084", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new Exception("Îøèáêà ñîõðàíåíèÿ àññîöèàòèâíîãî ìàññèâà â ôàéë");
		}
	}

	public static void SaveDictionaryToXML_2<TKey, TValue>(XmlWriter XW, Dictionary<TKey, TValue> Dict) where TValue : IXmlSerializable
	{
		try
		{
			XW.WriteStartElement("Dictionary");
			XW.WriteAttributeString("keyType", typeof(TKey).Name);
			XW.WriteAttributeString("valueType", typeof(TValue).Name);
			string name = typeof(TValue).Name;
			foreach (KeyValuePair<TKey, TValue> item in Dict)
			{
				XW.WriteStartElement(name);
				XW.WriteAttributeString("Key", item.Key.ToString());
				((IXmlSerializable)item.Value/*cast due to .constrained prefix*/).WriteXml(XW);
				XW.WriteEndElement();
			}
			XW.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add(Class72.smethod_14(1648302), ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new Exception("Îøèáêà ñîõðàíåíèÿ àññîöèàòèâíîãî ìàññèâà â ôàéë");
		}
	}

	public static void LoadDictionaryFromXML<TKey, TValue>(XmlReader XR, ref Dictionary<TKey, TValue> Dict)
	{
		try
		{
			if (!XR.ReadToFollowing("Dictionary"))
			{
				throw new Exception("dictionary node not found");
			}
			if (Operators.CompareString(XR.GetAttribute("keyType"), typeof(TKey).Name, false) != 0)
			{
				throw new Exception("key types don't match");
			}
			string name = typeof(TValue).Name;
			if (Operators.CompareString(XR.GetAttribute("valueType"), typeof(TValue).Name, false) != 0)
			{
				throw new Exception("value types don't match");
			}
			Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
			if (XR.IsEmptyElement)
			{
				if (Dict == null)
				{
					Dict = new Dictionary<TKey, TValue>();
				}
				Dict.Clear();
				return;
			}
			TKey Key = default(TKey);
			TValue Value = default(TValue);
			while (XR.ReadToFollowing(name))
			{
				smethod_1(XR, ref Key, ref Value);
				dictionary.Add((TKey)(object)Key, Value);
			}
			if (Dict == null)
			{
				Dict = new Dictionary<TKey, TValue>();
			}
			Dict.Clear();
			foreach (KeyValuePair<TKey, TValue> item in dictionary)
			{
				Dict.Add(item.Key, item.Value);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200086", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new Exception("Îøèáêà çàãðóçêè àññîöèàòèâíîãî ìàññèâà èç ôàéëà");
		}
	}

	public static void smethod_1<TKey, TValue>(XmlReader reader, ref TKey Key, ref TValue Value)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		CultureInfo provider = new CultureInfo("en-US");
		string attribute = reader.GetAttribute("Key");
		if ((object)typeof(TKey) == typeof(double))
		{
			Key = (TKey)(object)double.Parse(attribute, provider);
		}
		else
		{
			Key = (TKey)(object)attribute;
		}
		reader.MoveToContent();
		if ((object)typeof(TValue) == typeof(double))
		{
			Value = (TValue)(object)double.Parse(reader.ReadString(), provider);
		}
		else
		{
			Value = (TValue)(object)reader.ReadString();
		}
	}

	public static void KeyValuePairReadXML_2<TKey, TValue>(XmlReader reader, ref TKey Key, ref TValue Value) where TValue : IXmlSerializable, new()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		string attribute = reader.GetAttribute("Key");
		Key = (TKey)(object)attribute;
		TValue val = new TValue();
		reader.MoveToContent();
		((IXmlSerializable)val/*cast due to .constrained prefix*/).ReadXml(reader);
		Value = val;
	}

	public static void LoadDictionaryFromXML_2<TKey, TValue>(XmlReader XR, ref Dictionary<TKey, TValue> Dict) where TValue : IXmlSerializable, new()
	{
		try
		{
			if (!XR.ReadToFollowing("Dictionary"))
			{
				throw new Exception("dictionary node not found");
			}
			if (Operators.CompareString(XR.GetAttribute("keyType"), typeof(TKey).Name, false) != 0)
			{
				throw new Exception("key types don't match");
			}
			string name = typeof(TValue).Name;
			if (Operators.CompareString(XR.GetAttribute("valueType"), typeof(TValue).Name, false) != 0)
			{
				throw new Exception("value types don't match");
			}
			Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
			if (XR.IsEmptyElement)
			{
				if (Dict == null)
				{
					Dict = new Dictionary<TKey, TValue>();
				}
				Dict.Clear();
				return;
			}
			TKey Key = default(TKey);
			TValue Value = default(TValue);
			while (XR.ReadToFollowing(name))
			{
				KeyValuePairReadXML_2(XR, ref Key, ref Value);
				dictionary.Add((TKey)(object)Key, Value);
			}
			if (Dict == null)
			{
				Dict = new Dictionary<TKey, TValue>();
			}
			Dict.Clear();
			foreach (KeyValuePair<TKey, TValue> item in dictionary)
			{
				Dict.Add(item.Key, item.Value);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add(Class72.smethod_14(1648618), ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new Exception("Îøèáêà çàãðóçêè àññîöèàòèâíîãî ìàññèâà èç ôàéëà");
		}
	}

	static DictionaryStorage()
	{
		Class72.smethod_20();
	}
}
