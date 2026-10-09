using System;
using System.Runtime.CompilerServices;
using OpenDis.Core;
using OpenDis.Enumerations.EntityState.Type;

namespace OpenDis.Enumerations.Cet2010;

public class CetItem : ICetItem, IComparable<ICetItem>, IComparable
{
	[CompilerGenerated]
	private Country country_0;

	[CompilerGenerated]
	private byte byte_0;

	[CompilerGenerated]
	private EntityKind ChpYqEvrFiD;

	[CompilerGenerated]
	private byte byte_1;

	[CompilerGenerated]
	private byte? nullable_0;

	[CompilerGenerated]
	private byte? nullable_1;

	[CompilerGenerated]
	private byte? nullable_2;

	[CompilerGenerated]
	private uint? nullable_3;

	[CompilerGenerated]
	private string string_0;

	public Country Country
	{
		[CompilerGenerated]
		get
		{
			return country_0;
		}
		[CompilerGenerated]
		set
		{
			country_0 = value;
		}
	}

	public byte Domain
	{
		[CompilerGenerated]
		get
		{
			return byte_0;
		}
		[CompilerGenerated]
		set
		{
			byte_0 = value;
		}
	}

	public EntityKind Kind
	{
		[CompilerGenerated]
		get
		{
			return ChpYqEvrFiD;
		}
		[CompilerGenerated]
		set
		{
			ChpYqEvrFiD = value;
		}
	}

	public byte Category
	{
		[CompilerGenerated]
		get
		{
			return byte_1;
		}
		[CompilerGenerated]
		set
		{
			byte_1 = value;
		}
	}

	public byte? Subcategory
	{
		[CompilerGenerated]
		get
		{
			return nullable_0;
		}
		[CompilerGenerated]
		set
		{
			nullable_0 = value;
		}
	}

	public byte? Specific
	{
		[CompilerGenerated]
		get
		{
			return nullable_1;
		}
		[CompilerGenerated]
		set
		{
			nullable_1 = value;
		}
	}

	public byte? Extra
	{
		[CompilerGenerated]
		get
		{
			return nullable_2;
		}
		[CompilerGenerated]
		set
		{
			nullable_2 = value;
		}
	}

	public uint? Maximum
	{
		[CompilerGenerated]
		get
		{
			return nullable_3;
		}
		[CompilerGenerated]
		set
		{
			nullable_3 = value;
		}
	}

	public string Description
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

	public int CompareTo(ICetItem other)
	{
		if (other == null)
		{
			return 1;
		}
		int num = Country.ToString().CompareTo(other.Country.ToString());
		if (num != 0)
		{
			return num;
		}
		int num2 = Domain.CompareTo(other.Domain);
		if (num2 != 0)
		{
			return num2;
		}
		int num3 = Kind.ToString().CompareTo(other.Kind.ToString());
		if (num3 == 0)
		{
			int num4 = Category.CompareTo(other.Category);
			if (num4 == 0)
			{
				if (!Subcategory.HasValue)
				{
					if (!other.Subcategory.HasValue)
					{
						return 0;
					}
					return -1;
				}
				int num5 = Subcategory.Value.CompareTo(other.Subcategory);
				if (num5 == 0)
				{
					if (Specific.HasValue)
					{
						int num6 = Specific.Value.CompareTo(other.Specific);
						if (num6 == 0)
						{
							if (!Extra.HasValue)
							{
								if (other.Extra.HasValue)
								{
									return -1;
								}
								return 0;
							}
							int num7 = Extra.Value.CompareTo(other.Extra);
							if (num7 == 0)
							{
								if (!string.IsNullOrEmpty(Description))
								{
									return Description.CompareTo(other.Description);
								}
								return 0;
							}
							return num7;
						}
						return num6;
					}
					if (other.Specific.HasValue)
					{
						return -1;
					}
					return 0;
				}
				return num5;
			}
			return num4;
		}
		return num3;
	}

	public int CompareTo(object obj)
	{
		if (!(obj is CetItem))
		{
			throw new ArgumentException("Object is not of type CetItem.");
		}
		return CompareTo((CetItem)obj);
	}

	static CetItem()
	{
		Class72.smethod_20();
	}
}
