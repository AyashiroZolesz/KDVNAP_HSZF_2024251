using KDVNAP_HSZF_2024251.Model;
using KDVNAP_HSZF_2024251.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDVNAP_HSZF_2024251.Application
{
    public class DepartmentLogic : IDepartmentLogic
    {
        IRepository<Department> repository;

        public DepartmentLogic(IRepository<Department> repository)
        {
            this.repository = repository;
        }
        public void Create(Department department)
        {
            try
            {
                if (department.GetType().GetProperties().Where(x => !x.GetMethod.IsVirtual).Any(x => x.GetValue(department) == null))
                {
                    throw new ArgumentException("A property in the object is null, therefore it cannot be added to the database.");
                }
                // If it's null (new department property), cannot be added.
                else if (department.Id < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(department.Id));
                }
                else
                {
                    repository.Create(department);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                if (id < 0)
                {
                    throw new ArgumentOutOfRangeException("id");
                }
                else
                {
                    repository.Delete(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Department Read(int id)
        {
            try
            {
                if (id < 0)
                {
                    throw new ArgumentOutOfRangeException("id");
                }
                else
                {
                    return repository.Read(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<Department> ReadAll()
        {
            return repository.ReadAll();
        }

        public void Update(Department department)
        {
            try
            {
                if (department.GetType().GetProperties().Where(x => !x.GetMethod.IsVirtual).Any(x => x.GetValue(department) == null))
                {
                    throw new ArgumentException("A property in the object is null, therefore it cannot be updated to the database.");
                }
                // If it's null (new department property), cannot be updated.
                else
                {
                    repository.Update(department);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
