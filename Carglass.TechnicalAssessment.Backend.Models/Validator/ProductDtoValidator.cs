using Carglass.TechnicalAssessment.Backend.Models.Dto;
using FluentValidation;

namespace Carglass.TechnicalAssessment.Backend.Models.Validator
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.ProductName).NotEmpty().MaximumLength(100);
        }
    }
}
