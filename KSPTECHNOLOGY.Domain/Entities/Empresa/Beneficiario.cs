using KSPTECHNOLOGY.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPTECHNOLOGY.Domain.Entities.Empresa
{
    public class Beneficiario : BaseEntity
    {
        public string Nombre { get; set; }

        public string Parentesco { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Sexo { get; set; }

        public Guid EmpleadoId { get; set; }

        public virtual Empleado Empleado { get; set; } = null!;
    }
}