using Carglass.TechnicalAssessment.Backend.Models.Entities;

namespace Carglass.TechnicalAssessment.Backend.DL.Repositories
{
    public interface IProductRepository
    {
        void Create(Product item);
        void Delete(Product item);
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        Product? GetById(params object[] keyValues);
        void Update(Product item);
    }
}
