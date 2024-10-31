using KDVNAP_HSZF_2024251.Model;
using KDVNAP_HSZF_2024251.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDVNAP_HSZF_2024251.Application
{
    public class FactoryLogic : IFactoryLogic
    {
        IRepository<Factory> repository;

        public FactoryLogic(IRepository<Factory> repository)
        {
            this.repository = repository;
        }
        public void Create(Factory factory)
        {
            try
            {
                if (factory.GetType().GetProperties().Where(x => !x.GetMethod.IsVirtual).Any(x => x.GetValue(factory) == null))
                {
                    throw new ArgumentException("A property in the object is null, therefore it cannot be added to the database.");
                }
                // If it's null (new factory property), cannot be added.
                else if (factory.Id < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(factory.Id));
                }
                else
                {
                    repository.Create(factory);
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

        public Factory Read(int id)
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

        public IQueryable<Factory> ReadAll()
        {
            return repository.ReadAll();
        }

        public void Update(Factory factory)
        {
            try
            {
                if (factory.GetType().GetProperties().Where(x => !x.GetMethod.IsVirtual).Any(x => x.GetValue(factory) == null))
                {
                    throw new ArgumentException("A property in the object is null, therefore it cannot be updated to the database.");
                }
                // If it's null (new factory property), cannot be updated.
                else
                {
                    repository.Update(factory);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
