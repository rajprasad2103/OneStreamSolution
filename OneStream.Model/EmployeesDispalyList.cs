using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStream.Model
{
    public class EmployeesDispalyList
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public int DepartId { get; set; }
        public string? DepartName { get; set; }
    }
}
