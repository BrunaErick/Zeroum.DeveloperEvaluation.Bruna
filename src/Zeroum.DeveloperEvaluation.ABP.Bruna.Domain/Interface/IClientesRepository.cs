using System.Collections.Generic;
using System.Threading.Tasks;
using Zeroum.DeveloperEvaluation.ABP.Bruna.Request;
using Zeroum.DeveloperEvaluation.ABP.Bruna.Response;

namespace Zeroum.DeveloperEvaluation.ABP.Bruna.Interface
{
    public interface IClientesRepository
    {

        Task<int> CreateOrEditClientPJAsync(ClientesPJCreateRequest request);
        Task<int> CreateOrEditClientPFAsync(ClientesPFCreateRequest request);
        Task<ClientesPFResponse> GetByIdForEditPFAsync(int id);
        Task<ClientesPJResponse> GetByIdForEditPJAsync(int id);
        Task<List<ClientesPFResponse>> GetAllClientsPFAsync();
        Task<List<ClientesPJResponse>> GetAllClientsPJAsync();
        Task<ClientesPJResponse> GetBycnpjForEditPJAsync(string cnpj);
        Task<ClientesPFResponse> GetBycpfForEditPFAsync(string cpf);
        Task<bool> DeleteClientPJAsync(int id);
        Task<bool> DeleteClientPFAsync(int id);
    }
}
