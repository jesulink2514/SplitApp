using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using SplitApp.Model;
using Xamarin.Forms;

namespace SplitApp.ViewModel
{
    public class AddEditViewModel : INotifyPropertyChanged
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public ICommand AddOwnerCommand { get; private set; }
        public ICommand RemoveOwnerCommand { get; private set; }
        public ObservableCollection<Owner> Owners { get; set; } = new ObservableCollection<Owner>();
        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public bool IsEditing { get; set; }

        public AddEditViewModel()
        {
            this.AddOwnerCommand = new Command(AddOwner);
            this.RemoveOwnerCommand = new Command(RemoveOwner);
            this.SaveCommand = new Command(OnSave);
            this.DeleteCommand = new Command(OnDelete);
        }

        private void RemoveOwner(object obj)
        {
            var owner = obj as Owner;
            Owners.Remove(owner);
        }

        private void AddOwner()
        {
            Application.Current.MainPage.Navigation.PushAsync(new PickContactPage());
        }

        private void OnDelete(object obj)
        {
            var owner = obj as Owner;



        }

        private void OnSave()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
