using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Enumerations.Cet2006;

public class CetFactory
{
	public static Cet CreateAggregateTypes()
	{
		return smethod_0("OpenDis.Enumerations.Cet2006.AggregateTypes.xml");
	}

	public static List<ICetItem> Transform(Cet c)
	{
		List<ICetItem> first = new List<ICetItem>();
		IEnumerable<ICetItem> second = from e in c.Entities
			from j in e.Categories
			from k in j.Subcategories
			from l in k.Specifices
			from m in l.Extras
			select new CetItem
			{
				Category = j.Id,
				Country = e.Country,
				Description = m.Description,
				Domain = e.Domain,
				Extra = ((m.Id == 0) ? ((byte?)null) : new byte?(m.Id)),
				Kind = e.Kind,
				Specific = ((l.Id != 0) ? new byte?(l.Id) : ((byte?)null)),
				Subcategory = ((k.Id == 0) ? ((byte?)null) : new byte?(k.Id))
			};
		IEnumerable<ICetItem> second2 = from e in c.Entities
			from j in e.Categories
			from k in j.Subcategories
			from l in k.Specifices
			select new CetItem
			{
				Category = j.Id,
				Country = e.Country,
				Description = l.Description,
				Domain = e.Domain,
				Kind = e.Kind,
				Specific = ((l.Id == 0) ? ((byte?)null) : new byte?(l.Id)),
				Maximum = ((l.Id2 == 0) ? ((byte?)null) : new byte?(l.Id2)),
				Subcategory = ((k.Id == 0) ? ((byte?)null) : new byte?(k.Id))
			};
		IEnumerable<ICetItem> second3 = from e in c.Entities
			from j in e.Categories
			from k in j.Subcategories
			select new CetItem
			{
				Category = j.Id,
				Country = e.Country,
				Description = k.Description,
				Domain = e.Domain,
				Kind = e.Kind,
				Subcategory = ((k.Id != 0) ? new byte?(k.Id) : ((byte?)null)),
				Maximum = ((k.Id2 == 0) ? ((byte?)null) : new byte?(k.Id2))
			};
		List<ICetItem> list = Enumerable.Concat(second: from e in c.Entities
			from j in e.Categories
			select new CetItem
			{
				Category = j.Id,
				Country = e.Country,
				Description = j.Description,
				Domain = e.Domain,
				Kind = e.Kind
			}, first: first.Concat(second).Concat(second2).Concat(second3)).ToList();
		list.Sort();
		return list;
	}

	private static Cet smethod_0(string string_0)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		XmlSerializer val = new XmlSerializer(typeof(Cet));
		Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(string_0);
		return (Cet)val.Deserialize(manifestResourceStream);
	}

	public static Cet CreateEntityTypes()
	{
		return smethod_0("OpenDis.Enumerations.Cet2006.EntityTypes.xml");
	}

	static CetFactory()
	{
		Class72.smethod_20();
	}
}
