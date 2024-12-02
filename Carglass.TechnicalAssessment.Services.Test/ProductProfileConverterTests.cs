using AutoMapper;
using Carglass.TechnicalAssessment.Models.Dto;
using Carglass.TechnicalAssessment.Models.Entities;
using Carglass.TechnicalAssessment.Services.Converter;
using FluentAssertions;

namespace Carglass.TechnicalAssessment.Services.Test
{
    public class ProductProfileConverterTests
    {
        private readonly IMapper _mapper;

        public ProductProfileConverterTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ProductProfileConverter>());
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void Should_Map_Product_To_ProductDto()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                ProductName = "Cristal ventanilla delantera",
                ProductType = 25,
                NumTerminal = 933933933,
                SoldAt = DateTime.Parse("2019-01-09 14:26:17")
            };

            // Act
            var productDto = _mapper.Map<ProductDto>(product);

            // Assert
            productDto.Should().NotBeNull();
            productDto.Id.Should().Be(product.Id);
            productDto.ProductName.Should().Be(product.ProductName);
            productDto.ProductType.Should().Be(product.ProductType);
            productDto.NumTerminal.Should().Be(product.NumTerminal);
            productDto.SoldAt.Should().Be(product.SoldAt);
        }

        [Fact]
        public void Should_Map_ProductDto_To_Product()
        {
            // Arrange
            var productDto = new ProductDto
            {
                Id = 1,
                ProductName = "Cristal ventanilla delantera",
                ProductType = 25,
                NumTerminal = 933933933,
                SoldAt = DateTime.Parse("2019-01-09 14:26:17")
            };

            // Act
            var product = _mapper.Map<Product>(productDto);

            // Assert
            product.Should().NotBeNull();
            product.Id.Should().Be(productDto.Id);
            product.ProductName.Should().Be(productDto.ProductName);
            product.ProductType.Should().Be(productDto.ProductType);
            product.NumTerminal.Should().Be(productDto.NumTerminal);
            product.SoldAt.Should().Be(productDto.SoldAt);
        }
    }
}
