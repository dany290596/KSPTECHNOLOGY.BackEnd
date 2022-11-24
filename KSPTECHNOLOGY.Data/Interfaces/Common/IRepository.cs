using KSPTECHNOLOGY.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPTECHNOLOGY.Data.Interfaces.Common
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        Task<T> GetById(Guid id);

        Task Add(T t);

        void Update(T t);

        Task Delete(Guid id);
    }
}