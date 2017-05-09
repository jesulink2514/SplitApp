namespace SplitApp.Infrastructure
{
    public static class NavigationService
    {
        private static object _navigationParameter;
        public static void SetNavigationParameter<T>(T parameter)
        {
            _navigationParameter = parameter;
        }
        public static T GetNavigationParameter<T>() where T : class
        {
            var nav = _navigationParameter as T;
            _navigationParameter = null;
            return nav;
        }

        public static bool HasParameter => _navigationParameter != null;
    }
}
