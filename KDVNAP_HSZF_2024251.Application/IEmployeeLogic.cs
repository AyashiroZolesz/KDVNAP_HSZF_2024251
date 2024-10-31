using KDVNAP_HSZF_2024251.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDVNAP_HSZF_2024251.Application
{
    public interface IEmployeeLogic
    {
        void Create(Employee employee);
        void Delete(int id);
        Employee Read(int id);
        IQueryable<Employee> ReadAll();
        void Update(Employee employee);
    }
}
