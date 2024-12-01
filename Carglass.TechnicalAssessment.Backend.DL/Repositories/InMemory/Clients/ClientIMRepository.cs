﻿using Carglass.TechnicalAssessment.Backend.Entities;

namespace Carglass.TechnicalAssessment.Backend.DL.Repositories;

public class ClientIMRepository : ICrudRepository<Client>
{
    private ICollection<Client> _clients;

    public ClientIMRepository()
    {
        _clients = new HashSet<Client>()
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
        // TODO Implement
        throw new NotImplementedException();
    }

    public Client? GetById(params object[] keyValues)
    {
        return _clients.SingleOrDefault(x => x.Id.Equals(keyValues[0]));
    }

    public void Create(Client item)
    {
        // TODO Implement
        throw new NotImplementedException();
    }

    public void Update(Client item)
    {
        // TODO Implement
        throw new NotImplementedException();
    }

    public void Delete(Client item)
    {
        var toDeleteItem = _clients.Single(x => x.Id.Equals(item.Id));

        _clients.Remove(toDeleteItem);
    }
}
