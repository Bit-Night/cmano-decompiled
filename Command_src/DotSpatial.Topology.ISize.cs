using System.ComponentModel;

namespace DotSpatial.Topology;

[TypeConverter(typeof(ExpandableObjectConverter))]
public interface ISize
{
	double XSize { get; set; }

	double YSize { get; set; }

	double ZSize { get; set; }
}
