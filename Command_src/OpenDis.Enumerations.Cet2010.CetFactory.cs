using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Enumerations.Cet2010;

public class CetFactory
{
	public static Cet CreateAggregateTypes()
	{
		return smethod_0("OpenDis.Enumerations.Cet2010.AggregateTypes.xml");
	}

	private static Cet smethod_0(string string_0)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		XmlSerializer val = new XmlSerializer(typeof(Cet));
		Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(string_0);
		return (Cet)val.Deserialize(manifestResourceStream);
	}

	public static List<ICetItem> Transform(Cet c)
	{
		List<ICetItem> first = new List<ICetItem>();
		IEnumerable<ICetItem> second = from e in c.Entities
			from j in e.Categories
			from k in ((ICategoryOrCategoryRange)j).Subcategories
			from l in ((ISubcategoryOrSubcategoryRange)k).Specifices
			from m in ((ISpecificOrSpecificRange)l).Extras
			select new CetItem
			{
				Category = (byte)((GenericEntrySingle)j).Value,
				Country = e.Country,
				Description = m.Description,
				Domain = e.Domain,
				Extra = ((!(m is GenericEntryRange)) ? new byte?((byte)((GenericEntrySingle)m).Value) : ((((GenericEntryRange)m).Min == 0) ? ((byte?)null) : new byte?((byte)((GenericEntryRange)m).Min))),
				Maximum = ((!(m is GenericEntryRange)) ? ((byte?)null) : ((((GenericEntryRange)m).Max != 0) ? new byte?((byte)((GenericEntryRange)m).Max) : ((byte?)null))),
				Kind = e.Kind,
				Specific = ((!(l is GenericEntryRange)) ? new byte?((byte)((GenericEntrySingle)l).Value) : ((((GenericEntryRange)l).Min != 0) ? new byte?((byte)((GenericEntryRange)l).Min) : ((byte?)null))),
				Subcategory = ((!(k is GenericEntryRange)) ? new byte?((byte)((GenericEntrySingle)k).Value) : ((((GenericEntryRange)k).Min != 0) ? new byte?((byte)((GenericEntryRange)k).Min) : ((byte?)null)))
			};
		IEnumerable<ICetItem> second2 = from e in c.Entities
			from j in e.Categories
			from k in ((ICategoryOrCategoryRange)j).Subcategories
			from l in ((ISubcategoryOrSubcategoryRange)k).Specifices
			select new CetItem
			{
				Category = (byte)((GenericEntrySingle)j).Value,
				Country = e.Country,
				Description = l.Description,
				Domain = e.Domain,
				Kind = e.Kind,
				Specific = ((!(l is GenericEntryRange)) ? new byte?((byte)((GenericEntrySingle)l).Value) : ((((GenericEntryRange)l).Min == 0) ? ((byte?)null) : new byte?((byte)((GenericEntryRange)l).Min))),
				Maximum = ((!(l is GenericEntryRange)) ? ((byte?)null) : ((((GenericEntryRange)l).Max != 0) ? new byte?((byte)((GenericEntryRange)l).Max) : ((byte?)null))),
				Subcategory = ((!(k is GenericEntryRange)) ? new byte?((byte)((GenericEntrySingle)k).Value) : ((((GenericEntryRange)k).Min != 0) ? new byte?((byte)((GenericEntryRange)k).Min) : ((byte?)null)))
			};
		IEnumerable<ICetItem> second3 = from e in c.Entities
			from j in e.Categories
			from k in ((ICategoryOrCategoryRange)j).Subcategories
			select new CetItem
			{
				Category = (byte)((GenericEntrySingle)j).Value,
				Country = e.Country,
				Description = k.Description,
				Domain = e.Domain,
				Kind = e.Kind,
				Subcategory = ((!(k is GenericEntryRange)) ? new byte?((byte)((GenericEntrySingle)k).Value) : ((((GenericEntryRange)k).Min != 0) ? new byte?((byte)((GenericEntryRange)k).Min) : ((byte?)null))),
				Maximum = ((!(k is GenericEntryRange)) ? ((byte?)null) : ((((GenericEntryRange)k).Max == 0) ? ((byte?)null) : new byte?((byte)((GenericEntryRange)k).Max)))
			};
		List<ICetItem> list = Enumerable.Concat(second: from e in c.Entities
			from j in e.Categories
			select new CetItem
			{
				Category = (byte)((GenericEntrySingle)j).Value,
				Country = e.Country,
				Description = j.Description,
				Domain = e.Domain,
				Kind = e.Kind
			}, first: first.Concat(second).Concat(second2).Concat(second3)).ToList();
		list.Sort();
		return list;
	}

	public static Cet CreateEntityTypes()
	{
		return smethod_0("OpenDis.Enumerations.Cet2010.EntityTypes.xml");
	}

	static CetFactory()
	{
		Class72.smethod_20();
	}
}
