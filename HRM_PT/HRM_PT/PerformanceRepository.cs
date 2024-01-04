
using SQLite;
using HRM_PT.DbModel;
namespace HRM_PT;
    public class PerformanceRepository
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
        await conn.CreateTableAsync<PerformanceDB>();

    }

    public PerformanceRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    public async Task AddData(string _departmentName, string _planningStage, string _midYear, string _endYear)
    {
        try
        {
            int result = 0;
            await Init();

            var departmentInformation = new PerformanceDB
            {
                departmentName = _departmentName,
                planningStage = _planningStage,
                midYear = _midYear,
                endYear = _endYear
            };

            result = await conn.InsertAsync(departmentInformation);
            statusMessage = "Success";
        }catch(Exception e)
        {
            statusMessage = string.Format("Failed to add {0} {1}", e.Message, _departmentName);
        }

    }


    public async Task<List<PerformanceDB>> GetPerformanceRecord(string _department)
    {
        try
        {
            await Init();
            PerformanceDB test = await conn.Table<PerformanceDB>().FirstOrDefaultAsync(e => e.departmentName == _department);
            if(test != null)
            {
                statusMessage = "success";
                done = true;
                testData = true;
                return await conn.Table<PerformanceDB>().Where(e => e.departmentName == _department).ToListAsync();
            }
            else
            {
                statusMessage = string.Format("{0} does not exist.", _department);
                testData = false;
            }
        }catch( Exception e)
        {
            done = true;
            statusMessage = string.Format("Failed to retrieve data. {0}", e.Message);
        }

        return new List<PerformanceDB>();
    }
    public async Task<List<PerformanceDB>> GetAllPeople()
    {
        try
        {
            await Init();
            return await conn.Table<PerformanceDB>().ToListAsync();
        }catch(Exception e)
        {
            statusMessage = string.Format("Failed to retrieve data. {0} ", e.Message);
        }

        return new List<PerformanceDB>();
    }
    public async Task<bool> UpdateData(string department, string _departmentName, string _planningStage, string _midYear, string _endYear)
    {
        try
        {
            await Init();
            PerformanceDB dataUpdate = await conn.Table<PerformanceDB>().FirstOrDefaultAsync(e => e.departmentName == department);
        
            if(dataUpdate != null)
            {
                dataUpdate.departmentName = _departmentName;
                dataUpdate.planningStage = _planningStage;
                dataUpdate.midYear = _midYear;
                dataUpdate.endYear = _endYear;

                await conn.UpdateAsync(dataUpdate);
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

    public async Task<bool> DeletePerformanceData(string _department)
    {
        try
        {
            await Init();
            PerformanceDB deleteData = await conn.Table<PerformanceDB>().FirstOrDefaultAsync(e => e.departmentName == _department);
            if(deleteData != null)
            {
                await conn.DeleteAsync(deleteData);
                statusMessage = string.Format("{0} delete successful", _department);
                return true;
            }
            else
            {
                statusMessage = string.Format("{0} does not exist.", _department);
                return false;
            }
        }catch(Exception e)
        {
            statusMessage = string.Format("failed to delete data. {0}", e.Message);
            return false;
        }
    }


    }

