using System.Collections.Generic;
using System.ComponentModel;
using Plugin.Contacts.Abstractions;

namespace SplitApp.ViewModel
{
    public class AddEditViewModel : INotifyPropertyChanged
    {
        public List<Contact> Accountables { get; set; } = new List<Contact>()
        {
            new  Contact("1",isAggregate:false){DisplayName = "Jesus Angulo"},
            new  Contact("1",isAggregate:false){DisplayName = "Jesus Angulo"},
            new  Contact("1",isAggregate:false){DisplayName = "Jesus Angulo"},
            new  Contact("1",isAggregate:false){DisplayName = "Jesus Angulo"},
            new  Contact("1",isAggregate:false){DisplayName = "Jesus Angulo"},
            new  Contact("1",isAggregate:false){DisplayName = "Jesus Angulo"}
        };

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
