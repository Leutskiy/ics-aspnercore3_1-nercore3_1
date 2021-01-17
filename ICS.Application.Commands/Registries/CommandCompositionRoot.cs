using ICS.Application.Commands.Read;
using ICS.WebApplication.Commands.Read;
using ICS.WebApplication.Commands.Read.Contracts;
using ICS.WebApplication.Commands.Read.Results;
using LightInject;

namespace ICS.WebApplication.Commands.Registries
{
    public class CommandCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<ForeignParticipantReadCommand>();
            serviceRegistry.Register<UserReadCommand>();
            serviceRegistry.Register<ProfileWriteCommand>();
            serviceRegistry.Register<InvitationWriteCommand>();
			serviceRegistry.Register<AlienWriteCommand>();
			serviceRegistry.Register<EmployeeWriteCommand>()
                ;
            serviceRegistry.Register<EmployeeReadCommand>();

            serviceRegistry.Register<IReadCommand<AlienResult>, AlienReadCommand>();
            serviceRegistry.Register<IReadCommand<ProfileResult>, ProfileReadCommand>();
            serviceRegistry.Register<IReadCommand<ContactResult>, ContactReadCommand>();
            serviceRegistry.Register<IReadCommand<DocumentResult>, DocumentReadCommand>();
            serviceRegistry.Register<IReadCommand<PassportResult>, PassportReadCommand>();

            serviceRegistry.Register<IReadCommand<InvitationResult>, InvitationReadCommand>();
            serviceRegistry.Register<IReadCommand<VisitDetailResult>, VisitDetailReadCommand>();
            serviceRegistry.Register<IReadCommand<OrganizationResult>, OrganizationReadCommand>();
            serviceRegistry.Register<IReadCommand<StateRegistrationResult>, StateRegistrationReadCommand>();
            serviceRegistry.Register<IReadCommand<ForeignParticipantResult>, ForeignParticipantReadCommand>();
        }
    }
}