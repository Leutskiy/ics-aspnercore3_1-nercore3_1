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
        }
    }
}
