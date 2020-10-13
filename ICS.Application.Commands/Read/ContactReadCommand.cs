using ICS.Domain.Data.Repositories.Contracts;
using ICS.Shared;
using ICS.WebApplication.Commands.Converters;
using ICS.WebApplication.Commands.Read.Contracts;
using ICS.WebApplication.Commands.Read.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICS.WebApplication.Commands.Read
{
    /// <summary>
    /// Команда чтения контакта
    /// </summary>
    public sealed class ContactReadCommand : IReadCommand<ContactResult>
    {
        private readonly IContactRepository _contactRepository;

        public ContactReadCommand(IContactRepository contactRepository)
        {
            Contract.Argument.IsNotNull(contactRepository, nameof(contactRepository));

            _contactRepository = contactRepository;
        }

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="contactId">Идентификатор контакта</param>
        /// <returns>Информация о контакте</returns>
        public async Task<ContactResult> ExecuteAsync(Guid contactId)
        {
            Contract.Argument.IsNotEmptyGuid(contactId, nameof(contactId));

            var contact = await _contactRepository.GetAsync(contactId).ConfigureAwait(false);

            return DomainEntityConverter.ConvertToResult(contact: contact);
        }

        public Task<IEnumerable<ContactResult>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}