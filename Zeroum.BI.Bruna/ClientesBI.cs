using Zeroum.BI.Bruna.Interfaces;
using Zeroum.DAL.Bruna.Interfaces;
using Zeroum.DTO.Bruna.Request;
using Zeroum.DTO.Bruna.Response;

namespace Zeroum.BI.Bruna
{
    public class ClientesBI: IClientesBI
    {
        private readonly IClientesRepository _repo;

        /// <summary>
        /// Initializes a new instance of ClienteBusiness
        /// </summary>
        /// <param name="context">The database context</param>
        public ClientesBI(IClientesRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Creates a new client PJ
        /// </summary>
        /// <param name="request">The client PJ creation or edit request</param>
        /// <returns>The created client PJ details</returns>
        public async Task<int> CreateOrEditClientPJAsync(ClientesPJCreateRequest request)
        {
            return await _repo.CreateOrEditClientPJAsync(request);
        }

        /// <summary>
        /// Creates a new client PF
        /// </summary>
        /// <param name="request">The client PF creation or edit request</param>
        /// <returns>The created client PF details</returns>
        public async Task<int> CreateOrEditClientPFAsync(ClientesPFCreateRequest request)
        {
            return await _repo.CreateOrEditClientPFAsync(request);
        }

        /// <summary>
        /// Retrieves a Client PF
        /// </summary>
        /// <param name="id">The unique identifier of the Client PF</param>
        public async Task<ClientesPFResponse> GetByIdForEditPFAsync(int id)
        {
            return await _repo.GetByIdForEditPFAsync(id);
        }

        /// <summary>
        /// Retrieves a Client PJ
        /// </summary>
        public async Task<List<ClientesPJResponse>> GetAllClientsPJAsync()
        {
            return await _repo.GetAllClientsPJAsync();
        }

        /// <summary>
        /// Retrieves a Client PF
        /// </summary>
        /// <param name="id">The unique identifier of the Client PF</param>
        public async Task<List<ClientesPFResponse>> GetAllClientsPFAsync() 
        {
            return await _repo.GetAllClientsPFAsync();
        }

        /// <summary>
        /// Retrieves a Client PJ
        /// </summary>
        /// <param name="id">The unique identifier of the Client PJ</param>
        public async Task<ClientesPJResponse> GetByIdForEditPJAsync(int id)
        {
            return await _repo.GetByIdForEditPJAsync(id);
        }

        /// <summary>
        /// Deletes a Client PF from the database
        /// </summary>
        /// <param name="id">The unique identifier of the  Client PF to delete</param>
        public async Task<bool> DeleteClientPFAsync(int id)
        {
            return await _repo.DeleteClientPFAsync(id);
        }

        /// <summary>
        /// Deletes a Client PJ from the database
        /// </summary>
        /// <param name="id">The unique identifier of the  Client PJ to delete</param>
        public async Task<bool> DeleteClientPJAsync(int id)
        {
            return await _repo.DeleteClientPJAsync(id);
        }
    }
}
