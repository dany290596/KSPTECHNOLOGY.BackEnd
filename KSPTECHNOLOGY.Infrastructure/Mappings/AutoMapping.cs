using AutoMapper;
using KSPTECHNOLOGY.Domain.Entities.Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPTECHNOLOGY.Infrastructure.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            ConfigureMappings();
        }

        private void ConfigureMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                /** Response */
                CreateMap<Empleado, Models.Response.Empresa.EmpleadoDTO>().ReverseMap();

                CreateMap<Beneficiario, Models.Response.Empresa.BeneficiarioDTO>().ReverseMap();

                /** Request */
                CreateMap<Empleado, Models.Request.Empresa.EmpleadoDTO>().ReverseMap();

                CreateMap<Beneficiario, Models.Request.Empresa.BeneficiarioDTO>().ReverseMap();
            });
        }
    }
}