using Microsoft.Build.Framework;

namespace LeaveManagement.Web.Data
{
    public class LeaveType:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int DefaultDays { get; set; }
    }
}
