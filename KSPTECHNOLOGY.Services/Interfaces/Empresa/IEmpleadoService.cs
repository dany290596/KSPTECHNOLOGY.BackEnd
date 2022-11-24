using KSPTECHNOLOGY.Domain.Entities.Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPTECHNOLOGY.Services.Interfaces.Empresa
{
    public interface IEmpleadoService
    {
        Task<bool> PostEmployee(Empleado empleado);

        Task<bool> UpdateEmployee(Empleado empleado);

        IEnumerable<Empleado> GetEmployee();

        Task<bool> Inactivate(Guid id);

        Task<bool> Activate(Guid id);

        Task<Empleado> GetEmployeeById(Guid id);
    }
}