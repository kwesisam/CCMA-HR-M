using SQLite;
using HRM_PT.DbModel;

namespace HRM_PT;
public class LoginsRepository
{
    private static SQLiteConnection conn;
    string _dbPath;

    public string statusMessage { get; set; }

    public bool done { get; set; }

    public bool testData { get; set; }

    private void Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteConnection(_dbPath);
        conn.CreateTable<Logins>();
    }

    public LoginsRepository(string dbPath)
    {
        _dbPath = dbPath;
    }


    public void AddNewEmployee(string _staffID, string _firstName, string _surname, string _password)
    {
        try
        {
            int result = 0;
            Init();

            var employeeInformation = new Logins
            {
                staffID = _staffID,
                firstName = _firstName,
                surname = _surname,
                password = _password

            };

            result = conn.Insert(employeeInformation);
            statusMessage = "Success";
        }catch (Exception e)
        {
            statusMessage = string.Format("Failed to add {0} {1}", e.Message, _staffID);
        }
    }

    public List<Logins> CheckUserStaffID(string _staffID)
    {
        try
        {
            Init();

            Logins test = conn.Table<Logins>().FirstOrDefault(e => e.staffID == _staffID);
            
            if(test != null)
            {
                statusMessage = "Success";
                return conn.Table<Logins>().Where(e => e.staffID == _staffID).ToList();

            }
            else
            {
                statusMessage = "error";
            }
        }catch (Exception e)
        {
            statusMessage = string.Format("Invalid staff ID or password");
        }

        return new List<Logins>();
    }

    public List<Logins> CheckUser(string _staffID, string _password)
    {
        try
        {
            Init();

            Logins test = conn.Table<Logins>().FirstOrDefault(e => e.staffID == _staffID && e.password == _password);

            if (test != null)
            {
                statusMessage = "Success";

                return conn.Table<Logins>().Where(e => e.staffID == _staffID).ToList();
            }
            else
            {
                statusMessage = "error";
            }

        }
        catch (Exception e)
        {
            statusMessage = string.Format("Invalid staff ID or password");
        }

        return new List<Logins>();
    }
}

