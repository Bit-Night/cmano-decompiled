using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace DotSpatial.Serialization;

public class XmlSerializer
{
	private class Class65
	{
		private readonly List<KeyValuePair<object, XElement>> list_0 = new List<KeyValuePair<object, XElement>>();

		private int int_0;

		public int method_0(object object_0)
		{
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Expected O, but got Unknown
			int result = -1;
			XElement val = (from kvp in list_0
				where kvp.Key == object_0
				select kvp.Value).FirstOrDefault();
			if (val != null)
			{
				XAttribute val2 = val.Attribute(XName.op_Implicit("id"));
				if (val2 != null)
				{
					result = int.Parse(val2.Value, CultureInfo.InvariantCulture);
				}
				else
				{
					((XContainer)val).Add((object)new XAttribute(XName.op_Implicit("id"), (object)int_0.ToString(CultureInfo.InvariantCulture)));
					result = int_0;
					int_0++;
				}
			}
			return result;
		}

		public void Add(object o, XElement element)
		{
			list_0.Add(new KeyValuePair<object, XElement>(o, element));
		}

		[Conditional("DEBUG")]
		private void method_1(object object_0)
		{
			if (list_0.Any((KeyValuePair<object, XElement> kvp) => kvp.Key == object_0))
			{
				throw new InvalidOperationException("Duplicate entry detected");
			}
		}

		public void Clear()
		{
			list_0.Clear();
			int_0 = 0;
		}

		static Class65()
		{
			Class72.smethod_20();
		}
	}

	private readonly object object_0 = new object();

	private int rsBegoUypWY;

	private Dictionary<Type, int> dictionary_0;

	private Class65 cGfeghrIpjb;

