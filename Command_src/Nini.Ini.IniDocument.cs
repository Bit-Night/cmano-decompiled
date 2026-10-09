using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace Nini.Ini;

public class IniDocument
{
	private IniSectionCollection iniSectionCollection_0 = new IniSectionCollection();

	private ArrayList arrayList_0 = new ArrayList();

	private IniFileType iniFileType_0;

	public IniFileType FileType
	{
		get
		{
			return iniFileType_0;
		}
		set
		{
			iniFileType_0 = value;
		}
	}

	public IniSectionCollection Sections => iniSectionCollection_0;

	public IniDocument(string filePath)
	{
		iniFileType_0 = IniFileType.Standard;
		Load(filePath);
	}

	public IniDocument(string filePath, IniFileType type)
	{
		iniFileType_0 = type;
		Load(filePath);
	}

	public IniDocument(TextReader reader)
	{
		iniFileType_0 = IniFileType.Standard;
		Load(reader);
	}

	public IniDocument(TextReader reader, IniFileType type)
	{
		iniFileType_0 = type;
		Load(reader);
	}

	public IniDocument(Stream stream)
	{
		iniFileType_0 = IniFileType.Standard;
		Load(stream);
	}

	public IniDocument(Stream stream, IniFileType type)
	{
		iniFileType_0 = type;
		Load(stream);
	}

	public IniDocument(IniReader reader)
	{
		iniFileType_0 = IniFileType.Standard;
		Load(reader);
	}

	public IniDocument()
	{
	}

	public void Load(string filePath)
	{
		Load(new StreamReader(filePath));
	}

	public void Load(TextReader reader)
	{
		Load(method_1(reader, iniFileType_0));
	}

	public void Load(Stream stream)
	{
		Load(new StreamReader(stream));
	}

	public void Load(IniReader reader)
	{
		method_0(reader);
	}

	public void Save(TextWriter textWriter)
	{
		IniWriter iniWriter = method_2(textWriter, iniFileType_0);
		IniItem iniItem = null;
		IniSection iniSection = null;
		foreach (string item in arrayList_0)
		{
			iniWriter.WriteEmpty(item);
		}
		for (int i = 0; i < iniSectionCollection_0.Count; i++)
		{
			iniSection = iniSectionCollection_0[i];
			iniWriter.WriteSection(iniSection.Name, iniSection.Comment);
			for (int j = 0; j < iniSection.ItemCount; j++)
			{
				iniItem = iniSection.GetItem(j);
				if (iniItem.Name == "ConnectionString" && iniItem.Value != null && iniItem.Value.Count() > 0)
				{
					if (iniItem.Value.First() != '"')
					{
						iniItem.Value = '"' + iniItem.Value;
					}
					if (iniItem.Value.Last() != '"')
					{
						iniItem.Value += '"';
					}
				}
				switch (iniItem.Type)
				{
				case IniType.Empty:
					iniWriter.WriteEmpty(iniItem.Comment);
					break;
				case IniType.Key:
					iniWriter.WriteKey(iniItem.Name, iniItem.Value, iniItem.Comment);
					break;
				}
			}
		}
		iniWriter.Close();
	}

	public void Save(string filePath)
	{
		StreamWriter streamWriter = new StreamWriter(filePath);
		Save(streamWriter);
		streamWriter.Close();
	}

	public void Save(Stream stream)
	{
		Save(new StreamWriter(stream));
	}

	private void method_0(IniReader iniReader_0)
	{
		iniReader_0.IgnoreComments = false;
		bool flag = false;
		IniSection iniSection = null;
		try
		{
			while (iniReader_0.Read())
			{
				switch (iniReader_0.Type)
				{
				case IniType.Section:
					flag = true;
					if (iniSectionCollection_0[iniReader_0.Name] != null)
					{
						iniSectionCollection_0.Remove(iniReader_0.Name);
					}
					iniSection = new IniSection(iniReader_0.Name, iniReader_0.Comment);
					iniSectionCollection_0.Add(iniSection);
					break;
				case IniType.Key:
					if (iniSection.GetValue(iniReader_0.Name) == null)
					{
						iniSection.Set(iniReader_0.Name, iniReader_0.Value, iniReader_0.Comment);
					}
					break;
				case IniType.Empty:
					if (!flag)
					{
						arrayList_0.Add(iniReader_0.Comment);
					}
					else
					{
						iniSection.Set(iniReader_0.Comment);
					}
					break;
				}
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			iniReader_0.Close();
		}
	}

	private IniReader method_1(TextReader textReader_0, IniFileType iniFileType_1)
	{
		IniReader iniReader = new IniReader(textReader_0);
		switch (iniFileType_1)
		{
		case IniFileType.PythonStyle:
			iniReader.AcceptCommentAfterKey = false;
			iniReader.SetCommentDelimiters(new char[2] { ';', '#' });
			iniReader.SetAssignDelimiters(new char[1] { ':' });
			break;
		case IniFileType.SambaStyle:
			iniReader.AcceptCommentAfterKey = false;
			iniReader.SetCommentDelimiters(new char[2] { ';', '#' });
			iniReader.LineContinuation = true;
			break;
		case IniFileType.MysqlStyle:
			iniReader.AcceptCommentAfterKey = false;
			iniReader.AcceptNoAssignmentOperator = true;
			iniReader.SetCommentDelimiters(new char[1] { '#' });
			iniReader.SetAssignDelimiters(new char[2] { ':', '=' });
			break;
		case IniFileType.WindowsStyle:
			iniReader.ConsumeAllKeyText = true;
			break;
		}
		return iniReader;
	}

	private IniWriter method_2(TextWriter textWriter_0, IniFileType iniFileType_1)
	{
		IniWriter iniWriter = new IniWriter(textWriter_0);
		switch (iniFileType_1)
		{
		case IniFileType.PythonStyle:
			iniWriter.AssignDelimiter = ':';
			iniWriter.CommentDelimiter = '#';
			break;
		case IniFileType.SambaStyle:
		case IniFileType.MysqlStyle:
			iniWriter.AssignDelimiter = '=';
			iniWriter.CommentDelimiter = '#';
			break;
		}
		return iniWriter;
	}

	static IniDocument()
	{
		Class72.smethod_20();
	}
}
