
using SQLite;
using HRM_PT.DbModel;
namespace HRM_PT;
    public class PerformanceRepository
    {
    private static SQLiteConnection conn;
    string _dbPath;

    public string statusMessage { get; set; }
    public bool done { get; set; }

    private void Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteConnection(_dbPath);
        conn.CreateTable<PerformanceDB>();

    }

    public PerformanceRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    public void AddData(string _departmentName, string _planningStage, string _midYear, string _endYear)
    {
        try
        {
            int result = 0;
            Init();

            var departmentInformation = new PerformanceDB
            {
                departmentName = _departmentName,
                planningStage = _planningStage,
                midYear = _midYear,
                endYear = _endYear
            };

            result = conn.Insert(departmentInformation);
            statusMessage = "Success";
        }catch(Exception e)
        {
            statusMessage = string.Format("Failed to add {0} {1}", e.Message, _departmentName);
        }

    }

    public List<PerformanceDB> GetAllPeople()
    {
        try
        {
            Init();
            return conn.Table<PerformanceDB>().ToList();
        }catch(Exception e)
        {
            statusMessage = string.Format("Failed to retrieve data. {0} ", e.Message);
        }

        return new List<PerformanceDB>();
    }
    public bool UpdateData(string department, string _departmentName, string _planningStage, string _midYear, string _endYear)
    {
        try
        {
            Init();
            PerformanceDB dataUpdate = conn.Table<PerformanceDB>().FirstOrDefault(e => e.departmentName == department);
        
            if(dataUpdate != null)
            {
                dataUpdate.departmentName = _departmentName;
                dataUpdate.planningStage = _planningStage;
                dataUpdate.midYear = _midYear;
                dataUpdate.endYear = _endYear;

                conn.Update(dataUpdate);
                statusMessage = string.Format("{0} updated successfully.", department);

                return true;
            }
            else
            {
                statusMessage = string.Format("{0} does not exist", department);
                return false;
            }
        }catch(Exception e)
        {
            statusMessage = string.Format("Failed to update data. {0}", e.Message);
                return false;
        }
    }

    }

