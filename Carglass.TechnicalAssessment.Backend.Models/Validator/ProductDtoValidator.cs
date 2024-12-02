using Carglass.TechnicalAssessment.Models.Dto;
using FluentValidation;

namespace Carglass.TechnicalAssessment.Models.Validator
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
