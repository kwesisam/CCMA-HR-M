using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using HRM_PT.DbModel;

namespace HRM_PT;


    public class LeaveRepository
    {
    private static SQLiteAsyncConnection conn;
    string _dbPath;

    public string message { get; set; }
    public bool done { get; set; }

    private async Task Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteAsyncConnection(_dbPath);
        await conn.CreateTableAsync<LeaveManagementDB>();

      
    }
    public LeaveRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

        
    public async Task AddLeaveEmployee(string _staffID, string _dateApplied, string _nameOfHOD, string _daysRequested, 
        string _typeOfLeave, string _resumptionDate, string _officerTakenOver, string _approvedDate, string _totalLeave)
    {
        try
        {
            int result = 0;

            await Init();
            message = string.Empty;

            var employeeInformation = new LeaveManagementDB
            {
            staffID = _staffID,
            dateApplied = _dateApplied,
            nameOFHOD = _nameOfHOD,
            daysRequested = _daysRequested,
            typeOfLeave = _typeOfLeave,
            resumptionDate = _resumptionDate,
            takenOverOfficer = _officerTakenOver,
            approvedDate = _approvedDate,
            totalLeave = _totalLeave
            };
            message = "Success";
            done = true;
            result = await conn.InsertAsync(employeeInformation);
        }
        catch(Exception e)
        {
            message = string.Empty;

            message = string.Format("Failed to add {0}{1}", e.Message, _staffID);
            done = false;
        }
        
    }

    public async Task<List<LeaveManagementDB>>GetAllPeople()
    {
        try
        {
            await Init();
            message = string.Empty;

            return await conn.Table<LeaveManagementDB>().ToListAsync();
        }catch(Exception ex)
        {
            message = string.Empty;

            message = string.Format("failed to retrieve data. {0}", ex.Message);
        }

        return new List<LeaveManagementDB>();

    }

    public async Task<List<LeaveManagementDB>>GetPeopleByStaffID(string _staffID)
    {
        try
        {
            await Init();
            message = string.Empty;

            message = "Success";
            done = true;
            return await conn.Table<LeaveManagementDB>().Where(e => e.staffID == _staffID).ToListAsync();
        }catch(Exception e)
        {
            message = string.Empty;

            message = String.Format("Failed to retriev data.{0}{1}", e.Message, _staffID);
            done = false;
        }

        
        return new List<LeaveManagementDB>();
    }

    public async Task<bool> UpdateAddLeaveEmployee(string staffID_, string _staffID, string _dateApplied, string _nameOfHOD, string _daysRequested,
        string _typeOfLeave, string _resumptionDate, string _officerTakenOver, string _approvedDate, string _totalLeave)
    {
        try
        {
            await Init();
            message = string.Empty;

            LeaveManagementDB leaveUpdate = await conn.Table<LeaveManagementDB>().FirstOrDefaultAsync(e => e.staffID == staffID_);
            if(leaveUpdate != null) 
            {
                leaveUpdate.staffID = _staffID;
                leaveUpdate.dateApplied = _dateApplied;
                leaveUpdate.nameOFHOD = _nameOfHOD;
                leaveUpdate.daysRequested = _daysRequested;
                leaveUpdate.typeOfLeave = _typeOfLeave;
                leaveUpdate.resumptionDate = _resumptionDate;
                leaveUpdate.takenOverOfficer = _officerTakenOver;
                leaveUpdate.approvedDate = _approvedDate;
                leaveUpdate.totalLeave = _totalLeave;

                await conn.UpdateAsync(leaveUpdate);
                message = string.Format("{0} deleted successfully", staffID_);
                return true;
            }
            else
            {

                message = string.Format("{0} does not exist", staffID_);
                return false;
            }
        }catch (Exception e)
        {
            message = string.Empty;

            message = string.Format("failed to update data.{0}", e.Message);
            return false;
        }
    }

    public async Task<bool> DeleteAddLeaveEmployee(string _staffID)
    {
        try
        {
            await Init();
            message = string.Empty;

            LeaveManagementDB deleteDate = await conn.Table<LeaveManagementDB>().FirstOrDefaultAsync(e => e.staffID == _staffID);
            if (deleteDate != null)
            {
                await conn.DeleteAsync(deleteDate);
                message = string.Format("{0} deleted successfully", _staffID);
                return true;
            }
            else
            {
                message = string.Format("{0} does not exist", _staffID);
                return false;
            }
        }catch(Exception e)
        {
            message = string.Empty;

            message = string.Format("failed to delete data.{0}", e.Message);
            return false;
        }
       
    }
}

