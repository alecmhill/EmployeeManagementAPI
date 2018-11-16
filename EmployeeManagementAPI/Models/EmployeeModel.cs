using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagementAPI.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public int PositionId { get; set; }
    }
}