using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHR
{
    public interface IEmployee
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Remarks { get; set; }
        public DateTime WorkFrom { get; set; }
        public DateTime? DismissedOn { get; set; }

       
    }
}
