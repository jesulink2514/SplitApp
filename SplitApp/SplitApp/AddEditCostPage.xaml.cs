using SplitApp.ViewModel;
using Xamarin.Forms;
namespace SplitApp
{
    public partial class AddEditCostPage
    {
        public AddEditCostPage()
        {
            InitializeComponent();
            BindingContext = new AddEditViewModel();
        }
    }
}
