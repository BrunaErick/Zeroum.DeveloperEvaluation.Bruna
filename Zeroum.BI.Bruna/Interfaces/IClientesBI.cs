using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeroum.DTO.Bruna.Request;
using Zeroum.DTO.Bruna.Response;

namespace Zeroum.BI.Bruna.Interfaces
{
    public interface IClientesBI
    {
       Task<int> CreateOrEditClientPJAsync(ClientesPJCreateRequest request);
        Task<int> CreateOrEditClientPFAsync(ClientesPFCreateRequest request);
        Task<List<ClientesPJResponse>> GetAllClientsPJAsync();
        Task<List<ClientesPFResponse>> GetAllClientsPFAsync();
        Task<ClientesPFResponse> GetByIdForEditPFAsync(int id);
        Task<ClientesPJResponse> GetByIdForEditPJAsync(int id);
        Task<bool> DeleteClientPFAsync(int id);
        Task<bool> DeleteClientPJAsync(int id);
    }
}
