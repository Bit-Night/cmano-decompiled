using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace DotSpatial.Serialization;

public class XmlDeserializer
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public AssemblyName gqHeIcEiaTH;

		internal bool method_0(Assembly z)
		{
			return z.FullName == gqHeIcEiaTH.FullName;
		}

		static <>c__DisplayClass5_0()
		{
			Class72.smethod_20();
		}
	}

	private Dictionary<string, object> dictionary_0;

	private Dictionary<string, Type> dictionary_1;

	public T Deserialize<T>(string xml)
	{
		if (xml == null)
		{
			throw new ArgumentNullException("xml");
		}
		return method_0(default(T), xml, bool_0: false);
	}

	public void Deserialize<T>(T existingObject, string xml)
	{
		if (xml == null)
		{
			throw new ArgumentNullException("xml");
		}
		if (!typeof(T).IsValueType && existingObject == null)
		{
			throw new ArgumentNullException("existingObject");
		}
		method_0(existingObject, xml, bool_0: true);
	}

	private T method_0<T>(T gparam_0, string string_0, bool bool_0)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		dictionary_0 = new Dictionary<string, object>();
		try
		{
			using StringReader stringReader = new StringReader(string_0);
			XElement root = XDocument.Load((TextReader)stringReader).Root;
			if (root == null)
			{
				throw new XmlException("Could not find a root XML element.");
			}
			dictionary_1 = Monegyrjnji((XContainer)(object)root);
			if (bool_0)
			{
				method_1(root, gparam_0, bool_0: true);
				return gparam_0;
			}
			return (T)gDsegegkxPj(root, null);
		}
		finally
		{
			dictionary_0.Clear();
			if (dictionary_1 != null)
			{
				dictionary_1.Clear();
				dictionary_1 = null;
			}
		}
	}

	private static Dictionary<string, Type> Monegyrjnji(XContainer xcontainer_0)
	{
		Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
		TypeNameManager typeNameManager = new TypeNameManager();
		foreach (XElement item in Extensions.Elements<XElement>(xcontainer_0.Elements(XName.op_Implicit("types")), XName.op_Implicit("item")))
		{
			XAttribute val = item.Attribute(XName.op_Implicit("key"));
			XAttribute val2 = item.Attribute(XName.op_Implicit("value"));
			if (val == null || val2 == null)
			{
				continue;
			}
			Type type;
			try
			{
				type = Type.GetType(val2.Value);
				if (type == null)
				{
					type = Type.GetType(val2.Value, delegate(AssemblyName name)
					{
						<>c__DisplayClass5_0 <>c__DisplayClass5_ = new <>c__DisplayClass5_0();
						<>c__DisplayClass5_.gqHeIcEiaTH = name;
						return AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(<>c__DisplayClass5_.method_0);
					}, null);
				}
			}
			catch (FileLoadException)
			{
				type = Type.GetType(typeNameManager.UpdateTypename(val2.Value));
			}
			dictionary.Add(val.Value, type);
		}
		return dictionary;
	}

	private object gDsegegkxPj(XElement xelement_0, object object_0)
	{
		XAttribute val = xelement_0.Attribute(XName.op_Implicit("ref"));
		if (val != null)
		{
			return dictionary_0[val.Value];
		}
		object obj = method_5(xelement_0);
		if (obj != null)
		{
			return obj;
		}
		Type type = method_6(xelement_0);
		string text = BpLegPliiIt(xelement_0);
		if (!(type == null))
		{
			if (!type.IsPrimitive)
			{
				if (type.IsEnum)
				{
					obj = Enum.Parse(type, text);
				}
				else if (type == typeof(string))
				{
					obj = XmlHelper.UnEscapeInvalidCharacters(text);
				}
				else if (!(type == typeof(DateTime)))
				{
					if (type == typeof(Color))
					{
						obj = ColorTranslator.FromHtml(text);
					}
					else if (type == typeof(PointF))
					{
						string[] array = XmlHelper.UnEscapeInvalidCharacters(text).Split(new char[1] { '|' });
						obj = new PointF(float.Parse(array[0]), float.Parse(array[1]));
					}
					else
					{
						if (object_0 == null)
						{
							try
							{
								obj = method_7(type, xelement_0);
							}
							catch
							{
								obj = null;
							}
						}
						else
						{
							obj = object_0;
						}
						if (obj != null)
						{
							method_1(xelement_0, obj, bool_0: false);
						}
					}
				}
				else
				{
					obj = Convert.ToDateTime(text, CultureInfo.InvariantCulture);
				}
			}
			else
			{
				obj = ((text != "NaN") ? Convert.ChangeType(text, type, CultureInfo.InvariantCulture) : Convert.ChangeType(double.NaN, type));
			}
			return obj;
		}
		throw new ArgumentNullException("Couldn't find the assembly that contains the type that was serialized into that element");
	}

	private void method_1(XElement xelement_0, object object_0, bool bool_0)
	{
		Type type = object_0.GetType();
		SerializationMap serializationMap = SerializationMap.FromType(type);
		XAttribute val = xelement_0.Attribute(XName.op_Implicit("id"));
		if (val != null)
		{
			dictionary_0[val.Value] = object_0;
		}
		foreach (XElement item in from m in ((XContainer)xelement_0).Elements(XName.op_Implicit("member"))
			where m.Attribute(XName.op_Implicit("arg")) == null || bool_0
			select m)
		{
			string string_0 = GetName(item);
			SerializationMapEntry serializationMapEntry = serializationMap.Members.FirstOrDefault((SerializationMapEntry m) => m.Attribute.Name == string_0);
			if (serializationMapEntry == null)
			{
				continue;
			}
			if (serializationMapEntry.Member is PropertyInfo)
			{
				PropertyInfo propertyInfo = (PropertyInfo)serializationMapEntry.Member;
				if (propertyInfo.CanWrite)
				{
					propertyInfo.SetValue(object_0, gDsegegkxPj(item, null), null);
				}
				else
				{
					method_1(item, propertyInfo.GetValue(object_0, null), bool_0: false);
				}
			}
			else
			{
				((FieldInfo)serializationMapEntry.Member).SetValue(object_0, gDsegegkxPj(item, null));
			}
		}
		if (type.IsArray)
		{
			method_2(xelement_0, (Array)object_0);
		}
		else if (typeof(IDictionary).IsAssignableFrom(type))
		{
			method_3(xelement_0, (IDictionary)object_0);
		}
		else if (typeof(IList).IsAssignableFrom(type))
		{
			method_4(xelement_0, (IList)object_0);
		}
	}

	private void method_2(XElement xelement_0, Array array_0)
	{
		int index = 0;
		foreach (XElement item in ((XContainer)xelement_0).Elements(XName.op_Implicit("item")))
		{
			object value = gDsegegkxPj(item, array_0.GetValue(index));
			array_0.SetValue(value, index++);
		}
	}

	private void method_3(XElement xelement_0, IDictionary idictionary_0)
	{
		if (idictionary_0.Count > 0)
		{
			idictionary_0.Clear();
		}
		foreach (XElement item in ((XContainer)xelement_0).Elements(XName.op_Implicit("entry")))
		{
			XElement val = ((XContainer)item).Element(XName.op_Implicit("key"));
			XElement val2 = ((XContainer)item).Element(XName.op_Implicit("value"));
			if (val != null && val2 != null)
			{
				object obj = gDsegegkxPj(val, null);
				object obj2 = gDsegegkxPj(val2, null);
				if (obj != null && obj2 != null)
				{
					idictionary_0.Add(obj, obj2);
				}
			}
		}
	}

	private void method_4(XElement xelement_0, IList ilist_0)
	{
		if (ilist_0.Count > 0)
		{
			ilist_0.Clear();
		}
		foreach (XElement item in ((XContainer)xelement_0).Elements(XName.op_Implicit("item")))
		{
			object obj = gDsegegkxPj(item, null);
			if (obj != null)
			{
				ilist_0.Add(obj);
			}
		}
	}

	private object method_5(XElement xelement_0)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		XAttribute val = xelement_0.Attribute(XName.op_Implicit("formatter"));
		if (val == null)
		{
			return null;
		}
		XAttribute val2 = xelement_0.Attribute(XName.op_Implicit("value"));
		if (val2 == null)
		{
			throw new XmlException("Missing value attribute for formattable element " + smethod_0(xelement_0));
		}
		ConstructorInfo? constructor = dictionary_1[val.Value].GetConstructor(Type.EmptyTypes);
		object[] emptyTypes = Type.EmptyTypes;
		return ((SerializationFormatter)constructor.Invoke(emptyTypes)).FromString(XmlHelper.UnEscapeInvalidCharacters(val2.Value));
	}

	private Type method_6(XElement xelement_0)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		XAttribute val = xelement_0.Attribute(XName.op_Implicit("type"));
		if (val == null)
		{
			throw new XmlException("Missing type attribute for node " + smethod_0(xelement_0));
		}
		return dictionary_1[val.Value];
	}

	private static string BpLegPliiIt(XElement xelement_0)
	{
		XAttribute val = xelement_0.Attribute(XName.op_Implicit("value"));
		if (val != null)
		{
			return val.Value;
		}
		return null;
	}

	private static string GetName(XElement element)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		return (element.Attribute(XName.op_Implicit("name")) ?? throw new XmlException("Missing name attribute for node " + smethod_0(element))).Value;
	}

	private object method_7(Type type_0, XElement xelement_0)
	{
		List<object> list;
		if (!type_0.IsArray)
		{
			list = method_8(xelement_0);
		}
		else
		{
			int num = ((XContainer)xelement_0).Elements(XName.op_Implicit("item")).Count();
			list = new List<object> { num };
		}
		Type[] types = list.Select((object arg) => arg.GetType()).ToArray();
		return type_0.GetConstructor(types).Invoke(list.ToArray());
	}

	private List<object> method_8(XElement xelement_0)
	{
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		List<object> list = new List<object>();
		int num = 0;
		foreach (XElement item in from m in ((XContainer)xelement_0).Elements(XName.op_Implicit("member"))
			let arg = m.Attribute(XName.op_Implicit("arg"))
			where arg != null
			orderby arg.Value
			select m)
		{
			XAttribute val = item.Attribute(XName.op_Implicit("arg"));
			if (val != null)
			{
				if (int.Parse(val.Value, CultureInfo.InvariantCulture) != num)
				{
					throw new XmlException("Missing constructor argument " + num);
				}
				num++;
				list.Add(gDsegegkxPj(item, null));
			}
		}
		return list;
	}

	private static string smethod_0(object object_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		Stack<string> stack = new Stack<string>();
		do
		{
			stack.Push(((XElement)object_0).Name.LocalName);
			object_0 = ((XObject)object_0).Parent;
		}
		while (object_0 != null);
		stringBuilder.Append("/");
		do
		{
			stringBuilder.Append(stack.Pop());
			if (stack.Count > 0)
			{
				stringBuilder.Append("/");
			}
		}
		while (stack.Count > 0);
		return stringBuilder.ToString();
	}

	static XmlDeserializer()
	{
		Class72.smethod_20();
	}
}
