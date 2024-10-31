using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDVNAP_HSZF_2024251.Model
{
    public class Factory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Size { get; set; }
        public List<Department> Departments { get; set; } = new();
    }
}
