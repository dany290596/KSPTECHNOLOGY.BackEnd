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
    public class EmpleadoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmpleadoService _empleadoService;
        public EmpleadoController(
            IMapper mapper,
            IEmpleadoService empleadoService
            )
        {
            _mapper = mapper;
            _empleadoService = empleadoService;
        }

        [Route("Crear")]
        [HttpPost]
        public async Task<IActionResult> Create(Models.Request.Empresa.EmpleadoDTO data)
        {
            var empleado = _mapper.Map<Empleado>(data);

            await _empleadoService.PostEmployee(empleado);

            Models.Response.Empresa.EmpleadoDTO empleadoDTO = _mapper.Map<Models.Response.Empresa.EmpleadoDTO>(empleado);

            var response = new ApiResponse<Models.Response.Empresa.EmpleadoDTO>(true, "Se insertó correctamente", 200, empleadoDTO);

            return StatusCode(200, response);
        }

        [Route("Actualizar")]
        [HttpPut]
        public async Task<IActionResult> Update([Required] Guid id, Models.Request.Empresa.EmpleadoDTO data)
        {
            var empleado = _mapper.Map<Empleado>(data);
            empleado.Id = id;

            var result = await _empleadoService.UpdateEmployee(empleado);
            var response = new ApiResponse<bool>(true, "Se actualizó correctamente", 200, result);

            return StatusCode(200, response);
        }

        [Route("Obtener")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetEmployee()
        {
            var empleado = _empleadoService.GetEmployee();
            var empleadoDTO = _mapper.Map<IEnumerable<Models.Response.Empresa.EmpleadoDTO>>(empleado);
            var response = new ApiResponse<IEnumerable<Models.Response.Empresa.EmpleadoDTO>>(true, "Consulta ejecutada", 200, empleadoDTO);

            return StatusCode(200, response);
        }

        [Route("Activar")]
        [HttpPatch]
        public async Task<IActionResult> PatchActivate([Required] Guid id)
        {
            var result = await _empleadoService.Activate(id);
            var response = new ApiResponse<bool>(true, "Se activo correctamente", 200, result);

            return StatusCode(200, response);
        }

        [Route("Inactivar")]
        [HttpPatch]
        public async Task<IActionResult> PatchInactivate([Required] Guid id)
        {
            var result = await _empleadoService.Inactivate(id);
            var response = new ApiResponse<bool>(true, "Se inactivó correctamente", 200, result);

            return StatusCode(200, response);
        }

        [Route("ObtenerPorId")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetEmployeeById([Required] Guid id)
        {
            var empleado = await _empleadoService.GetEmployeeById(id);
            var empleadoDTO = _mapper.Map<Models.Response.Empresa.EmpleadoDTO>(empleado);
            var response = new ApiResponse<Models.Response.Empresa.EmpleadoDTO>(true, "Consulta ejecutada", 200, empleadoDTO);

            return StatusCode(200, response);
        }
    }
}