using AutoMapper;
using Carglass.TechnicalAssessment.Backend.DL.Repositories;
using Carglass.TechnicalAssessment.Backend.Models.Dto;
using Carglass.TechnicalAssessment.Backend.Models.Entities;
using FluentValidation;

namespace Carglass.TechnicalAssessment.Backend.BL.Products;

internal class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<ProductDto> _validator;

    public ProductService(
        IProductRepository productRepository,
        IMapper mapper,
        IValidator<ProductDto> validator)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public IEnumerable<ProductDto> GetAll()
    {
        var items = _productRepository.GetAll();
        return _mapper.Map<IEnumerable<ProductDto>>(items);
    }

    public ProductDto GetById(params object[] keyValues)
    {
        var item = _productRepository.GetById(keyValues);
        return _mapper.Map<ProductDto>(item);
    }

    public void Create(ProductDto item)
    {
        if (null != _productRepository.GetById(item.Id))
        {
            throw new Exception("Ya existe un producto con este Id");
        }

        ValidateDto(item);

        var entity = _mapper.Map<Product>(item);
        _productRepository.Create(entity);
    }

    public void Update(ProductDto item)
    {
        if (null == _productRepository.GetById(item.Id))
        {
            throw new Exception("No existe ningún producto con este Id");
        }

        ValidateDto(item);

        var entity = _mapper.Map<Product>(item);
        _productRepository.Update(entity);
    }

    public void Delete(ProductDto item)
    {
        var entity = _productRepository.GetById(item.Id);
        if (entity == null)
        {
            throw new Exception("No existe ningún producto con este Id");
        }

        _productRepository.Delete(entity);
    }

    private void ValidateDto(ProductDto item)
    {
        var validationResult = _validator.Validate(item);
        if (validationResult.Errors.Any())
        {
            string toShowErrors = string.Join("; ", validationResult.Errors.Select(s => s.ErrorMessage));
            throw new Exception($"El producto especificado no cumple los requisitos de validación. Errores: '{toShowErrors}'");
        }
    }
}
