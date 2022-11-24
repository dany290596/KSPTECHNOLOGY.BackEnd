using AutoMapper;
using KSPTECHNOLOGY.Domain.Entities.Empresa;
using KSPTECHNOLOGY.Services.Interfaces.Empresa;
using KSPTECHNOLOGY.Services.Responses;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace KSPTECHNOLOGY.Controllers.Empresa
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Empresa")]
    public class BeneficiarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBeneficiarioService _beneficiarioService;

        public BeneficiarioController(
            IMapper mapper,
            IBeneficiarioService beneficiarioService
            )
        {
            _mapper = mapper;
            _beneficiarioService = beneficiarioService;
        }

        [Route("Crear")]
        [HttpPost]
        public async Task<IActionResult> Create(Models.Request.Empresa.BeneficiarioDTO data)
        {
            var beneficiario = _mapper.Map<Beneficiario>(data);

            await _beneficiarioService.PostBeneficiary(beneficiario);

            Models.Response.Empresa.BeneficiarioDTO beneficiarioDTO = _mapper.Map<Models.Response.Empresa.BeneficiarioDTO>(beneficiario);

            var response = new ApiResponse<Models.Response.Empresa.BeneficiarioDTO>(true, "Se insertó correctamente", 200, beneficiarioDTO);

            return StatusCode(200, response);
        }

        [Route("Actualizar")]
        [HttpPut]
        public async Task<IActionResult> Update([Required] Guid id, Models.Request.Empresa.BeneficiarioDTO data)
        {
            var beneficiario = _mapper.Map<Beneficiario>(data);
            beneficiario.Id = id;

            var result = await _beneficiarioService.UpdateBeneficiary(beneficiario);
            var response = new ApiResponse<bool>(true, "Se actualizó correctamente", 200, result);

            return StatusCode(200, response);
        }


        [Route("ObtenerPorSexo")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetEmployeeBySex()
        {
            List<Models.Response.Empresa.TipoSexoDTO> listDTO = new List<Models.Response.Empresa.TipoSexoDTO>();

            listDTO.Add(new Models.Response.Empresa.TipoSexoDTO() { Sexo = "M", Descripcion = "Masculino" });
            listDTO.Add(new Models.Response.Empresa.TipoSexoDTO() { Sexo = "F", Descripcion = "Femenino" });
            listDTO.Add(new Models.Response.Empresa.TipoSexoDTO() { Sexo = "O", Descripcion = "Otro" });

            var response = new ApiResponse<List<Models.Response.Empresa.TipoSexoDTO>>(true, "Consulta ejecutada", 200, listDTO);

            return StatusCode(200, response);
        }
    }
}