	public string Serialize(object value)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		lock (object_0)
		{
			cGfeghrIpjb = new Class65();
			dictionary_0 = new Dictionary<Type, int>();
			XDocument val = new XDocument(new object[1] { method_1("root", null, value) });
			if (val.Root != null)
			{
				((XContainer)val.Root).AddFirst((object)method_8());
			}
			string result = method_0(val);
			vdQegpxjexW();
			return result;
		}
	}

	private void vdQegpxjexW()
	{
		cGfeghrIpjb.Clear();
		cGfeghrIpjb = null;
	}

	private string method_0(XDocument xdocument_0)
	{
		using StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
		xdocument_0.Save((TextWriter)stringWriter);
		stringWriter.Flush();
		return stringWriter.ToString();
	}

	private XElement method_1(string string_0, SerializeAttribute serializeAttribute_0, object object_1, params object[] content)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Expected O, but got Unknown
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Expected O, but got Unknown
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Expected O, but got Unknown
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Expected O, but got Unknown
		if (object_1 != null)
		{
			Type type = object_1.GetType();
			int num = cGfeghrIpjb.method_0(object_1);
			XElement val;
			if (num >= 0)
			{
				val = new XElement(XName.op_Implicit(string_0), new object[2]
				{
					content,
					(object)new XAttribute(XName.op_Implicit("ref"), (object)num.ToString(CultureInfo.InvariantCulture))
				});
				if (serializeAttribute_0 != null && serializeAttribute_0.ConstructorArgumentIndex >= 0)
				{
					((XContainer)val).Add((object)new XAttribute(XName.op_Implicit("arg"), (object)serializeAttribute_0.ConstructorArgumentIndex));
				}
				return val;
			}
			val = method_2(string_0, object_1, serializeAttribute_0, content);
			if (serializeAttribute_0 != null && serializeAttribute_0.Formatter != null)
			{
				XElement obj = val;
				object[] array = method_4(serializeAttribute_0.Formatter, object_1);
				((XContainer)obj).Add(array);
			}
			else if (type.IsPrimitive)
			{
				((XContainer)val).Add((object)new XAttribute(XName.op_Implicit("value"), (object)Convert.ToString(object_1, CultureInfo.InvariantCulture)));
			}
			else if (type.IsEnum)
			{
				((XContainer)val).Add((object)new XAttribute(XName.op_Implicit("value"), (object)object_1.ToString()));
			}
			else if (!(object_1 is string))
			{
				if (typeof(IDictionary).IsAssignableFrom(type))
				{
					method_6(val, (IDictionary)object_1);
				}
				else if (!typeof(IList).IsAssignableFrom(type) && !typeof(ICollection).IsAssignableFrom(type))
				{
					if (!(type == typeof(DateTime)))
					{
						if (type == typeof(Color))
						{
							((XContainer)val).Add((object)new XAttribute(XName.op_Implicit("value"), (object)ColorTranslator.ToHtml((Color)object_1)));
						}
						else if (!(type == typeof(PointF)))
						{
							SerializationMap serializationMap = SerializationMap.FromType(object_1.GetType());
							method_5(val, serializationMap.Members, object_1);
						}
						else
						{
							PointF pointF = (PointF)object_1;
							((XContainer)val).Add((object)new XAttribute(XName.op_Implicit("value"), (object)XmlHelper.EscapeInvalidCharacters(pointF.X + "|" + pointF.Y)));
						}
					}
					else
					{
						((XContainer)val).Add((object)new XAttribute(XName.op_Implicit("value"), (object)Convert.ToString(object_1, CultureInfo.InvariantCulture)));
					}
				}
				else
				{
					method_7(val, (IEnumerable)object_1);
				}
			}
			else
			{
				((XContainer)val).Add((object)new XAttribute(XName.op_Implicit("value"), (object)XmlHelper.EscapeInvalidCharacters((string)object_1)));
			}
			return val;
		}
		throw new ArgumentNullException("value");
	}

	private XElement method_2(string string_0, object object_1, SerializeAttribute serializeAttribute_0, params object[] content)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		Type type = object_1.GetType();
		XElement val = new XElement(XName.op_Implicit(string_0), content);
		((XContainer)val).Add((object)new XAttribute(XName.op_Implicit("type"), (object)method_3(type).ToString()));
		if (serializeAttribute_0 != null && serializeAttribute_0.ConstructorArgumentIndex >= 0)
		{
			((XContainer)val).Add((object)new XAttribute(XName.op_Implicit("arg"), (object)serializeAttribute_0.ConstructorArgumentIndex));
		}
		if (!type.IsValueType && !type.Equals(typeof(string)))
		{
			cGfeghrIpjb.Add(object_1, val);
		}
		return val;
	}

	private int method_3(Type type_0)
	{
		if (!dictionary_0.TryGetValue(type_0, out var value))
		{
			value = rsBegoUypWY;
			dictionary_0[type_0] = value;
			rsBegoUypWY++;
		}
		return value;
	}

	private XAttribute[] method_4(Type type_0, object object_1)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		SerializationFormatter serializationFormatter = (SerializationFormatter)type_0.GetConstructor(Type.EmptyTypes).Invoke(null);
		return (XAttribute[])(object)new XAttribute[2]
		{
			new XAttribute(XName.op_Implicit("value"), (object)XmlHelper.EscapeInvalidCharacters(serializationFormatter.ToString(object_1))),
			new XAttribute(XName.op_Implicit("formatter"), (object)method_3(type_0).ToString())
		};
	}

	private void method_5(XElement xelement_0, IEnumerable<SerializationMapEntry> ienumerable_0, object object_1)
	{
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		foreach (SerializationMapEntry item in ienumerable_0)
		{
			object value;
			if (item.Member is PropertyInfo)
			{
				value = ((PropertyInfo)item.Member).GetValue(object_1, null);
			}
			else
			{
				if (!(item.Member is FieldInfo))
				{
					throw new InvalidOperationException("Only fields and properties are supported.");
				}
				value = ((FieldInfo)item.Member).GetValue(object_1);
			}
			if (value != null)
			{
				string text = ((item.Attribute == null || string.IsNullOrEmpty(item.Attribute.Name)) ? item.Member.Name : item.Attribute.Name);
				XElement val = method_1("member", item.Attribute, value, (object)new XAttribute(XName.op_Implicit("name"), (object)text));
				((XContainer)xelement_0).Add((object)val);
			}
		}
	}

	private void method_6(XElement xelement_0, IDictionary idictionary_0)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		foreach (DictionaryEntry item in idictionary_0)
		{
			XElement val = new XElement(XName.op_Implicit("entry"), new object[2]
			{
				method_1("key", null, item.Key),
				method_1("value", null, item.Value)
			});
			((XContainer)xelement_0).Add((object)val);
		}
	}

	private void method_7(XElement xelement_0, IEnumerable ienumerable_0)
	{
		foreach (object item in ienumerable_0)
		{
			if (item != null)
			{
				((XContainer)xelement_0).Add((object)method_1("item", null, item));
			}
		}
	}

	private XElement method_8()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		return new XElement(XName.op_Implicit("types"), (object)((IEnumerable<KeyValuePair<Type, int>>)dictionary_0).Select((Func<KeyValuePair<Type, int>, XElement>)((KeyValuePair<Type, int> keyValuePair_0) => new XElement(XName.op_Implicit("item"), new object[2]
		{
			(object)new XAttribute(XName.op_Implicit("key"), (object)keyValuePair_0.Value),
			(object)new XAttribute(XName.op_Implicit("value"), (object)method_9(keyValuePair_0.Key))
		}))));
	}

	private string method_9(Type type_0)
	{
		return Regex.Replace(type_0.AssemblyQualifiedName, ", Version=\\S+ Culture=\\S+ PublicKeyToken=null", string.Empty);
	}

	[CompilerGenerated]
	private XElement method_10(KeyValuePair<Type, int> keyValuePair_0)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		return new XElement(XName.op_Implicit("item"), new object[2]
		{
			(object)new XAttribute(XName.op_Implicit("key"), (object)keyValuePair_0.Value),
			(object)new XAttribute(XName.op_Implicit("value"), (object)method_9(keyValuePair_0.Key))
		});
	}

	static XmlSerializer()
	{
		Class72.smethod_20();
	}
}
