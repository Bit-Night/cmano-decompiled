using System.Collections.Generic;
using System.ComponentModel;

namespace OpenDis.Enumerations.Cet2010;

public interface ISubcategoryOrSubcategoryRange : IGenericEntryDescription, IGenericEntry, INotifyPropertyChanged
{
	List<GenericEntryDescription> Specifices { get; set; }

	ulong UId { get; set; }
}
