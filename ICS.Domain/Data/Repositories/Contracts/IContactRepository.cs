using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICS.Domain.Entities;
using ICS.Domain.Models;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IContactRepository
    {
        Contact Create(
            string email,
            string postcode,
            string homePhoneNumber,
            string workPhoneNumber,
            string mobilePhoneNumber);

        Task DeleteAsync(Guid id);

        Task<IEnumerable<Contact>> GetAllAsync();

        Task<Contact> GetAsync(Guid id);

        Task UpdateAsync(Guid currentContcatId, ContactDto newContact);
    }
}