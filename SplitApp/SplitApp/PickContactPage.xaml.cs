using SplitApp.ViewModel;
using Xamarin.Forms;
namespace SplitApp
{
    public partial class PickContactPage
    {
        public PickContactPage()
        {
            InitializeComponent();
            BindingContext = new PickContactViewModel();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            (this.BindingContext as PickContactViewModel)?.SelectContactCommand.Execute(e.Item);
        }
    }
}
