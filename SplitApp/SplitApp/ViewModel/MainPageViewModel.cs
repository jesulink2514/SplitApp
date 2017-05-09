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
    public class MainPageViewModel: INotifyPropertyChanged, INavigationEvents
    {
        public ObservableCollection<Cost> Costs { get; set; } = new ObservableCollection<Cost>();
        public ICommand AddCostCommand { get; private set; }
        public ICommand EditCostCommand { get; private set; }
        public ICommand CalculateCommand { get; private set; }
        public bool NoHasItems => !Costs.Any();
        public bool HasItems => Costs.Any();

        public MainPageViewModel()
        {
            this.AddCostCommand = new Command(OnAddCost);
            this.EditCostCommand = new Command(OnEditCost);
            this.CalculateCommand = new Command(OnCalculate);
        }

        private async void OnEditCost(object obj)
        {
            var cost = obj as Cost;
            NavigationService.SetNavigationParameter(cost);

            await Application.Current.MainPage.Navigation.PushAsync(new View.AddEditCostPage());
        }

        private async void OnAddCost()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new View.AddEditCostPage());
        }

        private async void OnCalculate()
        {
            NavigationService.SetNavigationParameter(this.Costs);
            await Application.Current.MainPage.Navigation.PushAsync(new View.ResultPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnAppearing()
        {
            if (NavigationService.HasParameter)
            {
                var newCost = NavigationService.GetNavigationParameter<EditorParameter<Cost>>();
                if (newCost.Status == EditorStatus.Deleted)
                {
                    Costs.Remove(newCost.Param);
                }
                else if(newCost.Status == EditorStatus.New)
                {
                    Costs.Add(newCost.Param);
                }
                OnPropertyChanged("NoHasItems");
                OnPropertyChanged("HasItems");
            }
        }

        public void OnDisappearing()
        {
        }
    }
}
