using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SplitApp.Model
{
    public class Cost: INotifyPropertyChanged
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public ObservableCollection<Owner> Owners { get; set; } = new ObservableCollection<Owner>();
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
