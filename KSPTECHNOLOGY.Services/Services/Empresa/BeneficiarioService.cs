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
    public class BeneficiarioService : IBeneficiarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BeneficiarioService(
            IUnitOfWork unitOfWork
            )
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> PostBeneficiary(Beneficiario beneficiario)
        {
            bool booOk = false;

            try
            {
                beneficiario.Id = Guid.NewGuid();
                beneficiario.FechaCreacion = DateTime.Now;

                await _unitOfWork.BeneficiarioRepository.Add(beneficiario);

                await _unitOfWork.SaveChangesAsync();

                booOk = true;
            }
            catch (Exception ex)
            {
                booOk = false;
            }

            return booOk;
        }

        public async Task<bool> UpdateBeneficiary(Beneficiario beneficiario)
        {
            Beneficiario currentBeneficiario = await _unitOfWork.BeneficiarioRepository.GetById(beneficiario.Id);

            currentBeneficiario.Nombre = beneficiario.Nombre;
            currentBeneficiario.Parentesco = beneficiario.Parentesco;
            currentBeneficiario.FechaNacimiento = beneficiario.FechaNacimiento;
            currentBeneficiario.Sexo = beneficiario.Sexo;
            currentBeneficiario.FechaModificacion = DateTime.Now;

            _unitOfWork.BeneficiarioRepository.Update(currentBeneficiario);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteByBeneficiary(Guid employeeId)
        {
            try
            {
                if (employeeId == Guid.Empty) { return false; }

                _unitOfWork.BeneficiarioRepository.DeleteByBeneficiary(employeeId);

                return true;
            }
            catch (Exception ex)
            {
                throw;
                return false;
            }
        }

        public async Task<bool> PostBeneficiaryMultiple(ICollection<Beneficiario> beneficiario)
        {
            bool booOk = false;

            try
            {
                if (beneficiario.Count > 0)
                {
                    foreach (Beneficiario item in beneficiario)
                    {
                        await PostBeneficiarys(item);
                    }
                }

                booOk = true;
            }
            catch (Exception ex)
            {

            }

            return booOk;
        }

        public async Task PostBeneficiarys(Beneficiario beneficiario)
        {
            beneficiario.Id = Guid.NewGuid();
            beneficiario.FechaCreacion = DateTime.Now;

            await _unitOfWork.BeneficiarioRepository.Add(beneficiario);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}