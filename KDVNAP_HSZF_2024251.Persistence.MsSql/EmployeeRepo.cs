using KDVNAP_HSZF_2024251.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDVNAP_HSZF_2024251.Persistence.MsSql
{
    public class EmployeeRepo : GenericRepository<Employee>, IRepository<Employee>
    {
        public EmployeeRepo(AppDbContext ctx) : base(ctx) { }
        public override Employee Read(int id)
        {
            return context.Employees.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Employee item)
        {
            var oldEmp = Read(item.Id);
            foreach (var property in oldEmp.GetType().GetProperties())
            {
                if (property.GetAccessors().FirstOrDefault(x => x.IsVirtual) == null)
                {
                    property.SetValue(oldEmp, property.GetValue(item)); // Value swap
                }
            }
            context.SaveChanges();
        }
    }
}
