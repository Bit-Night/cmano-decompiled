using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Nini.Ini;

[Serializable]
public class IniException : SystemException
{
	private IniReader iniReader_0;

	private string string_0 = "";

	public int LinePosition
	{
		get
		{
			if (iniReader_0 == null)
			{
				return 0;
			}
			return iniReader_0.LinePosition;
		}
	}

	public int LineNumber
	{
		get
		{
			if (iniReader_0 == null)
			{
				return 0;
			}
			return iniReader_0.LineNumber;
		}
	}

	public override string Message
	{
		get
		{
			if (iniReader_0 == null)
			{
				return base.Message;
			}
			return string.Format(CultureInfo.InvariantCulture, "{0} - Line: {1}, Position: {2}.", string_0, LineNumber, LinePosition);
		}
	}

	public IniException()
	{
		string_0 = "An error has occurred";
	}

	public IniException(string message, Exception exception)
		: base(message, exception)
	{
	}

	public IniException(string message)
		: base(message)
	{
		string_0 = message;
	}

	internal IniException(IniReader reader, string message)
		: this(message)
	{
		iniReader_0 = reader;
		string_0 = message;
	}

	protected IniException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		if (iniReader_0 != null)
		{
			info.AddValue("lineNumber", iniReader_0.LineNumber);
			info.AddValue("linePosition", iniReader_0.LinePosition);
		}
	}

	static IniException()
	{
		Class72.smethod_20();
	}
}
