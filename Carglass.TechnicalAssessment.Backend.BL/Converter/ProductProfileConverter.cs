using AutoMapper;
using Carglass.TechnicalAssessment.Backend.Models.Dto;
using Carglass.TechnicalAssessment.Backend.Models.Entities;

namespace Carglass.TechnicalAssessment.Backend.BL.Converter;

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
