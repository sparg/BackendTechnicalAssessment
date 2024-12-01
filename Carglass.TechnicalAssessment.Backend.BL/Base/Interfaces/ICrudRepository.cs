namespace Carglass.TechnicalAssessment.Backend.BL.Base.Interfaces;

public interface ICrudAppService<TDto>
{
    IEnumerable<TDto> GetAll();
    TDto GetById(params object[] keyValues);

    void Create(TDto item);
    void Update(TDto item);
    void Delete(TDto item);
}
