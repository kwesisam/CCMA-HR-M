using SQLite;

namespace HRM_PT.DbModel;

    [Table("performance_db")]
    public class PerformanceDB
    {
    [MaxLength(150)]
    public string departmentName { get; set; }
    [MaxLength(50)]
    public string planningStage { get; set; }
    [MaxLength(50)]
    public string midYear { get; set; }
    [MaxLength(50)]
    public string endYear { get; set; }


    }

