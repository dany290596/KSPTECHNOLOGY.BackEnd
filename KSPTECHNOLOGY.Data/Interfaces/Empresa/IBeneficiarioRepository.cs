using KSPTECHNOLOGY.Data.Interfaces.Common;
using KSPTECHNOLOGY.Domain.Entities.Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPTECHNOLOGY.Data.Interfaces.Empresa
{
    public interface IBeneficiarioRepository : IRepository<Beneficiario>
    {
        void DeleteByBeneficiary(Guid employeeId);
    }
}