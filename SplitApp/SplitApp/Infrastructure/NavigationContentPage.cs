using Xamarin.Forms;

namespace SplitApp.Infrastructure
{
    public class NavigationContentPage: ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as INavigationEvents)?.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            (this.BindingContext as INavigationEvents)?.OnDisappearing();
        }
    }
}
