using Zeroum.DTO.Bruna.Request;
using Zeroum.DTO.Bruna.Response;

namespace Zeroum.DAL.Bruna.Interfaces
{
    public interface IClientesRepository
    {
        Task<int> CreateOrEditClientPJAsync(ClientesPJCreateRequest request);
        Task<int> CreateOrEditClientPFAsync(ClientesPFCreateRequest request);
        Task<ClientesPFResponse> GetByIdForEditPFAsync(int id);
        Task<ClientesPJResponse> GetByIdForEditPJAsync(int id);
        Task<List<ClientesPFResponse>> GetAllClientsPFAsync();
        Task<List<ClientesPJResponse>> GetAllClientsPJAsync();
        Task<bool> DeleteClientPJAsync(int id);
        Task<bool> DeleteClientPFAsync(int id);
    }
}
