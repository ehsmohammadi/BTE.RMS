using BTE.Core;
using BTE.RMS.Persistence;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

public class DomainServiceInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(Classes.FromAssemblyNamed("BTE.RMS.Model")
            .BasedOn<IDomainService>()
            .WithService.FromInterface()
            .LifestyleTransient()
            .Configure(c => c.DependsOn(Dependency.OnValue("meetingRepository", new MeetingRepository(new RMSContext()))))
            //.Configure(c => c.DependsOn(Dependency.OnComponent(typeof(IRepository))))
            );

    }

}