namespace HRM_PT
{
    public partial class App : Application
    {
        public static EmployeeRepository EmployeeRep { get; private set; }
        public static LeaveRepository LeaveRep { get; private set; }
        public static LoginsRepository LoginsRep { get; private set; }
        public App(EmployeeRepository repo, LeaveRepository leaveR, LoginsRepository lrep)
        {

            InitializeComponent();

            MainPage = new AppShell();

            EmployeeRep = repo; 
            LeaveRep = leaveR;
            LoginsRep = lrep;
        }
    }
}