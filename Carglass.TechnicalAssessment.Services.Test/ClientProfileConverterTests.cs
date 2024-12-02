using AutoMapper;
using Carglass.TechnicalAssessment.Models.Dto;
using Carglass.TechnicalAssessment.Models.Entities;
using Carglass.TechnicalAssessment.Services.Converter;
using FluentAssertions;

namespace Carglass.TechnicalAssessment.Services.Test
{
    public class ClientProfileConverterTests
    {
        private readonly IMapper _mapper;

        public ClientProfileConverterTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ClientProfileConverter>());
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void Should_Map_Client_To_ClientDto()
        {
            // Arrange
            var client = new Client
            {
                Id = 1,
                DocType = "nif",
                DocNum = "12345678A",
                Email = "test@example.com",
                GivenName = "John",
                FamilyName1 = "Doe",
                Phone = "123456789"
            };

            // Act
            var clientDto = _mapper.Map<ClientDto>(client);

            // Assert
            clientDto.Should().NotBeNull();
            clientDto.Id.Should().Be(client.Id);
            clientDto.DocType.Should().Be(client.DocType);
            clientDto.DocNum.Should().Be(client.DocNum);
            clientDto.Email.Should().Be(client.Email);
            clientDto.GivenName.Should().Be(client.GivenName);
            clientDto.FamilyName1.Should().Be(client.FamilyName1);
            clientDto.Phone.Should().Be(client.Phone);
        }

        [Fact]
        public void Should_Map_ClientDto_To_Client()
        {
            // Arrange
            var clientDto = new ClientDto
            {
                Id = 1,
                DocType = "nif",
                DocNum = "12345678A",
                Email = "test@example.com",
                GivenName = "John",
                FamilyName1 = "Doe",
                Phone = "123456789"
            };

            // Act
            var client = _mapper.Map<Client>(clientDto);

            // Assert
            client.Should().NotBeNull();
            client.Id.Should().Be(clientDto.Id);
            client.DocType.Should().Be(clientDto.DocType);
            client.DocNum.Should().Be(clientDto.DocNum);
            client.Email.Should().Be(clientDto.Email);
            client.GivenName.Should().Be(clientDto.GivenName);
            client.FamilyName1.Should().Be(clientDto.FamilyName1);
            client.Phone.Should().Be(clientDto.Phone);
        }
    }
}
