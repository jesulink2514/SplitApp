using SplitApp.ViewModel;
using Xamarin.Forms;

namespace SplitApp.View
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var vm = this.BindingContext as MainPageViewModel;
            vm.EditCostCommand.Execute(e.Item);
            (sender as ListView).SelectedItem = null;
        }
    }
}
