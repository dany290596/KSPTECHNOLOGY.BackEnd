using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPTECHNOLOGY.Models.Request.Empresa
{
    public class EmpleadoDTO
    {
        public string Foto { get; set; }

        public string Nombre { get; set; }

        public string Puesto { get; set; }

        public double Salario { get; set; }

        public virtual ICollection<BeneficiarioDTO>? Beneficiario { get; set; } = null!;
    }
}