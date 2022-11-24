using KSPTECHNOLOGY.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPTECHNOLOGY.Domain.Entities.Empresa
{
    public class Empleado : BaseEntity
    {
        public Empleado()
        {
            Beneficiario = new HashSet<Beneficiario>();
        }

        public string Foto { get; set; }

        public string Nombre { get; set; }

        public string Puesto { get; set; }

        public double Salario { get; set; }

        public byte Estatus { get; set; }

        public DateTime FechaContratacion { get; set; }

        public virtual ICollection<Beneficiario> Beneficiario { get; set; }
    }
}