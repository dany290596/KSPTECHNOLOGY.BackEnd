using KSPTECHNOLOGY.Data.Context;
using KSPTECHNOLOGY.Data.Implements.Common;
using KSPTECHNOLOGY.Data.Interfaces.Empresa;
using KSPTECHNOLOGY.Domain.Entities.Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPTECHNOLOGY.Data.Implements.Empresa
{
    public class BeneficiarioRepository : Repository<Beneficiario>, IBeneficiarioRepository
    {
        public BeneficiarioRepository(KSPTECHNOLOGYContext context) : base(context) { }

        public void DeleteByBeneficiary(Guid employeeId)
        {
            _context.Beneficiario.RemoveRange(_context.Beneficiario.Where(x => x.EmpleadoId == employeeId));
        }
    }
}