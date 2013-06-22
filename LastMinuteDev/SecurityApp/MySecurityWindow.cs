namespace SecurityApp
{
    using System;
    using System.Windows;

    public class MySecurityWindow : Window
    {
        public MySecurityWindow()
        {
            this.Resources.MergedDictionaries.Clear();

            ResourceDictionary myResourceDictionary = new ResourceDictionary();

            myResourceDictionary.Source =
                new Uri(@"/SecurityApp;component/Resources/SecurityResources.xaml",
                    UriKind.Relative);

            this.Resources.MergedDictionaries.Add(myResourceDictionary);

            var res = this.TryFindResource("securityDataController");
            this.SecurityDataController = res as SecurityDataController;
        }

        public static readonly DependencyProperty SecurityDataControllerProperty =
            DependencyProperty.Register("SecurityDataController", typeof(SecurityDataController), typeof(MySecurityWindow));

        public SecurityDataController SecurityDataController
        {
            get { return (SecurityDataController)GetValue(SecurityDataControllerProperty); }
            set{ SetValue(SecurityDataControllerProperty, value); }
        }
    }
}
