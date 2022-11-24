using KSPTECHNOLOGY.Models.Response.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPTECHNOLOGY.Models.Request.Empresa
{
    public class BeneficiarioDTO
    {
        public string Nombre { get; set; }

        public string Parentesco { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Sexo { get; set; }

        public Guid EmpleadoId { get; set; }
    }
}