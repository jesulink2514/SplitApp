using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using SplitApp.Infrastructure;
using SplitApp.Model;

namespace SplitApp.ViewModel
{
    public class ResultPageViewModel:INotifyPropertyChanged, INavigationEvents
    {
        public bool IsLoading { get; set; }

        public void OnAppearing()
        {
            IsLoading = true;

            if(!NavigationService.HasParameter)return;

            var costs = NavigationService.GetNavigationParameter<ObservableCollection<Cost>>();
            var users = costs.SelectMany(x=>x.Owners)
                .Select(x=>x.Name).Distinct()
                .Select(x=>new Result(){Name = x,Amount = 0})
                .ToDictionary(x=>x.Name,x=>x);

            foreach (var cost in costs)
            {
                var amount = cost.Amount / cost.Owners.Count;
                foreach (var owner in cost.Owners)
                {
                    users[owner.Name].Amount += amount;
                }
            }

            Results = users.Values.ToList();

            IsLoading = false;
        }

        public List<Result> Results { get; set; }
        public void OnDisappearing()
        {   
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
