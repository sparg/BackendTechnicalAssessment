namespace Carglass.TechnicalAssessment.Backend.DL.Repositories.Base;

public interface ICrudRepository<TEntity>
{
    IEnumerable<TEntity> GetAll();
    TEntity? GetById(params object[] keyValues);
    TEntity? GetById(int id);

    void Create(TEntity item);
    void Update(TEntity item);
    void Delete(TEntity item);
}
