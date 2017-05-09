using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Contacts;
using Plugin.Contacts.Abstractions;
using SplitApp.Model;
using Xamarin.Forms;

namespace SplitApp.ViewModel
{
    public class PickContactViewModel: INotifyPropertyChanged
    {
        public PickContactViewModel()
        {
            LoadContacts();
            SearchCommand = new Command(OnSearch);
            SelectContactCommand = new Command(OnSelectContact);
        }

        private void OnSelectContact(object obj)
        {
            var item = obj as Owner;



        }

        public ICommand SelectContactCommand { get;private set; }

        private void OnSearch()
        {
            Contacts = string.IsNullOrEmpty(SearchCriteria) ? 
                AllContacts.ToList() : 
                AllContacts.Where(x => x.Name.StartsWith(SearchCriteria)).Take(100).ToList();
        }

        public ICommand SearchCommand { get; private set; }
        public string SearchCriteria { get; set; }
        public bool IsLoading { get; set; }
        public async void LoadContacts()
        {
            if(IsLoading)return;

            IsLoading = true;

            if (await CrossContacts.Current.RequestPermission())
            {
                CrossContacts.Current.PreferContactAggregation = false;

                await Task.Run(() =>
                {
                    if (CrossContacts.Current.Contacts == null)
                        return;

                    AllContacts = CrossContacts.Current.Contacts
                      .Where(c => !string.IsNullOrWhiteSpace(c.LastName) && c.Phones.Count > 0)
                      .OrderBy(x=>x.DisplayName).ToList()
                      .Select(x=> new Owner()
                        {
                            Name = x.DisplayName,
                            Phone = x.Phones.FirstOrDefault()?.Number
                        })
                      .ToList();

                    Contacts= AllContacts.ToList();

                    IsLoading = false;
                });
            }
        }

        public List<Owner> AllContacts { get; set; }
        public List<Owner> Contacts { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
