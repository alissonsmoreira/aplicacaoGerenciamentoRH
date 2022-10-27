using Unity;
using Unity.Injection;

using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.infrastructure.factory
{
    public static class RepositoryFactory
    {
        public static IRepository<T> CreateRepository<T, R>(IUnitOfWork unitOfWork)
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType(typeof(IRepository<T>), typeof(R), new InjectionConstructor(unitOfWork));

            return container.Resolve<IRepository<T>>();
        }

        public static IRepositoryCustom<T> CreateRepositoryCustom<T, R>(IUnitOfWork unitOfWork)
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType(typeof(IRepositoryCustom<T>), typeof(R), new InjectionConstructor(unitOfWork));

            return container.Resolve<IRepositoryCustom<T>>();
        }
    }
}