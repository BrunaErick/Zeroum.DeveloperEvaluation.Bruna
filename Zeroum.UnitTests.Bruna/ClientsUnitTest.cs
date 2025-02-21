using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using Zeroum.BI.Bruna.Interfaces;
using Zeroum.WebApi.Bruna.Controllers;
using Zeroum.DTO.Bruna.Request;
using System.Threading.Tasks;
using Zeroum.DTO.Bruna.Response;

namespace Zeroum.UnitTests.Bruna
{
    public class ClientesControllerTests
    {
        private Mock<IClientesBI> _mockClientesBI;
        private ClientesController _controller;

        [SetUp]
        public void Setup()
        {
            _mockClientesBI = new Mock<IClientesBI>();
            _controller = new ClientesController(null, _mockClientesBI.Object);  // Passing null for ILogger
        }

        [Test]
        public async Task CreateOrEditClientPJ_ReturnsCreatedResult_WhenSuccess()
        {
            // Arrange
            var request = new ClientesPJCreateRequest(); // Fill with mock data
            _mockClientesBI.Setup(b => b.CreateOrEditClientPJAsync(It.IsAny<ClientesPJCreateRequest>())).ReturnsAsync(1); // Mock success

            // Act
            var result = await _controller.CreateOrEditClientPJ(request);

            // Assert
            var createdResult = result as CreatedResult;
            Assert.IsNotNull(createdResult);
            Assert.AreEqual(201, createdResult.StatusCode); // Created HTTP status
        }

        [Test]
        public async Task CreateOrEditClientPJ_ReturnsBadRequest_WhenFail()
        {
            // Arrange
            var request = new ClientesPJCreateRequest(); // Fill with mock data
            _mockClientesBI.Setup(b => b.CreateOrEditClientPJAsync(It.IsAny<ClientesPJCreateRequest>())).ReturnsAsync(0); // Mock failure

            // Act
            var result = await _controller.CreateOrEditClientPJ(request);

            // Assert
            var badRequestResult = result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual(400, badRequestResult.StatusCode); // BadRequest HTTP status
        }
        #region Test GetAllClientsPFAsync

        [Test]
        public async Task GetAllClientsPF_ReturnsOkResult_WhenClientsFound()
        {
            // Arrange
            var mockClientsPF = new List<ClientesPFResponse> { new ClientesPFResponse { Id = 1, nome = "Cliente 1" }, new ClientesPFResponse { Id = 2, nome = "Cliente 2" } };
            _mockClientesBI.Setup(b => b.GetAllClientsPFAsync()).ReturnsAsync(mockClientsPF); // Mock list with clients

            // Act
            var result = await _controller.GetAllClientsPFAsync();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode); // Verifica se o status é OK (200)
        }

        [Test]
        public async Task GetAllClientsPF_ReturnsNotFound_WhenNoClients()
        {
            // Arrange
            _mockClientesBI.Setup(b => b.GetAllClientsPFAsync()).ReturnsAsync(new List<ClientesPFResponse>()); // Mock empty list

            // Act
            var result = await _controller.GetAllClientsPFAsync();

            // Assert
            var notFoundResult = result as NotFoundObjectResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode); // Verifica se o status é NotFound (404)
        }

        #endregion

        #region Test GetAllClientsPJAsync

        [Test]
        public async Task GetAllClientsPJ_ReturnsOkResult_WhenClientsFound()
        {
            // Arrange
            var mockClientsPJ = new List<ClientesPJResponse> { new ClientesPJResponse { Id = 1, razaoSocial = "Empresa 1" }, new ClientesPJResponse { Id = 2, razaoSocial = "Empresa 2" } };
            _mockClientesBI.Setup(b => b.GetAllClientsPJAsync()).ReturnsAsync(mockClientsPJ); // Mock list with clients

            // Act
            var result = await _controller.GetAllClientsPJAsync();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode); // Verifica se o status é OK (200)
        }

        [Test]
        public async Task GetAllClientsPJ_ReturnsNotFound_WhenNoClients()
        {
            // Arrange
            _mockClientesBI.Setup(b => b.GetAllClientsPJAsync()).ReturnsAsync(new List<ClientesPJResponse>()); // Mock empty list

            // Act
            var result = await _controller.GetAllClientsPJAsync();

            // Assert
            var notFoundResult = result as NotFoundObjectResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode); // Verifica se o status é NotFound (404)
        }

        #endregion


        [Test]
        public async Task DeleteClientPJ_ReturnsOkResult_WhenSuccess()
        {
            // Arrange
            _mockClientesBI.Setup(b => b.DeleteClientPJAsync(It.IsAny<int>())).ReturnsAsync(true); // Mock success

            // Act
            var result = await _controller.DeleteClientPJ(1);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode); // OK HTTP status
        }

        [Test]
        public async Task DeleteClientPJ_ReturnsBadRequest_WhenFail()
        {
            // Arrange
            _mockClientesBI.Setup(b => b.DeleteClientPJAsync(It.IsAny<int>())).ReturnsAsync(false); // Mock failure

            // Act
            var result = await _controller.DeleteClientPJ(1);

            // Assert
            var badRequestResult = result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual(400, badRequestResult.StatusCode); // BadRequest HTTP status
        }
    }
}
