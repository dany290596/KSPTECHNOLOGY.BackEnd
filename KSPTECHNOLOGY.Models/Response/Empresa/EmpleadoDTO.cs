using KSPTECHNOLOGY.Models.Response.Common;

namespace KSPTECHNOLOGY.Models.Response.Empresa
{
    public class EmpleadoDTO : BaseEntityDTO
    {
        public string Foto { get; set; }

        public string Nombre { get; set; }

        public string Puesto { get; set; }

        public double Salario { get; set; }

        public byte Estatus { get; set; }

        public DateTime FechaContratacion { get; set; }

        public virtual ICollection<BeneficiarioDTO> Beneficiario { get; set; }
    }
}
