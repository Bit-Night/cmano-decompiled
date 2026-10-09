using System.ComponentModel;

namespace OpenDis.Enumerations.Cet2010;

public interface GInterface12 : IGenericEntryDescription, IGenericEntry, INotifyPropertyChanged
{
	ulong UId { get; set; }
}
