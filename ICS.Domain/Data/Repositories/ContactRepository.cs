using ICS.Domain.Data.Adapters;
using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Entities;
using ICS.Domain.Models;
using ICS.Domain.Services.Contracts;
using ICS.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICS.Domain.Data.Repositories
{
    /// <summary>
    /// Репозиторий контактов
    /// </summary>
    public sealed class ContactRepository : IContactRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly DomainContext _domainContext;

        public ContactRepository(
            IIdGenerator idGenerator,
            DomainContext databaseContext)
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _domainContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        /// <summary>
        /// Получить все контакты
        /// </summary>
        /// <returns>Контакты</returns>
        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            var contacts = await _domainContext.Set<Contact>().ToArrayAsync().ConfigureAwait(false);

            return contacts;
        }

        /// <summary>
        /// Получить контакт
        /// </summary>
        /// <param name="id">Идентификатор контакта</param>
        /// <returns>Контакт</returns>
        public async Task<Contact> GetAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var contact = await _domainContext.Set<Contact>().FindAsync(id).ConfigureAwait(false);

            if (contact == null)
            {
                throw new Exception($"Сущность не найдена для id: {id}");
            }

            return contact;
        }

        /// <summary>
        /// Создать контакт
        /// </summary>
        /// <param name="email">Электронный адрес</param>
        /// <param name="postcode">Почтовый индекс</param>
        /// <param name="homePhoneNumber">Домашний номер телефона</param>
        /// <param name="workPhoneNumber">Рабочий номер телефона</param>
        /// <param name="mobilePhoneNumber">Мобильный номер телефона</param>
        /// <returns></returns>
        public Contact Create(
            string email,
            string postcode,
            string homePhoneNumber,
            string workPhoneNumber,
            string mobilePhoneNumber)
        {
            /*
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(email, nameof(email));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(postcode, nameof(postcode));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(homePhoneNumber, nameof(homePhoneNumber));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(workPhoneNumber, nameof(workPhoneNumber));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(mobilePhoneNumber, nameof(mobilePhoneNumber));
            */

            var createdContact = _domainContext.Set<Contact>().CreateProxy();

            var id = _idGenerator.Generate();
            createdContact.Initialize(
                id: id,
                email: email,
                postcode: postcode,
                homePhoneNumber: homePhoneNumber,
                workPhoneNumber: workPhoneNumber,
                mobilePhoneNumber: mobilePhoneNumber);

            var newContact = _domainContext.Set<Contact>().Add(createdContact);

            return newContact.Entity;
        }

        public async Task UpdateAsync(Guid currentContcatId, ContactDto newContact)
        {
            Contract.Argument.IsNotEmptyGuid(currentContcatId, nameof(currentContcatId));
            Contract.Argument.IsNotNull(newContact, nameof(newContact));

            var currentContact = await GetAsync(currentContcatId).ConfigureAwait(false);

            currentContact.Update(
                email: newContact.Email,
                postcode: newContact.Postcode,
                homePhoneNumber: newContact.HomePhoneNumber,
                workPhoneNumber: newContact.WorkPhoneNumber,
                mobilePhoneNumber: newContact.MobilePhoneNumber);
        }

        /// <summary>
        /// Удалить контакт
        /// </summary>
        /// <param name="id">Идентификатор контакта</param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var deletedContact = await GetAsync(id).ConfigureAwait(false);

            _domainContext.Set<Contact>().Remove(deletedContact);
        }
    }
}