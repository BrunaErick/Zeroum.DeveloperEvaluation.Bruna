using Moq;
using Xunit;
using Zeroum.DeveloperEvaluation.ABP.Bruna.Repository;
using Zeroum.DeveloperEvaluation.ABP.Bruna.Interface;
using Zeroum.DeveloperEvaluation.ABP.Bruna.Request;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using FluentAssertions;
using Shouldly;
using System;
using Zeroum.DeveloperEvaluation.ABP.Bruna.Response;

namespace Zeroum.DeveloperEvaluation.ABP.Bruna.Tests
{
    public class ClientesRepositoryTests
    {
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly ClientesRepository _clientesRepository;

        public ClientesRepositoryTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();

            // Mockando a connection string
            _mockConfiguration.Setup(config => config.GetConnectionString("DefaultConnection"))
                .Returns("Data Source=localhost;Initial Catalog=MinhaBase;Integrated Security=True");

            // Criando a instância do repositório com a configuração mockada
            _clientesRepository = new ClientesRepository(_mockConfiguration.Object);
        }

        [Fact]
        public async Task CreateOrEditClientPJAsync_ShouldReturnId_WhenClientIsCreated()
        {
            // Arrange: preparando a request
            var request = new ClientesPJCreateRequest
            {
                cnpj = "12345678000123",
                razaoSocial = "Empresa Teste",
                nomeFantasia = "Empresa Fantasia",
                email = "contato@empresa.com",
                dataAbertura = DateTime.Now
            };

            // Mockando o comportamento do método GetBycnpjForEditPJAsync, que normalmente buscaria no banco
            var mockCliente = new ClientesPJResponse
            {
                razaoSocial = null // Significa que a empresa ainda não foi cadastrada, então vai ser inserida
            };

            // Mock do método GetBycnpjForEditPJAsync
            var mockMethod = new Mock<Func<string, Task<ClientesPJResponse>>>();
            mockMethod.Setup(m => m.Invoke(It.IsAny<string>())).Returns(Task.FromResult(mockCliente));

            // Act: Chamando o método do repositório
            var result = await _clientesRepository.CreateOrEditClientPJAsync(request);

            // Assert: Verificar se o ID foi retornado (ID maior que 0)
            result.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task CreateOrEditClientPJAsync_ShouldUpdateClient_WhenClientExists()
        {
            // Arrange: preparando a request
            var request = new ClientesPJCreateRequest
            {
                cnpj = "12345678000123",
                razaoSocial = "Empresa Teste Atualizada",
                nomeFantasia = "Empresa Fantasia Atualizada",
                email = "contato@empresa-atualizada.com",
                dataAbertura = DateTime.Now
            };

            // Mockando um cliente já existente
            var mockClienteExistente = new ClientesPJResponse
            {
                razaoSocial = "Empresa Teste", // Já existe no banco
                Id = 1
            };

            // Mock do método GetBycnpjForEditPJAsync
            _mockConfiguration.Setup(m => m.GetConnectionString("DefaultConnection")).Returns("FakeConnectionString");

            // Mock do método GetBycnpjForEditPJAsync retornando um cliente existente
            var mockMethod = new Mock<Func<string, Task<ClientesPJResponse>>>();
            mockMethod.Setup(m => m.Invoke(It.IsAny<string>())).Returns(Task.FromResult(mockClienteExistente));

            // Act: Chamando o método do repositório
            var result = await _clientesRepository.CreateOrEditClientPJAsync(request);

            // Assert: Verificar se o ID retornado é o ID do cliente existente
            result.Should().Be(1);
        }
    }
}
