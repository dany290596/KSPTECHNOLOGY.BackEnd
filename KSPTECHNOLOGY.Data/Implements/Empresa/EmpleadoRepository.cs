using KSPTECHNOLOGY.Data.Context;
using KSPTECHNOLOGY.Data.Implements.Common;
using KSPTECHNOLOGY.Data.Interfaces.Empresa;
using KSPTECHNOLOGY.Domain.Entities.Empresa;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KSPTECHNOLOGY.Data.Implements.Empresa
{
    public class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(KSPTECHNOLOGYContext context) : base(context) { }

        public Empleado GetFirstOrDefaultEmployee(Expression<Func<Empleado, bool>> predicate)
        {
            return _context.Empleado.Include(i => i.Beneficiario).FirstOrDefault(predicate);
        }
    }
}