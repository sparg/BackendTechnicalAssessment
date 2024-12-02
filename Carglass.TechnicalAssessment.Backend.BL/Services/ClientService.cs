using AutoMapper;
using Carglass.TechnicalAssessment.Data.IRepositories;
using Carglass.TechnicalAssessment.Models.Dto;
using Carglass.TechnicalAssessment.Models.Entities;
using Carglass.TechnicalAssessment.Services.IServices;
using FluentValidation;

namespace Carglass.TechnicalAssessment.Services.Services;

internal class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<ClientDto> _validator;

    public ClientService(
        IClientRepository clientRepository,
        IMapper mapper,
        IValidator<ClientDto> validator)
    {
        _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public IEnumerable<ClientDto> GetAll()
    {
        var items = _clientRepository.GetAll();
        return _mapper.Map<IEnumerable<ClientDto>>(items);
    }

    public ClientDto GetById(params object[] keyValues)
    {
        var item = _clientRepository.GetById(keyValues);
        return _mapper.Map<ClientDto>(item);
    }

    public void Create(ClientDto item)
    {
        if (null != _clientRepository.GetById(item.Id))
        {
            throw new Exception("Ya existe un cliente con este Id");
        }

        ValidateDto(item);

        var entity = _mapper.Map<Client>(item);
        _clientRepository.Create(entity);
    }

    public void Update(ClientDto item)
    {
        if (null == _clientRepository.GetById(item.Id))
        {
            throw new Exception("No existe ningún cliente con este Id");
        }

        ValidateDto(item);

        var entity = _mapper.Map<Client>(item);
        _clientRepository.Update(entity);
    }

    public void Delete(ClientDto item)
    {
        var entity = _clientRepository.GetById(item.Id);
        if (entity == null)
        {
            throw new Exception("No existe ningún cliente con este Id");
        }

        _clientRepository.Delete(entity);
    }

    private void ValidateDto(ClientDto item)
    {
        var validationResult = _validator.Validate(item);
        if (validationResult.Errors.Any())
        {
            string toShowErrors = string.Join("; ", validationResult.Errors.Select(s => s.ErrorMessage));
            throw new Exception($"El cliente especificado no cumple los requisitos de validación. Errores: '{toShowErrors}'");
        }
    }
}
