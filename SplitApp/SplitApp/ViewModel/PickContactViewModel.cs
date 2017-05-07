using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Plugin.Contacts;
using Plugin.Contacts.Abstractions;

namespace SplitApp.ViewModel
{
    public class PickContactViewModel: INotifyPropertyChanged
    {
        public PickContactViewModel()
        {
            
        }

        public async void LoadContacts()
        {
            if (await CrossContacts.Current.RequestPermission())
            {
                List<Contact> contacts = null;
                CrossContacts.Current.PreferContactAggregation = false;//recommended
                                                                       //run in background
                await Task.Run(() =>
                {
                    if (CrossContacts.Current.Contacts == null)
                        return;

                    contacts = CrossContacts.Current.Contacts
                      .Where(c => !string.IsNullOrWhiteSpace(c.LastName) && c.Phones.Count > 0)
                      .ToList();

                    contacts = contacts.OrderBy(c => c.LastName).ToList();
                });
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
