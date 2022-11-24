using KSPTECHNOLOGY.Models.Response.Common;

namespace KSPTECHNOLOGY.Models.Response.Empresa
{
    public class BeneficiarioDTO : BaseEntityDTO
    {
        public string Nombre { get; set; }

        public string Parentesco { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Sexo { get; set; }

        public Guid EmpleadoId { get; set; }
    }
}