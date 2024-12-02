using Carglass.TechnicalAssessment.Data.IRepositories;
using Carglass.TechnicalAssessment.Models.Entities;

namespace Carglass.TechnicalAssessment.Data.Repositories;

public class ClientRepository : IClientRepository
{
    private ICollection<Client> _clientsRepository;

    public ClientRepository()
    {
        _clientsRepository = new HashSet<Client>()
        {
            new Client()
            {
                Id = 1,
                DocType = "nif",
                DocNum = "11223344E",
                Email = "eromani@sample.com",
                GivenName = "Enriqueta",
                FamilyName1 = "Romani",
                Phone = "668668668"
            }
        };
    }

    public IEnumerable<Client> GetAll()
    {
        return _clientsRepository;
    }

    public Client? GetById(int id)
    {
        return _clientsRepository.SingleOrDefault(x => x.Id == id);
    }

    public Client? GetById(params object[] keyValues)
    {
        return _clientsRepository.SingleOrDefault(x => x.Id.Equals(keyValues[0]));
    }

    public void Create(Client item)
    {
        if (_clientsRepository.Any(x => x.Id == item.Id))
        {
            throw new ArgumentException("A client with the same Id already exists.");
        }
        _clientsRepository.Add(item);
    }

    public void Update(Client item)
    {
        var existingClient = _clientsRepository.SingleOrDefault(x => x.Id == item.Id);
        if (existingClient == null)
        {
            throw new ArgumentException("Client not found.");
        }

        existingClient.DocType = item.DocType;
        existingClient.DocNum = item.DocNum;
        existingClient.Email = item.Email;
        existingClient.GivenName = item.GivenName;
        existingClient.FamilyName1 = item.FamilyName1;
        existingClient.Phone = item.Phone;
    }

    public void Delete(Client item)
    {
        var toDeleteItem = _clientsRepository.Single(x => x.Id.Equals(item.Id));

        _clientsRepository.Remove(toDeleteItem);
    }
}
