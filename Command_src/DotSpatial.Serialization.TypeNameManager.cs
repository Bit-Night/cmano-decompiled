using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DotSpatial.Serialization;

public class TypeNameManager
{
	private readonly Dictionary<string, Assembly> dictionary_0;

	public TypeNameManager()
	{
		dictionary_0 = new Dictionary<string, Assembly>();
	}

	public string UpdateTypename(string invalidTypeName)
	{
		QualifiedTypeName qualifiedTypeName = new QualifiedTypeName(invalidTypeName);
		for (QualifiedTypeName qualifiedTypeName2 = qualifiedTypeName; qualifiedTypeName2 != null; qualifiedTypeName2 = qualifiedTypeName2.EnclosedName)
		{
			method_0(qualifiedTypeName2);
		}
		return qualifiedTypeName.ToString();
	}

	private void method_0(QualifiedTypeName qualifiedTypeName_0)
	{
		if (!Enumerable.Contains(dictionary_0.Keys, qualifiedTypeName_0.Assembly))
		{
			method_1(qualifiedTypeName_0.Assembly);
		}
		if (Enumerable.Contains(dictionary_0.Keys, qualifiedTypeName_0.Assembly))
		{
			AssemblyName name = dictionary_0[qualifiedTypeName_0.Assembly].GetName();
			qualifiedTypeName_0.Version = name.Version;
			string text = BitConverter.ToString(name.GetPublicKeyToken());
			text = text.Replace("-", string.Empty).ToLower();
			qualifiedTypeName_0.PublicKeyToken = text;
		}
	}

	private void method_1(string string_0)
	{
		string text = string_0 + ".dll";
		if (!File.Exists(text))
		{
			string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			if (directoryName != null)
			{
				string[] files = Directory.GetFiles(directoryName, text, SearchOption.AllDirectories);
				if (files.Length == 0)
				{
					string directoryName2 = Path.GetDirectoryName(directoryName);
					if (directoryName2 != null)
					{
						DirectoryInfo parent = Directory.GetParent(directoryName2);
						while (parent != null)
						{
							string[] files2 = Directory.GetFiles(directoryName, text, SearchOption.TopDirectoryOnly);
							if (files2.Length == 0)
							{
								parent = parent.Parent;
								continue;
							}
							text = files2[0];
							break;
						}
					}
				}
				else
				{
					text = files[0];
				}
			}
		}
		if (File.Exists(text))
		{
			Assembly assembly = Assembly.LoadFrom(text);
			if (assembly != null)
			{
				dictionary_0.Add(string_0, assembly);
			}
		}
	}

	static TypeNameManager()
	{
		Class72.smethod_20();
	}
}
