using SplitApp.ViewModel;

namespace SplitApp.View
{
    public partial class AddEditCostPage
    {
        public AddEditCostPage()
        {
            InitializeComponent();
            BindingContext = new AddEditCostViewModel();
        }
    }
}
