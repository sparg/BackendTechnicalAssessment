﻿using Carglass.TechnicalAssessment.Models.Entities;

namespace Carglass.TechnicalAssessment.Data.IRepositories
{
    public interface IClientRepository
    {
        void Create(Client item);
        void Delete(Client item);
        IEnumerable<Client> GetAll();
        Client? GetById(int id);
        Client? GetById(params object[] keyValues);
        void Update(Client item);
    }
}