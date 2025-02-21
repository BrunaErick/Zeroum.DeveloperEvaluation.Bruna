using Microsoft.AspNetCore.Mvc;
using Zeroum.BI.Bruna.Interfaces;
using Zeroum.DTO.Bruna.Request;
using Zeroum.DTO.Bruna.Response;

namespace Zeroum.WebApi.Bruna.Controllers
{
    [ApiController]
    [Route("Clients")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly IClientesBI _business;
        public ClientesController(ILogger<ClientesController> logger, IClientesBI business)
        {
            _logger = logger;
            _business = business;
        }

        /// <summary>
        /// Creates a new client PJ
        /// </summary>
        /// <param name="request">The client PJ creation or edit request</param>
        /// <returns>The created client PJ details</returns>
        [HttpPost("CreateOrEditClientPJ")]
        public async Task<IActionResult> CreateOrEditClientPJ([FromBody] ClientesPJCreateRequest request)
        {
            var response = _business.CreateOrEditClientPJAsync(request);
            if (response.Result > 0)
            {
                return Created(string.Empty, new 
                {
                    Success = true,
                    Message = "Client PJ created/updated successfully",
                    Data = "Id: " + (int)response.Result
            });
            }
            else
                return BadRequest(new 
                {
                    Success = false,
                    Message = "Error",
                    Data = "Error"
                });


        }


        /// <summary>
        /// Creates a new client PF
        /// </summary>
        /// <param name="request">The client PF creation or edit request</param>
        /// <returns>The created client PF details</returns>
        [HttpPost("CreateOrEditClientPF")]
        public async Task<IActionResult> CreateOrEditClientPF([FromBody] ClientesPFCreateRequest request)
        {
            var response = _business.CreateOrEditClientPFAsync(request);
            if (response.Result > 0)
            {
                return Created(string.Empty, new
                {
                    Success = true,
                    Message = "Client PF created/updated successfully",
                    Data = "Id: " + (int)response.Result
                });
            }
            else
                return BadRequest(new
                {
                    Success = false,
                    Message = "Error",
                    Data = "Error"
                });


        }

        /// <summary>
        /// Retrieves all Clients PF
        /// </summary>
        [HttpGet("GetAllClientPF")]
        public async Task<IActionResult> GetAllClientsPFAsync()
        {
            var response = _business.GetAllClientsPFAsync();

            if ((response.Result).Count > 0)
                return Ok(new
                {
                    Success = true,
                    Message = "Clients PF retrieved successfully",
                    Data = response.Result
                });
            else
                return NotFound(new 
                {
                    Success = false,
                    Message = "Not Found",
                    Data = response.Result
                });
        }

        /// <summary>
        /// Retrieves all Clients PJ
        /// </summary>
        [HttpGet("GetAllClientPJ")]
        public async Task<IActionResult> GetAllClientsPJAsync()
        {
            var response = _business.GetAllClientsPJAsync();

            if ((response.Result).Count > 0)
                return Ok(new
                {
                    Success = true,
                    Message = "Clients PJ retrieved successfully",
                    Data = response.Result
                });
            else
                return NotFound(new
                {
                    Success = false,
                    Message = "Not Foud",
                    Data = response.Result
                });
        }

        /// <summary>
        /// Retrieves a Client PJ by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the Client PJ</param>
        [HttpGet("getByIdForEditPJ/{id}")]
        public async Task<IActionResult> getByIdForEditPJ([FromRoute] int id)
        {
            var response = _business.GetByIdForEditPJAsync(id);         

            if (!string.IsNullOrEmpty((response.Result).razaoSocial))
                return Ok(new 
                {
                    Success = true,
                    Message = "Client PJ retrieved successfully",
                    Data = response.Result
                });
            else
                return NotFound(new
                {
                    Success = false,
                    Message = "Not Found",
                    Data = response.Result
                });
        }

        /// <summary>
        /// Retrieves a Client PF by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the Client PF</param>
        [HttpGet("getByIdForEditPF/{id}")]
        public async Task<IActionResult> getByIdForEditPF([FromRoute] int id)
        {
            var response = _business.GetByIdForEditPFAsync(id);

            if (!string.IsNullOrEmpty((response.Result).nome))
                return Ok(new
                {
                    Success = true,
                    Message = "Client PF retrieved successfully",
                    Data = response.Result
                });
            else
                return NotFound(new
                {
                    Success = false,
                    Message = "Not Found",
                    Data = response.Result
                });
        }

        /// <summary>
        /// Deletes a Client PJ by their ID
        /// </summary>
        /// <param name = "id" > The unique identifier of the Client PJ to delete</param>
        [HttpDelete("DeleteClientPJ/{id}")]
        public async Task<IActionResult> DeleteClientPJ([FromRoute] int id)
        {
            var response = _business.DeleteClientPJAsync(id);

            if (((Boolean)response.Result))
                return Ok(new
                {
                    Success = true,
                    Message = "Client PJ deleted successfully"
                });
            else
                return BadRequest(new
                {
                    Success = false,
                    Message = "Error"
                });
        }

        /// <summary>
        /// Deletes a Client PF by their ID
        /// </summary>
        /// <param name = "id" > The unique identifier of the Client PF to delete</param>
        [HttpDelete("DeleteClientPF/{id}")]
        public async Task<IActionResult> DeleteClientPF([FromRoute] int id)
        {
            var response = _business.DeleteClientPFAsync(id);

            if (((Boolean)response.Result))
                return Ok(new
                {
                    Success = true,
                    Message = "Client PF deleted successfully"
                });
            else
                return BadRequest(new
                {
                    Success = false,
                    Message = "Error"
                });
        }

    }
}
