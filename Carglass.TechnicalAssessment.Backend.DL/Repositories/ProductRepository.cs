using Carglass.TechnicalAssessment.Data.IRepositories;
using Carglass.TechnicalAssessment.Models.Entities;

namespace Carglass.TechnicalAssessment.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private ICollection<Product> _productsRepository;

    public ProductRepository()
    {
        _productsRepository = new HashSet<Product>()
        {
            new Product()
            {
                Id = 1111111,
                ProductName = "Cristal ventanilla delantera",
                ProductType = 25,
                NumTerminal = 933933933,
                SoldAt = DateTime.Parse("2019-01-09 14:26:17")
            }
        };
    }

    public IEnumerable<Product> GetAll()
    {
        return _productsRepository;
    }

    public Product? GetById(int id)
    {
        return _productsRepository.SingleOrDefault(x => x.Id == id);
    }

    public Product? GetById(params object[] keyValues)
    {
        return _productsRepository.SingleOrDefault(x => x.Id.Equals(keyValues[0]));
    }

    public void Create(Product item)
    {
        if (_productsRepository.Any(x => x.Id == item.Id))
        {
            throw new ArgumentException("A product with the same Id already exists.");
        }
        _productsRepository.Add(item);
    }

    public void Update(Product item)
    {
        var existingProduct = _productsRepository.SingleOrDefault(x => x.Id == item.Id);
        if (existingProduct == null)
        {
            throw new ArgumentException("Product not found.");
        }

        existingProduct.ProductName = item.ProductName;
        existingProduct.ProductType = item.ProductType;
        existingProduct.NumTerminal = item.NumTerminal;
        existingProduct.SoldAt = item.SoldAt;
    }

    public void Delete(Product item)
    {
        var toDeleteItem = _productsRepository.Single(x => x.Id.Equals(item.Id));

        _productsRepository.Remove(toDeleteItem);
    }
}
