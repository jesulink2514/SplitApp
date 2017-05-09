using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using SplitApp.Infrastructure;
using SplitApp.Model;
using Xamarin.Forms;

namespace SplitApp.ViewModel
{
    public class AddEditCostViewModel : INotifyPropertyChanged, INavigationEvents
    {
        public ICommand AddOwnerCommand { get; private set; }
        public ICommand RemoveOwnerCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public bool IsEditing { get; set; }

        public AddEditCostViewModel()
        {
            this.AddOwnerCommand = new Command(AddOwner);
            this.RemoveOwnerCommand = new Command(RemoveOwner);
            this.SaveCommand = new Command(OnSave);
            this.DeleteCommand = new Command(OnDelete);
        }

        private void RemoveOwner(object obj)
        {
            var owner = obj as Owner;
            this.Cost.Owners.Remove(owner);
        }

        private void AddOwner()
        {
            Application.Current.MainPage.Navigation.PushAsync(new View.PickContactPage());
        }

        private async void OnDelete(object obj)
        {
            var sure = await App.Current.MainPage.DisplayAlert("Deleting this cost","Are you sure?", "Ok", "Cancel");
            if(!sure)return;

            var param = new EditorParameter<Cost>()
            {
                Param = Cost, Status = EditorStatus.Deleted
            };
            NavigationService.SetNavigationParameter(param);
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async void OnSave()
        {
            if (!this.Cost.IsValid)
            {
                var message = this.Cost.Error;
                await App.Current.MainPage.DisplayAlert("Error", message, "Ok");
                return;
            }

            NavigationService.SetNavigationParameter(new EditorParameter<Cost>(){
                Param = this.Cost, Status = IsEditing? EditorStatus.Edited : EditorStatus.New
            });
            await App.Current.MainPage.Navigation.PopAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnAppearing()
        {
            if (!NavigationService.HasParameter)return;

            if (NavigationService.Is<Cost>())
            {
                this.IsEditing = true;
                this.Cost = NavigationService.GetNavigationParameter<Cost>();
            }
            else if(NavigationService.Is<Owner>())
            {
                var owner = NavigationService.GetNavigationParameter<Owner>();
                if (this.Cost.Owners.All(x => x.Name != owner.Name))
                {
                    this.Cost.Owners.Add(owner);
                }
            }
        }

        public Cost Cost { get; set; } = new Cost();

        public void OnDisappearing()
        {
        }
    }
}
