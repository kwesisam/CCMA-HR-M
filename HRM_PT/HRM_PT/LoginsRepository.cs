using SQLite;
using HRM_PT.DbModel;

namespace HRM_PT;
public class LoginsRepository
{
    private static SQLiteAsyncConnection conn;
    string _dbPath;

    public string statusMessage { get; set; }

    public bool done { get; set; }

    public bool testData { get; set; }

    private async Task Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteAsyncConnection(_dbPath);
        await conn.CreateTableAsync<Logins>();
    }

    public LoginsRepository(string dbPath)
    {
        _dbPath = dbPath;
    }


    public async Task AddNewEmployee(string _staffID, string _firstName, string _surname, string _password)
    {
        try
        {
            int result = 0;
            await Init();
            statusMessage = string.Empty;

            var employeeInformation = new Logins
            {
                staffID = _staffID,
                firstName = _firstName,
                surname = _surname,
                password = _password

            };

            result = await conn.InsertAsync(employeeInformation);
            statusMessage = "Success";
        }catch (Exception e)
        {
            statusMessage = string.Empty;

            statusMessage = string.Format("Failed to add {0} {1}", e.Message, _staffID);
        }
    }

    public async Task<List<Logins>> CheckUserStaffID(string _staffID)
    {
        try
        {
            await Init();
            statusMessage = string.Empty;

            Logins test = await conn.Table<Logins>().FirstOrDefaultAsync(e => e.staffID == _staffID);
            
            if(test != null)
            {
                statusMessage = "Success";
                return await conn.Table<Logins>().Where(e => e.staffID == _staffID).ToListAsync();

            }
            else
            {
                statusMessage = "error";
            }
        }catch (Exception e)
        {
            statusMessage = string.Empty;

            statusMessage = string.Format("Invalid staff ID or password");
        }

        return new List<Logins>();
    }

    public async Task<List<Logins>> CheckUser(string _staffID, string _password)
    {
        try
        {
            await Init();
            statusMessage = string.Empty;

            Logins test =await conn.Table<Logins>().FirstOrDefaultAsync(e => e.staffID == _staffID && e.password == _password);

            if (test != null)
            {
                statusMessage = "Success";

                return await  conn.Table<Logins>().Where(e => e.staffID == _staffID).ToListAsync();
            }
            else
            {
                statusMessage = "error";
            }

        }
        catch (Exception e)
        {
            statusMessage = string.Empty;

            statusMessage = string.Format("Invalid staff ID or password");
        }

        return new List<Logins>();
    }
}

