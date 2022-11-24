using KSPTECHNOLOGY.Data.Interfaces.Common;
using KSPTECHNOLOGY.Domain.Entities.Empresa;
using KSPTECHNOLOGY.Services.Interfaces.Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPTECHNOLOGY.Services.Services.Empresa
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBeneficiarioService _beneficiarioService;

        public EmpleadoService(
            IUnitOfWork unitOfWork,
            IBeneficiarioService beneficiarioService
            )
        {
            _unitOfWork = unitOfWork;
            _beneficiarioService = beneficiarioService;
        }

        public async Task<bool> PostEmployee(Empleado empleado)
        {
            bool booOk = false;

            try
            {
                empleado.Id = Guid.NewGuid();
                empleado.Estatus = 1;
                empleado.FechaContratacion = DateTime.Now;
                empleado.FechaCreacion = DateTime.Now;

                if (empleado.Beneficiario.Count > 0)
                {
                    empleado.Beneficiario.ToList().ForEach(x =>
                    {
                        x.Id = Guid.NewGuid();
                        x.FechaCreacion = DateTime.Now;
                    });

                }
                await _unitOfWork.EmpleadoRepository.Add(empleado);

                await _unitOfWork.SaveChangesAsync();

                booOk = true;
            }
            catch (Exception ex)
            {
                booOk = false;
            }

            return booOk;
        }

        public async Task<bool> UpdateEmployee(Empleado empleado)
        {
            Empleado currentEmpleado = await _unitOfWork.EmpleadoRepository.GetById(empleado.Id);

            currentEmpleado.Foto = empleado.Foto;
            currentEmpleado.Nombre = empleado.Nombre;
            currentEmpleado.Puesto = empleado.Puesto;
            currentEmpleado.Salario = empleado.Salario;
            currentEmpleado.FechaModificacion = DateTime.Now;

            _unitOfWork.EmpleadoRepository.Update(currentEmpleado);

            await _unitOfWork.SaveChangesAsync();

            bool ok = await _beneficiarioService.DeleteByBeneficiary(currentEmpleado.Id);

            if (ok && empleado.Beneficiario.Count > 0)
            {
                await _beneficiarioService.PostBeneficiaryMultiple(empleado.Beneficiario);
            }

            return true;
        }

        public IEnumerable<Empleado> GetEmployee()
        {
            IEnumerable<Empleado> empleados = _unitOfWork.EmpleadoRepository.GetAll();

            return empleados;
        }

        public async Task<bool> Inactivate(Guid id)
        {
            bool booOk = false;

            try
            {
                Empleado employee = await GetEmployeeById(id);

                if (employee == null) { return false; }

                employee.FechaBaja = DateTime.Now;
                employee.Estatus = 2;

                _unitOfWork.EmpleadoRepository.Update(employee);

                await _unitOfWork.SaveChangesAsync();

                booOk = true;
            }
            catch (Exception ex)
            {
                throw;
            }

            return booOk;
        }

        public async Task<bool> Activate(Guid id)
        {
            bool booOk = false;

            try
            {
                Empleado employee = await GetEmployeeById(id);

                if (employee == null) { return false; }

                employee.FechaReactivacion = DateTime.Now;
                employee.Estatus = 1;

                _unitOfWork.EmpleadoRepository.Update(employee);

                await _unitOfWork.SaveChangesAsync();

                booOk = true;
            }
            catch (Exception ex)
            {
                throw;
            }

            return booOk;
        }

        public async Task<Empleado> GetEmployeeById(Guid id)
        {
            Empleado employee = _unitOfWork.EmpleadoRepository.GetFirstOrDefaultEmployee(g => g.Id == id);

            return employee;
        }
    }
}