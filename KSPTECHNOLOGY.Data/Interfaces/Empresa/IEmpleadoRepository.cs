using KSPTECHNOLOGY.Data.Interfaces.Common;
using KSPTECHNOLOGY.Domain.Entities.Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KSPTECHNOLOGY.Data.Interfaces.Empresa
{
    public interface IEmpleadoRepository : IRepository<Empleado>
    {
        Empleado GetFirstOrDefaultEmployee(Expression<Func<Empleado, bool>> predicate);
    }
}