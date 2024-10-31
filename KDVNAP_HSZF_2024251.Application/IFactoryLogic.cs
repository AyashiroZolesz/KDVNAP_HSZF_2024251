using KDVNAP_HSZF_2024251.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDVNAP_HSZF_2024251.Application
{
    public interface IFactoryLogic
    {
        void Create(Factory factory);
        void Delete(int id);
        Factory Read(int id);
        IQueryable<Factory> ReadAll();
        void Update(Factory factory);
    }
}
