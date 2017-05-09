using System.ComponentModel;

namespace SplitApp.Model
{
    public class Result : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}