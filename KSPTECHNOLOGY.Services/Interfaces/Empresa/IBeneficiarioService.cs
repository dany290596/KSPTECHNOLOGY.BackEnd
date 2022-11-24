using KSPTECHNOLOGY.Domain.Entities.Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPTECHNOLOGY.Services.Interfaces.Empresa
{
    public interface IBeneficiarioService
    {
        Task<bool> DeleteByBeneficiary(Guid employeeId);

        Task<bool> PostBeneficiary(Beneficiario beneficiario);

        Task<bool> UpdateBeneficiary(Beneficiario beneficiario);

        Task<bool> PostBeneficiaryMultiple(ICollection<Beneficiario> beneficiario);

        Task PostBeneficiarys(Beneficiario beneficiario);
    }
}