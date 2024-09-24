using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using uniofwork.Repositories;
using uniofwork.Data;

public static class UnityConfig
{
    public static void RegisterComponents()
    {
        var container = new UnityContainer();

        container.RegisterType<ApplicationDbContext>();
        container.RegisterType<ICustomerRepository, CustomerRepository>();
        container.RegisterType<IOrderRepository, OrderRepository>();
        container.RegisterType<IUnitOfWork, UnitOfWork>();

        DependencyResolver.SetResolver(new UnityDependencyResolver(container));
    }
}
