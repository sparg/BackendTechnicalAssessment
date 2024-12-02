using AutoMapper;
using Carglass.TechnicalAssessment.Backend.Models.Dto;
using Carglass.TechnicalAssessment.Backend.Models.Entities;

namespace Carglass.TechnicalAssessment.Backend.BL.Converter;

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
