using Azure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Zeroum.DAL.Bruna.Interfaces;
using Dapper;
using Zeroum.DTO.Bruna.Request;
using Zeroum.DTO.Bruna.Response;

namespace Zeroum.DAL.Bruna.Repository
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly IConfiguration _appSettings;

        /// <summary>
        /// Initializes a new instance of ClientesRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public ClientesRepository(IConfiguration appSettings)
        {
            _appSettings = appSettings;
        }


        /// <summary>
        /// Creates a new Client PJ in the database
        /// </summary>
        /// <param name="request">The Client PJ to create</param>
        /// <returns>The created Client PJ</returns>
        public async Task<int> CreateOrEditClientPJAsync(ClientesPJCreateRequest request)
        {
            var connectionstring = _appSettings.GetConnectionString("DefaultConnection");
            var cliente = GetBycnpjForEditPJAsync(request.cnpj);
            var id = 0;
            var sqlQuery = "";

            if (string.IsNullOrEmpty(cliente.Result.razaoSocial))
            {
                sqlQuery = @" Insert into  [Zeroum].[dbo].[ClientesPj] 
                (
                [cnpj] 
                ,[razaoSocial] 
                ,[nomeFantasia] 
                ,[email] 
                ,[dataAbertura]
                ) 
                OUTPUT INSERTED.Id
                 values(
                    @cnpj
                    ,@razaoSocial
                    ,@nomeFantasia
                    ,@email
                    ,@dataAbertura)";

            }
            else 
            {
                sqlQuery = @" Update [Zeroum].[dbo].[ClientesPj] SET                
                 [razaoSocial] = @razaoSocial
                ,[nomeFantasia] = @nomeFantasia
                ,[email] = @email
                ,[dataAbertura] = @dataAbertura                                
                WHERE  [cnpj]  = @cnpj
                ";
            }

            try
            {
           

                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@cnpj", request.cnpj);
                        command.Parameters.AddWithValue("@razaoSocial", request.razaoSocial);
                        command.Parameters.AddWithValue("@nomeFantasia", request.nomeFantasia);
                        command.Parameters.AddWithValue("@email", request.email);
                        command.Parameters.AddWithValue("@dataAbertura", request.dataAbertura);

                        if (string.IsNullOrEmpty(cliente.Result.razaoSocial))
                            id = (int)command.ExecuteScalar();
                        else 
                        {
                            command.ExecuteScalar();
                            id = cliente.Result.Id;
                        }
                            
                    }
                }

                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        /// <summary>
        /// Creates a new Client PF in the database
        /// </summary>
        /// <param name="request">The Client PF to create</param>
        /// <returns>The created Client PF</returns>
        public async Task<int> CreateOrEditClientPFAsync(ClientesPFCreateRequest request)
        {
            var connectionstring = _appSettings.GetConnectionString("DefaultConnection");
            var cliente = GetBycpfForEditPFAsync(request.cpf);
            var id = 0;
            var sqlQuery = "";

            if (string.IsNullOrEmpty(cliente.Result.nome))
            {
                sqlQuery = @" Insert into  [Zeroum].[dbo].[ClientesPf] 
                (
                    [nome] 
                    ,[cpf] 
                    ,[rg] 
                    ,[email] 
                    ,[telefone]
                    ,[nascimento]
                ) 
                OUTPUT INSERTED.Id
                 values(
                    @nome
                    ,@cpf
                    ,@rg
                    ,@email
                    ,@telefone
                    ,@nascimento)";
            }
            else 
            {
                sqlQuery = @" Update  [Zeroum].[dbo].[ClientesPf] SET
                    [nome] = @nome
                    ,[rg] = @rg
                    ,[email] = @email
                    ,[telefone] = @telefone
                    ,[nascimento] = @nascimento
                    WHERE  cpf = @cpf
                    ";
            }
            try
            {               

                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@nome", request.nome);
                        command.Parameters.AddWithValue("@cpf", request.cpf);
                        command.Parameters.AddWithValue("@rg", request.rg);
                        command.Parameters.AddWithValue("@email", request.email);
                        command.Parameters.AddWithValue("@telefone", request.telefone);
                        command.Parameters.AddWithValue("@nascimento", request.nascimento);

                        if (string.IsNullOrEmpty(cliente.Result.nome))
                            id = (int)command.ExecuteScalar();
                        else 
                        {
                            command.ExecuteScalar();
                            id = cliente.Result.Id;
                        }
                    }
                }

                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// Retrieves all Clients PF
        /// </summary>
        public async Task<List<ClientesPFResponse>> GetAllClientsPFAsync()
        {
            var response = new List<ClientesPFResponse>();
            var connectionstring = _appSettings.GetConnectionString("DefaultConnection");

            try
            {
                var sqlQuery = @"SELECT
                           [Id]
                            ,[nome] 
                            ,[cpf] 
                            ,[rg] 
                            ,[email] 
                            ,[telefone]
                            ,[nascimento]
                         FROM [Zeroum].[dbo].[ClientesPF] ";

                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    // Usando Dapper para executar a consulta e mapear o resultado para uma lista de objetos Clientes PF
                    response = (await connection.QueryAsync<ClientesPFResponse>(sqlQuery)).ToList();
                }

                return response;
            }
            catch (Exception ex)
            {
                // Log de erro ou alguma outra lógica se necessário
            }

            return response;
        }


        /// <summary>
        /// Retrieves all Clients PJ
        /// </summary>
        public async Task<List<ClientesPJResponse>> GetAllClientsPJAsync()
        {
            var response = new List<ClientesPJResponse>();
            var connectionstring = _appSettings.GetConnectionString("DefaultConnection");

            try
            {
                var sqlQuery = @"SELECT
                           [Id]
                            ,[cnpj] 
                            ,[razaoSocial] 
                            ,[nomeFantasia] 
                            ,[email] 
                            ,[dataAbertura]
                         FROM [Zeroum].[dbo].[ClientesPJ] ";

                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    // Usando Dapper para executar a consulta e mapear o resultado para uma lista de objetos Clientes PJ
                    response = (await connection.QueryAsync<ClientesPJResponse>(sqlQuery)).ToList();
                }

                return response;
            }
            catch (Exception ex)
            {
                // Log de erro ou alguma outra lógica se necessário
            }

            return response;
        }


        /// <summary>
        /// Retrieves a Client PF
        /// </summary>
        /// <param name="id">The unique identifier of the Client PF</param>
        public async Task<ClientesPFResponse> GetByIdForEditPFAsync(int id)
        {
            var response = new ClientesPFResponse();
            var connectionstring = _appSettings.GetConnectionString("DefaultConnection");

            var sqlQuery = @"SELECT
                            [Id]
                            ,[nome] 
                            ,[cpf] 
                            ,[rg] 
                            ,[email] 
                            ,[telefone]
                            ,[nascimento]
                         FROM [Zeroum].[dbo].[ClientesPF] 
                         WHERE [Id] = @id";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                // Usando Dapper para executar a consulta e mapear o resultado para um objeto Cliente PF
                response = connection.QuerySingleOrDefault<ClientesPFResponse>(sqlQuery, new { id });
            }
            if (response == null)
                response = new ClientesPFResponse();

            return response;
        }


        /// <summary>
        /// Retrieves a Client PJ
        /// </summary>
        /// <param name="id">The unique identifier of the Client PJ</param>
        public async Task<ClientesPJResponse> GetByIdForEditPJAsync(int id)
        {
            var response = new ClientesPJResponse();
            var connectionstring = _appSettings.GetConnectionString("DefaultConnection");

            var sqlQuery = @"SELECT
                            [Id]
                            ,[cnpj] 
                            ,[razaoSocial] 
                            ,[nomeFantasia] 
                            ,[email] 
                            ,[dataAbertura]
                         FROM [Zeroum].[dbo].[ClientesPJ] 
                         WHERE[Id] = @id";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                // Usando Dapper para executar a consulta e mapear o resultado para um objeto Cliente PJ
                response = connection.QuerySingleOrDefault<ClientesPJResponse>(sqlQuery, new { id });
            }

            if (response == null)
                response = new ClientesPJResponse();

            return response;
        }


        /// <summary>
        /// Retrieves a Client PF
        /// </summary>
        /// <param name="cpf">The unique identifier of the Client PF</param>
        public async Task<ClientesPFResponse> GetBycpfForEditPFAsync(string cpf)
        {
            var response = new ClientesPFResponse();
            var connectionstring = _appSettings.GetConnectionString("DefaultConnection");

            var sqlQuery = @"SELECT
                            [Id]
                            ,[nome] 
                            ,[cpf] 
                            ,[rg] 
                            ,[email] 
                            ,[telefone]
                            ,[nascimento]
                         FROM [Zeroum].[dbo].[ClientesPF] 
                         WHERE [cpf] = @cpf";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                // Usando Dapper para executar a consulta e mapear o resultado para um objeto Cliente PF
                response = connection.QuerySingleOrDefault<ClientesPFResponse>(sqlQuery, new { cpf });
            }
            if (response == null)
                response = new ClientesPFResponse();

            return response;
        }


        /// <summary>
        /// Retrieves a Client PJ
        /// </summary>
        /// <param name="cnpj">The unique identifier of the Client PJ</param>
        public async Task<ClientesPJResponse> GetBycnpjForEditPJAsync(string cnpj)
        {
            var response = new ClientesPJResponse();
            var connectionstring = _appSettings.GetConnectionString("DefaultConnection");

            var sqlQuery = @"SELECT
                            [Id]
                            ,[cnpj] 
                            ,[razaoSocial] 
                            ,[nomeFantasia] 
                            ,[email] 
                            ,[dataAbertura]
                         FROM [Zeroum].[dbo].[ClientesPJ] 
                         WHERE[cnpj] = @cnpj";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                // Usando Dapper para executar a consulta e mapear o resultado para um objeto Cliente PJ
                response = connection.QuerySingleOrDefault<ClientesPJResponse>(sqlQuery, new { cnpj });
            }

            if (response == null)
                response = new ClientesPJResponse();

            return response;
        }


        /// <summary>
        /// Deletes a Client PF from the database
        /// </summary>
        /// <param name="id">The unique identifier of the  Client PF to delete</param>
        public async Task<bool> DeleteClientPFAsync(int id)
        {
            var connectionstring = _appSettings.GetConnectionString("DefaultConnection");

            var sqlQuery = @"
                DELETE FROM [Zeroum].[dbo].[ClientesPF]
                WHERE [iD] = @id";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                // Usando Dapper para executar a consulta de deleção
                int rowsAffected = connection.Execute(sqlQuery, new { id });

                // Verifica se a exclusão foi bem-sucedida (caso o número de linhas afetadas seja 1)
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Deletes a Client PJ from the database
        /// </summary>
        /// <param name="id">The unique identifier of the  Client PJ to delete</param>
        public async Task<bool> DeleteClientPJAsync(int id)
        {
            var connectionstring = _appSettings.GetConnectionString("DefaultConnection");

            var sqlQuery = @"
                DELETE FROM [Zeroum].[dbo].[ClientesPJ]
                WHERE [iD] = @id";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                // Usando Dapper para executar a consulta de deleção
                int rowsAffected = connection.Execute(sqlQuery, new { id });

                // Verifica se a exclusão foi bem-sucedida (caso o número de linhas afetadas seja 1)
                return rowsAffected > 0;
            }
        }
    }
}
