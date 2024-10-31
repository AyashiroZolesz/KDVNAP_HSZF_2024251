using KDVNAP_HSZF_2024251.Model;
using KDVNAP_HSZF_2024251.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDVNAP_HSZF_2024251.Application
{
    public class EmployeeLogic : IEmployeeLogic
    {
        IRepository<Employee> repository;

        public EmployeeLogic(IRepository<Employee> repository)
        {
            this.repository = repository;
        }
        public void Create(Employee employee)
        {
            try
            {
                if (employee.GetType().GetProperties().Where(x => !x.GetMethod.IsVirtual).Any(x => x.GetValue(employee) == null))
                {
                    throw new ArgumentException("A property in the object is null, therefore it cannot be added to the database.");
                }
                // If it's null (new employee property), cannot be added.
                else if (employee.Id < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(employee.Id));
                }
                else
                {
                    repository.Create(employee);
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

        public Employee Read(int id)
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

        public IQueryable<Employee> ReadAll()
        {
            return repository.ReadAll();
        }

        public void Update(Employee employee)
        {
            try
            {
                if (employee.GetType().GetProperties().Where(x => !x.GetMethod.IsVirtual).Any(x => x.GetValue(employee) == null))
                {
                    throw new ArgumentException("A property in the object is null, therefore it cannot be updated to the database.");
                }
                // If it's null (new department property), cannot be updated.
                else
                {
                    repository.Update(employee);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
