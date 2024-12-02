using AutoMapper;
using Carglass.TechnicalAssessment.Models.Dto;
using Carglass.TechnicalAssessment.Models.Entities;

namespace Carglass.TechnicalAssessment.Services.Converter;

public class ClientProfileConverter : Profile
{
    public ClientProfileConverter()
    {
        // Entity to Dto
        CreateMap<Client, ClientDto>();

        // Dto to Entity
        CreateMap<ClientDto, Client>();
    }
}
