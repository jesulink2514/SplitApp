using System.ComponentModel;

namespace SplitApp.Model
{
    public class Owner: INotifyPropertyChanged
    {
        public Owner()
        {
            ProfileUrl = "DefaultContact.png";
        }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string ProfileUrl { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
