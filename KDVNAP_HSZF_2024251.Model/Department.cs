using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDVNAP_HSZF_2024251.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FactoryId { get; set; }
        public Factory Factory { get; set; }  // Kapcsolat a Factory osztállyal
        public List<Employee> Employees { get; set; } = new();
    }
}
