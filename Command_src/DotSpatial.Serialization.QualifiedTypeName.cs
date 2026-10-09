using System;
using System.Runtime.CompilerServices;

namespace DotSpatial.Serialization;

public class QualifiedTypeName
{
	[CompilerGenerated]
	private QualifiedTypeName qualifiedTypeName_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private Version version_0;

	[CompilerGenerated]
	private string string_2;

	[CompilerGenerated]
	private string string_3;

	public QualifiedTypeName EnclosedName
	{
		[CompilerGenerated]
		get
		{
			return qualifiedTypeName_0;
		}
		[CompilerGenerated]
		set
		{
			qualifiedTypeName_0 = value;
		}
	}

	public string TypeName
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public string Assembly
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public Version Version
	{
		[CompilerGenerated]
		get
		{
			return version_0;
		}
		[CompilerGenerated]
		set
		{
			version_0 = value;
		}
	}

	public string Culture
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	public string PublicKeyToken
	{
		[CompilerGenerated]
		get
		{
			return string_3;
		}
		[CompilerGenerated]
		set
		{
			string_3 = value;
		}
	}

	public QualifiedTypeName(string qualifiedName)
	{
		if (qualifiedName.Contains("[["))
		{
			int num = qualifiedName.IndexOf("[[");
			int num2 = qualifiedName.IndexOf("]]");
			string qualifiedName2 = qualifiedName.Substring(num + 2, num2 - (num + 2));
			EnclosedName = new QualifiedTypeName(qualifiedName2);
			qualifiedName = qualifiedName.Substring(0, num + 2) + qualifiedName.Substring(num2, qualifiedName.Length - num2);
		}
		string[] array = qualifiedName.Split(new char[1] { ',' });
		TypeName = array[0];
		Assembly = array[1].Trim();
		for (int i = 2; i < array.Length; i++)
		{
			string text = array[i].Trim();
			if (text.Substring(0, 8) == "Version=")
			{
				string version = text.Substring(8, text.Length - 8);
				Version = new Version(version);
			}
			if (text.Substring(0, 8) == "Culture=")
			{
				Culture = text.Substring(8, text.Length - 8);
			}
			if (text.Substring(0, 15) == "PublicKeyToken=")
			{
				string publicKeyToken = text.Substring(15, text.Length - 15);
				PublicKeyToken = publicKeyToken;
			}
		}
	}

	public new string ToString()
	{
		string text = TypeName;
		if (text.Contains("[["))
		{
			int startIndex = TypeName.IndexOf("]]");
			text = TypeName.Insert(startIndex, EnclosedName.ToString());
		}
		string text2 = PublicKeyToken;
		if (string.IsNullOrEmpty(text2))
		{
			text2 = "null";
		}
		return $"{text}, {Assembly}, Version={Version}, Culture={Culture}, PublicKeyToken={text2}";
	}

	static QualifiedTypeName()
	{
		Class72.smethod_20();
	}
}
