using Carglass.TechnicalAssessment.Data.Repositories;
using Carglass.TechnicalAssessment.Models.Entities;
using FluentAssertions;

namespace Carglass.TechnicalAssessment.Data.Test
{
    public class ProductRepositoryTests
    {
        private readonly ProductRepository _productRepository;

        public ProductRepositoryTests()
        {
            _productRepository = new ProductRepository();
        }

        [Fact]
        public void GetAll_ShouldReturnAllProducts()
        {
            // Act
            var products = _productRepository.GetAll();

            // Assert
            products.Should().NotBeNull();
            products.Should().HaveCount(1);
        }

        [Fact]
        public void GetById_ShouldReturnProduct_WhenProductExists()
        {
            // Act
            var product = _productRepository.GetById(1111111);

            // Assert
            product.Should().NotBeNull();
            product.Id.Should().Be(1111111);
        }

        [Fact]
        public void GetById_ShouldReturnNull_WhenProductDoesNotExist()
        {
            // Act
            var product = _productRepository.GetById(9999999);

            // Assert
            product.Should().BeNull();
        }

        [Fact]
        public void Create_ShouldAddProduct()
        {
            // Arrange
            var newProduct = new Product
            {
                Id = 2222222,
                ProductName = "Cristal ventanilla trasera",
                ProductType = 26,
                NumTerminal = 944944944,
                SoldAt = DateTime.Parse("2020-02-10 15:30:20")
            };

            // Act
            _productRepository.Create(newProduct);
            var product = _productRepository.GetById(2222222);

            // Assert
            product.Should().NotBeNull();
            product.Id.Should().Be(2222222);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenProductWithSameIdExists()
        {
            // Arrange
            var newProduct = new Product
            {
                Id = 1111111,
                ProductName = "Cristal ventanilla trasera",
                ProductType = 26,
                NumTerminal = 944944944,
                SoldAt = DateTime.Parse("2020-02-10 15:30:20")
            };

            // Act
            Action act = () => _productRepository.Create(newProduct);

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("A product with the same Id already exists.");
        }

        [Fact]
        public void Update_ShouldModifyProduct()
        {
            // Arrange
            var updatedProduct = new Product
            {
                Id = 1111111,
                ProductName = "Cristal ventanilla delantera actualizado",
                ProductType = 25,
                NumTerminal = 933933933,
                SoldAt = DateTime.Parse("2019-01-09 14:26:17")
            };

            // Act
            _productRepository.Update(updatedProduct);
            var product = _productRepository.GetById(1111111);

            // Assert
            product.Should().NotBeNull();
            product.ProductName.Should().Be("Cristal ventanilla delantera actualizado");
        }

        [Fact]
        public void Update_ShouldThrowException_WhenProductDoesNotExist()
        {
            // Arrange
            var updatedProduct = new Product
            {
                Id = 9999999,
                ProductName = "Cristal ventanilla trasera",
                ProductType = 26,
                NumTerminal = 944944944,
                SoldAt = DateTime.Parse("2020-02-10 15:30:20")
            };

            // Act
            Action act = () => _productRepository.Update(updatedProduct);

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("Product not found.");
        }

        [Fact]
        public void Delete_ShouldRemoveProduct()
        {
            // Arrange
            var productToDelete = new Product
            {
                Id = 1111111,
                ProductName = "Cristal ventanilla delantera",
                ProductType = 25,
                NumTerminal = 933933933,
                SoldAt = DateTime.Parse("2019-01-09 14:26:17")
            };

            // Act
            _productRepository.Delete(productToDelete);
            var product = _productRepository.GetById(1111111);

            // Assert
            product.Should().BeNull();
        }

        [Fact]
        public void Delete_ShouldThrowException_WhenProductDoesNotExist()
        {
            // Arrange
            var productToDelete = new Product
            {
                Id = 9999999,
                ProductName = "Cristal ventanilla trasera",
                ProductType = 26,
                NumTerminal = 944944944,
                SoldAt = DateTime.Parse("2020-02-10 15:30:20")
            };

            // Act
            Action act = () => _productRepository.Delete(productToDelete);

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}
