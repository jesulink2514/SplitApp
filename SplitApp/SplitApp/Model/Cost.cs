using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SplitApp.Model
{
    public class Cost: INotifyPropertyChanged
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public ObservableCollection<Owner> Owners { get; set; } = new ObservableCollection<Owner>();

        public string Error
        {
            get
            {
                if (string.IsNullOrEmpty(Description)) return "You need to enter a description";
                if (Amount <= 0) return "Amount need to be a valid no negative number.";
                if (!Owners.Any()) return "You need to specify at least one resposible for this charge.";
                return string.Empty;
            }
        }

        public bool IsValid
        {
            get
            {
                if (string.IsNullOrEmpty(Description)) return false;
                if (Amount <= 0) return false;
                if (!Owners.Any()) return false;
                return true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
