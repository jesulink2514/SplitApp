using SplitApp.ViewModel;

namespace SplitApp.View
{
    public partial class ResultPage
    {
        public ResultPage()
        {
            InitializeComponent();
            BindingContext = new ResultPageViewModel();
        }
    }
}
