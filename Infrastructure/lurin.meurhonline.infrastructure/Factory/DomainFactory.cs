using Unity;
using Unity.Injection;

using lurin.meurhonline.infrastructure.factory.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.infrastructure.factory
{
    public static class DomainFactory
    {
        public static IOperation<T> CreateDomain<T, O>(IUnitOfWork unitOfWork)
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType(typeof(IOperation<T>), typeof(O)).RegisterInstance(unitOfWork);

            return container.Resolve<IOperation<T>>();
        }
    }
}
