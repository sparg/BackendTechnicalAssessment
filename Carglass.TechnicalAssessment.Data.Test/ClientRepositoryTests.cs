using Carglass.TechnicalAssessment.Data.Repositories;
using Carglass.TechnicalAssessment.Models.Entities;
using FluentAssertions;

namespace Carglass.TechnicalAssessment.Data.Test
{
    public class ClientRepositoryTests
    {
        private readonly ClientRepository _clientRepository;

        public ClientRepositoryTests()
        {
            _clientRepository = new ClientRepository();
        }

        [Fact]
        public void GetAll_ShouldReturnAllClients()
        {
            // Act
            var clients = _clientRepository.GetAll();

            // Assert
            clients.Should().NotBeNull();
            clients.Should().HaveCount(1);
        }

        [Fact]
        public void GetById_ShouldReturnClient_WhenClientExists()
        {
            // Act
            var client = _clientRepository.GetById(1);

            // Assert
            client.Should().NotBeNull();
            client!.Id.Should().Be(1);
        }

        [Fact]
        public void GetById_ShouldReturnNull_WhenClientDoesNotExist()
        {
            // Act
            var client = _clientRepository.GetById(99);

            // Assert
            client.Should().BeNull();
        }

        [Fact]
        public void Create_ShouldAddClient()
        {
            // Arrange
            var newClient = new Client
            {
                Id = 2,
                DocType = "nif",
                DocNum = "22334455F",
                Email = "jdoe@sample.com",
                GivenName = "John",
                FamilyName1 = "Doe",
                Phone = "777777777"
            };

            // Act
            _clientRepository.Create(newClient);
            var client = _clientRepository.GetById(2);

            // Assert
            client.Should().NotBeNull();
            client!.Id.Should().Be(2);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenClientWithSameIdExists()
        {
            // Arrange
            var newClient = new Client
            {
                Id = 1,
                DocType = "nif",
                DocNum = "22334455F",
                Email = "jdoe@sample.com",
                GivenName = "John",
                FamilyName1 = "Doe",
                Phone = "777777777"
            };

            // Act
            Action act = () => _clientRepository.Create(newClient);

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("A client with the same Id already exists.");
        }

        [Fact]
        public void Update_ShouldModifyClient()
        {
            // Arrange
            var updatedClient = new Client
            {
                Id = 1,
                DocType = "nif",
                DocNum = "11223344E",
                Email = "updated@sample.com",
                GivenName = "Updated",
                FamilyName1 = "Name",
                Phone = "999999999"
            };

            // Act
            _clientRepository.Update(updatedClient);
            var client = _clientRepository.GetById(1);

            // Assert
            client.Should().NotBeNull();
            client!.Email.Should().Be("updated@sample.com");
            client.GivenName.Should().Be("Updated");
        }

        [Fact]
        public void Update_ShouldThrowException_WhenClientDoesNotExist()
        {
            // Arrange
            var updatedClient = new Client
            {
                Id = 99,
                DocType = "nif",
                DocNum = "22334455F",
                Email = "jdoe@sample.com",
                GivenName = "John",
                FamilyName1 = "Doe",
                Phone = "777777777"
            };

            // Act
            Action act = () => _clientRepository.Update(updatedClient);

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("Client not found.");
        }

        [Fact]
        public void Delete_ShouldRemoveClient()
        {
            // Arrange
            var clientToDelete = new Client
            {
                Id = 1,
                DocType = "nif",
                DocNum = "11223344E",
                Email = "eromani@sample.com",
                GivenName = "Enriqueta",
                FamilyName1 = "Romani",
                Phone = "668668668"
            };

            // Act
            _clientRepository.Delete(clientToDelete);
            var client = _clientRepository.GetById(1);

            // Assert
            client.Should().BeNull();
        }

        [Fact]
        public void Delete_ShouldThrowException_WhenClientDoesNotExist()
        {
            // Arrange
            var clientToDelete = new Client
            {
                Id = 99,
                DocType = "nif",
                DocNum = "22334455F",
                Email = "jdoe@sample.com",
                GivenName = "John",
                FamilyName1 = "Doe",
                Phone = "777777777"
            };

            // Act
            Action act = () => _clientRepository.Delete(clientToDelete);

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}
