namespace Carglass.TechnicalAssessment.Services.IServices.Base;

public interface ICrudServices<TDto>
{
    IEnumerable<TDto> GetAll();
    TDto GetById(params object[] keyValues);

    void Create(TDto item);
    void Update(TDto item);
    void Delete(TDto item);
}
