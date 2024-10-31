using KDVNAP_HSZF_2024251.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDVNAP_HSZF_2024251.Persistence.MsSql
{
    public class FactoryRepo : GenericRepository<Factory>, IRepository<Factory>
    {
        public FactoryRepo(AppDbContext ctx) : base(ctx) { }
        public override Factory Read(int id)
        {
            return context.Factories.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Factory item)
        {
            var oldFactory = Read(item.Id);
            foreach (var property in oldFactory.GetType().GetProperties())
            {
                if (property.GetAccessors().FirstOrDefault(x => x.IsVirtual) == null)
                {
                    property.SetValue(oldFactory, property.GetValue(item)); // Value swap
                }
            }
            context.SaveChanges();
        }
    }
}
