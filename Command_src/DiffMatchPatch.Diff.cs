namespace DiffMatchPatch;

public sealed class Diff
{
	public Operation operation;

	public string text;

	public Diff(Operation operation, string text)
	{
		this.operation = operation;
		this.text = text;
	}

	public override string ToString()
	{
		string text = this.text.Replace('\n', '¶');
		return "Diff(" + operation.ToString() + ",\"" + text + "\")";
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (!(obj is Diff diff))
		{
			return false;
		}
		if (diff.operation == operation)
		{
			return diff.text == text;
		}
		return false;
	}

	public bool Equals(Diff obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj.operation == operation)
		{
			return obj.text == text;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return text.GetHashCode() ^ operation.GetHashCode();
	}

	static Diff()
	{
		Class72.smethod_20();
	}
}
