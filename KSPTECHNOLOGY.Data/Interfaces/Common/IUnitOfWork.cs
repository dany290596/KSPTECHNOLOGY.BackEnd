using KSPTECHNOLOGY.Data.Interfaces.Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPTECHNOLOGY.Data.Interfaces.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IBeneficiarioRepository BeneficiarioRepository { get; }

        IEmpleadoRepository EmpleadoRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}