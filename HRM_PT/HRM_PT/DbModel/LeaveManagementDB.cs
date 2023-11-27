using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace HRM_PT.DbModel;
    [Table("leave_tb")]
    public class LeaveManagementDB
    {

    [PrimaryKey, Unique]
    public string staffID { get; set; }

    [MaxLength(100)]
    public string dateApplied { get; set; }

    [MaxLength(200)]
    public string nameOFHOD { get; set; }

    [MaxLength(100)]
    public string daysRequested { get; set; }

    [MaxLength(150)]
    public string typeOfLeave { get; set; }

    [MaxLength(100)]
    public string resumptionDate { get; set; }

    [MaxLength(150)]
    public string takenOverOfficer { get; set; }

    [MaxLength(100)]
    public string approvedDate { get; set; }

    [MaxLength(100)]
    public string totalLeave { get; set; }



}

