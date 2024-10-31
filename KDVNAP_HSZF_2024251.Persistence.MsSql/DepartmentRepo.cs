using KDVNAP_HSZF_2024251.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDVNAP_HSZF_2024251.Persistence.MsSql
{
    public class DepartmentRepo : GenericRepository<Department>, IRepository<Department>
    {
        public DepartmentRepo(AppDbContext ctx) : base(ctx) { }
        public override Department Read(int id)
        {
            return context.Departments.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Department item)
        {
            var oldDepartment = Read(item.Id);
            foreach (var property in oldDepartment.GetType().GetProperties())
            {
                if (property.GetAccessors().FirstOrDefault(x => x.IsVirtual) == null)
                {
                    property.SetValue(oldDepartment, property.GetValue(item)); // Value swap
                }
            }
            context.SaveChanges();
        }
    }
}
