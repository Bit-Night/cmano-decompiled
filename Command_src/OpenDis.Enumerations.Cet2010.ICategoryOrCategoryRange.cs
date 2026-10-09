using System.Collections.Generic;
using System.ComponentModel;

namespace OpenDis.Enumerations.Cet2010;

public interface ICategoryOrCategoryRange : IGenericEntryDescription, IGenericEntry, INotifyPropertyChanged
{
	List<GenericEntryDescription> Subcategories { get; set; }

	ulong UId { get; set; }
}
