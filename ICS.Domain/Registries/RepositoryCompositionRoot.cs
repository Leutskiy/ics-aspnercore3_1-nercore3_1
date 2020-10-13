using ICS.Domain.Data.Repositories;
using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Repositories;
using ICS.Domain.Repositories.Contracts;
using LightInject;

namespace ICS.Domain.Registries
{
    public class RepositoryCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IUserRepository, UserRepository>();
            serviceRegistry.Register<IProfileRepository, ProfileRepository>();

            serviceRegistry.Register<IAlienRepository, AlienRepository>();
            serviceRegistry.Register<IContactRepository, ContactRepository>();
            serviceRegistry.Register<IPassportRepository, PassportRepository>();
            serviceRegistry.Register<IEmployeeRepository, EmployeeRepository>();
            serviceRegistry.Register<IDocumentRepository, DocumentRepository>();
            serviceRegistry.Register<IInvitationRepository, InvitationRepository>();
            serviceRegistry.Register<IVisitDetailRepository, VisitDetailRepository>();
            serviceRegistry.Register<IOrganizationRepository, OrganizationRepository>();
            serviceRegistry.Register<IStateRegistrationRepository, StateRegistrationRepository>();
            serviceRegistry.Register<IForeignParticipantRepository, ForeignParticipantRepository>();
        }
    }
}