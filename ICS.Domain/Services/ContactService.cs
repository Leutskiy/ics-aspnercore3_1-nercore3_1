using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Entities;
using ICS.Domain.Models;
using ICS.Domain.Services.Contracts;
using ICS.Shared;

namespace ICS.Domain.Services
{
    /// <summary>
    /// Сервис для работы с контактными данными
    /// </summary>
    public sealed class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(
            IContactRepository contactRepository)
        {
            Contract.Argument.IsNotNull(contactRepository, nameof(contactRepository));

            _contactRepository = contactRepository;
        }

        /// <summary>
        /// Добавить контакт
        /// </summary>
        /// <param name="addedContact">Добавляемый контакт</param>
        /// <returns>Контакт</returns>
        public Contact Add(ContactDto addedContact)
        {
            Contract.Argument.IsNotNull(addedContact, nameof(addedContact));

            var contact = _contactRepository.Create(
                email: addedContact.Email,
                postcode: addedContact.Postcode,
                homePhoneNumber: addedContact.HomePhoneNumber,
                workPhoneNumber: addedContact.WorkPhoneNumber,
                mobilePhoneNumber: addedContact.MobilePhoneNumber);

            return contact;
        }
    }
}