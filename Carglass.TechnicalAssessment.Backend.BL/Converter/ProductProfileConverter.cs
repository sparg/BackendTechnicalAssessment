using AutoMapper;
using Carglass.TechnicalAssessment.Models.Dto;
using Carglass.TechnicalAssessment.Models.Entities;

namespace Carglass.TechnicalAssessment.Services.Converter;

public class ProductProfileConverter : Profile
{
    public ProductProfileConverter()
    {
        // Entity to Dto
        CreateMap<Product, ProductDto>();

        // Dto to Entity
        CreateMap<ProductDto, Product>();
    }
}
