using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_EmployeeConsoleAppWithDALAssignment.Models
{
    public class EmployeeModel
    {
        public string Name { get; set; }    
        public string DateOfBirth { get; set; }
        public string EmploymentStartDate { get; set; }
        public string EmploymentEndDate { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
