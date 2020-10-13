using ICS.Domain.Services;
using ICS.Domain.Services.Contracts;
using LightInject;

namespace ICS.Domain.Registries
{
    public class ServiceCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IClock, SystemClock>();
            serviceRegistry.Register<IIdGenerator, IdGenerator>();
            serviceRegistry.Register<IUserInfoProvider, UserInfoProvider>();
            serviceRegistry.Register<IAlienService, AlienService>();
            serviceRegistry.Register<IContactService, ContactService>();
            serviceRegistry.Register<IEmployeeService, EmployeeService>();
            serviceRegistry.Register<IPassportService, PassportService>();
            serviceRegistry.Register<IInvitationService, InvitationService>();
            serviceRegistry.Register<IVisitDetailService, VisitDetailService>();
            serviceRegistry.Register<IOrganizationService, OrganizationService>();
            serviceRegistry.Register<IStateRegistrationService, StateRegistrationService>();
            serviceRegistry.Register<IForeignParticipantService, ForeignParticipantService>();
        }
    }
}
