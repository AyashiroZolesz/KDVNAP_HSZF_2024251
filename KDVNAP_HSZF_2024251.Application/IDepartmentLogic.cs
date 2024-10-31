using KDVNAP_HSZF_2024251.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDVNAP_HSZF_2024251.Application
{
    public interface IDepartmentLogic
    {
        void Create(Department department);
        void Delete(int  id);
        Department Read(int id);
        IQueryable<Department> ReadAll();
        void Update(Department department);

    }
}
