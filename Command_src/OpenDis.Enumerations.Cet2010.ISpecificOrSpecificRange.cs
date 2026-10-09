using System.Collections.Generic;
using System.ComponentModel;

namespace OpenDis.Enumerations.Cet2010;

public interface ISpecificOrSpecificRange : IGenericEntryDescription, IGenericEntry, INotifyPropertyChanged
{
	List<GenericEntryDescription> Extras { get; set; }

	ulong UId { get; set; }
}
