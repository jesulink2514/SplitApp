using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SplitApp.Infrastructure;
using SplitApp.Model;
using Xamarin.Forms;

namespace SplitApp.ViewModel
{
    public class MainPageViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Cost> Costs { get; set; } = new ObservableCollection<Cost>();
        public ICommand AddCostCommand { get; private set; }
        public bool NoHasItems => !Costs.Any();
        public bool HasItems => Costs.Any();
        public void OnAppering()
        {
            if (NavigationService.HasParameter)
            {
                var newCost = NavigationService.GetNavigationParameter<Cost>();
                Costs.Add(newCost);
                OnPropertyChanged("NoHasItems");
                OnPropertyChanged("HasItems");
            }
        }

        public MainPageViewModel()
        {
            this.AddCostCommand = new Command(OnAddCost);
        }

        private async void OnAddCost()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddEditCostPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
