namespace HRM_PT
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
            SetBackButtonBehavior(this, new BackButtonBehavior { IsEnabled = false });

        }
    }
}