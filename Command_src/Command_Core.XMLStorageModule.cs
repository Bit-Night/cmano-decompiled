using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class XMLStorageModule
{
	public sealed class PersistentPointer
	{
		public string ObjectTypeID;

		public int ID;

		public override int GetHashCode()
		{
			return ObjectTypeID.GetHashCode() ^ ID;
		}

		static PersistentPointer()
		{
			Class72.smethod_20();
		}
	}

	public sealed class TTailRecursion
	{
		public long Oid;

		public object Obj;

		public TTailRecursion(long Oid, ref object Obj)
		{
			this.Oid = Oid;
			this.Obj = RuntimeHelpers.GetObjectValue(Obj);
		}

		static TTailRecursion()
		{
			Class72.smethod_20();
		}
	}

	[Serializable]
	public abstract class TestClassP
	{
		[NonSerialized]
		public bool IgnoreField;

		public double NonIgnoredField;

		protected TestClassP()
		{
			NonIgnoredField = 15.093;
		}

		static TestClassP()
		{
			Class72.smethod_20();
		}
	}

	[Serializable]
	public sealed class TestClass : TestClassP
	{
		public double NonIgnoredField2;

		public TestClass()
		{
			NonIgnoredField2 = 16.2;
		}

		static TestClass()
		{
			Class72.smethod_20();
		}
	}

	private static ObjectIDGenerator objectIDGenerator_0;

	private static Stack<TTailRecursion> stack_0;

	internal static bool SaveObjectToXML(string FileName, ref object Obj)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		XmlWriter xmlWriter_ = null;
		XmlWriterSettings val = new XmlWriterSettings();
		bool result;
		try
		{
			val.Indent = true;
			val.IndentChars = "\t";
			objectIDGenerator_0 = new ObjectIDGenerator();
			xmlWriter_ = XmlWriter.Create(FileName, val);
			xmlWriter_.WriteStartDocument();
			xmlWriter_.WriteStartElement("root");
			stack_0 = new Stack<TTailRecursion>();
			xmlWriter_.WriteStartElement("content");
			smethod_2(ref xmlWriter_, (Array)RuntimeHelpers.GetObjectValue(Obj), 0, bool_0: true);
			xmlWriter_.WriteEndElement();
			xmlWriter_.WriteStartElement("objects");
			while (stack_0.Count > 0)
			{
				TTailRecursion tTailRecursion = stack_0.Pop();
				smethod_1(ref xmlWriter_, RuntimeHelpers.GetObjectValue(tTailRecursion.Obj), tTailRecursion.Oid, 0, bool_0: false);
			}
			xmlWriter_.WriteEndElement();
			xmlWriter_.Close();
			result = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ex2?.Data.Add("Error at 200065", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			xmlWriter_.WriteEndElement();
			xmlWriter_.Close();
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static void smethod_0(ref XmlWriter xmlWriter_0, object object_0, int int_0, bool bool_0)
	{
		string text = Strings.StrDup(int_0, "\t");
		xmlWriter_0.WriteWhitespace("\r\n");
		xmlWriter_0.WriteWhitespace(text);
		if (object_0 != null)
		{
			Type type = object_0.GetType();
			xmlWriter_0.WriteStartElement(type.Name);
			if (object.Equals(type, typeof(double)))
			{
				CultureInfo cultureInfo = new CultureInfo("en-US");
				xmlWriter_0.WriteString(Conversions.ToDouble(object_0).ToString(cultureInfo));
			}
			else if (!object.Equals(type, typeof(float)))
			{
				if (!object.Equals(type, typeof(int)))
				{
					if (object.Equals(type, typeof(DateTime)))
					{
						CultureInfo cultureInfo2 = new CultureInfo("en-US");
						_ = cultureInfo2.DateTimeFormat;
						xmlWriter_0.WriteString(Conversions.ToDate(object_0).ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff'Z'", cultureInfo2));
					}
					else
					{
						xmlWriter_0.WriteString(object_0.ToString());
					}
				}
				else
				{
					CultureInfo cultureInfo3 = new CultureInfo("en-US");
					xmlWriter_0.WriteString(Conversions.ToSingle(object_0).ToString(cultureInfo3));
				}
			}
			else
			{
				CultureInfo cultureInfo4 = new CultureInfo("en-US");
				xmlWriter_0.WriteString(Conversions.ToSingle(object_0).ToString(cultureInfo4));
			}
			xmlWriter_0.WriteEndElement();
		}
		else
		{
			xmlWriter_0.WriteElementString("NULL", "");
		}
	}

	private static void smethod_1(ref XmlWriter xmlWriter_0, object object_0, long long_0, int int_0, bool bool_0)
	{
		Type type = object_0.GetType();
		xmlWriter_0.WriteStartElement(type.Name);
		xmlWriter_0.WriteAttributeString("oid", long_0.ToString());
		FieldInfo[] fields = type.GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			object[] customAttributes = fieldInfo.GetCustomAttributes(typeof(NonSerializedAttribute), inherit: true);
			if (customAttributes == null || customAttributes.Length <= 0)
			{
				string text = fieldInfo.ToString();
				int num = text.IndexOf(' ');
				text = text.Substring(num + 1, text.Length - num - 1);
				xmlWriter_0.WriteStartElement(text);
				smethod_2(ref xmlWriter_0, (Array)RuntimeHelpers.GetObjectValue(fieldInfo.GetValue(RuntimeHelpers.GetObjectValue(object_0))), int_0 + 3, bool_0: true);
				xmlWriter_0.WriteWhitespace("\r\n" + Strings.StrDup(int_0 + 3, "\t"));
				xmlWriter_0.WriteEndElement();
			}
		}
		PropertyInfo[] properties = type.GetProperties();
		foreach (PropertyInfo propertyInfo in properties)
		{
			object[] customAttributes2 = propertyInfo.GetCustomAttributes(typeof(NonSerializedAttribute), inherit: true);
			if (customAttributes2 != null && customAttributes2.Length > 0)
			{
				continue;
			}
			string text2 = propertyInfo.ToString();
			int num2 = text2.IndexOf(' ');
			if (propertyInfo.GetIndexParameters().Length > 0)
			{
				continue;
			}
			text2 = text2.Substring(num2 + 1, text2.Length - num2 - 1);
			if (!propertyInfo.PropertyType.IsArray)
			{
				xmlWriter_0.WriteStartElement(text2);
				smethod_2(ref xmlWriter_0, (Array)RuntimeHelpers.GetObjectValue(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(object_0), null)), int_0 + 3, bool_0: true);
				if (bool_0)
				{
					xmlWriter_0.WriteWhitespace("\r\n" + Strings.StrDup(int_0 + 1, "\t"));
				}
				else
				{
					xmlWriter_0.WriteWhitespace("\r\n" + Strings.StrDup(int_0 + 3, "\t"));
				}
				xmlWriter_0.WriteEndElement();
			}
			else
			{
				Array array_ = (Array)propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(object_0), null);
				smethod_2(ref xmlWriter_0, array_, int_0 + 3, bool_0: true);
				xmlWriter_0.WriteWhitespace("\r\n" + Strings.StrDup(int_0 + 3, "\t"));
			}
		}
		xmlWriter_0.WriteEndElement();
		xmlWriter_0.Flush();
	}

	private unsafe static void smethod_2(ref XmlWriter xmlWriter_0, Array array_0, int int_0, bool bool_0)
	{
		string text = Strings.StrDup(int_0, "\t");
		if (!bool_0)
		{
			xmlWriter_0.WriteWhitespace("\r\n" + text);
		}
		if (array_0 == null)
		{
			xmlWriter_0.WriteElementString("NULL", "");
			return;
		}
		Type type = array_0.GetType();
		if (!type.IsArray)
		{
			if (!(type.IsValueType | ((object)type == typeof(string))))
			{
				if (type.IsPointer | type.IsByRef | type.IsClass)
				{
					bool firstTime;
					long id = objectIDGenerator_0.GetId(RuntimeHelpers.GetObjectValue(array_0), out firstTime);
					xmlWriter_0.WriteStartElement(array_0.GetType().Name);
					xmlWriter_0.WriteAttributeString("ref", id.ToString());
					xmlWriter_0.WriteEndElement();
					if (firstTime)
					{
						stack_0.Push(new TTailRecursion(id, ref *(object*)(&array_0)));
					}
				}
			}
			else
			{
				smethod_0(ref xmlWriter_0, RuntimeHelpers.GetObjectValue(array_0), int_0 + 1, bool_0: false);
			}
		}
		else
		{
			Type elementType = type.GetElementType();
			xmlWriter_0.WriteStartElement("Array");
			xmlWriter_0.WriteAttributeString("type", elementType.Name);
			Array array = array_0;
			xmlWriter_0.WriteAttributeString("size", array.Length.ToString());
			foreach (object item in array)
			{
				object Obj = RuntimeHelpers.GetObjectValue(item);
				if (!(Obj.GetType().IsValueType | ((object)Obj.GetType() == typeof(string))))
				{
					bool firstTime2;
					long id2 = objectIDGenerator_0.GetId(RuntimeHelpers.GetObjectValue(Obj), out firstTime2);
					xmlWriter_0.WriteStartElement(Obj.GetType().Name);
					xmlWriter_0.WriteAttributeString("ref", id2.ToString());
					xmlWriter_0.WriteEndElement();
					if (firstTime2)
					{
						stack_0.Push(new TTailRecursion(id2, ref Obj));
					}
				}
				else
				{
					smethod_0(ref xmlWriter_0, RuntimeHelpers.GetObjectValue(Obj), int_0 + 3, bool_0: true);
				}
			}
			xmlWriter_0.WriteWhitespace("\r\n" + text + "\t\t");
			xmlWriter_0.WriteEndElement();
		}
		xmlWriter_0.Flush();
	}

	public static void LoadObjectFromXML(ref object Obj, string Filename)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Invalid comparison between Unknown and I4
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Invalid comparison between Unknown and I4
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Invalid comparison between Unknown and I4
		try
		{
			TreeNode val = null;
			TreeNode val2 = null;
			new Dictionary<long, object>();
			XmlReaderSettings val3 = new XmlReaderSettings();
			val3.ProhibitDtd = true;
			val3.XmlResolver = null;
			val3.IgnoreComments = true;
			val3.IgnoreProcessingInstructions = true;
			TextReader textReader = new StreamReader(Filename);
			XmlReader val4 = XmlReader.Create(textReader, val3);
			val4.MoveToContent();
			while (val4.Read())
			{
				XmlNodeType nodeType = val4.NodeType;
				if ((int)nodeType != 1)
				{
					if ((int)nodeType != 3)
					{
						if ((int)nodeType == 15)
						{
							val = val.Parent;
						}
					}
					else
					{
						val2.ToolTipText = val4.Value;
					}
					continue;
				}
				val2 = new TreeNode(val4.Name);
				if (val4.HasAttributes)
				{
					while (val4.MoveToNextAttribute())
					{
					}
					val4.MoveToElement();
				}
				val.Nodes.Add(val2);
				val = (val4.IsEmptyElement ? val : val2);
			}
			val4.Close();
			textReader.Close();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	internal static object ReadNode(ref XmlReader XR)
	{
		XR.ReadElementContentAsString();
		XR.GetAttribute("ref");
		return null;
	}

	static XMLStorageModule()
	{
		Class72.smethod_20();
	}
}
