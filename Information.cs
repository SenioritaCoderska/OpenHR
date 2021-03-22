using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHR
{
    public class Information : IEmployee, IAddress, ISalary
    {
        public int Id { get; set; }
        public string FirstName { get ; set ; }
        public string LastName { get; set ; }

        public DateTime WorkFrom { get; set ; }
        public DateTime? DismissedOn { get ; set ; }

        public string Street { get ; set ; }
        public string City { get ; set ; }
        public string ZipCode { get ; set ; }
        public int Salary { get ; set ; }
        public string Remarks { get ; set ; }
        
    }
}
