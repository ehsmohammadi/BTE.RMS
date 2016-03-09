using BTE.Core;
using BTE.Presentation;
using BTE.Presentation.UI.WPF;
using BTE.RMS.Presentation.Logic;
using BTE.RMS.Presentation.Logic.Controller;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace BTE.RMS.Presentation.WPF
{
    public class Bootstrapper : IBootStrapper
    {
        public void Execute()
        {
            var container = new WindsorContainer();
            //container.Kernel.ComponentModelBuilder.RemoveContributor(
            //    container.Kernel.ComponentModelBuilder.Contributors.OfType<PropertiesDependenciesModelInspector>().Single());
            //container.Kernel.ReleasePolicy = new NoTrackingReleasePolicy();
            //container.AddFacility<EventAggregatorFacility>();
            container.Register
                (
                    Component.For<IWindsorContainer>().Instance(container),
                    Component.For<IViewManager>().ImplementedBy<ViewManager>().LifestyleSingleton(),
                    Component.For<IRMSController>().ImplementedBy<RMSController>().LifestyleSingleton(),
                    Component.For<IEventPublisher>().ImplementedBy<EventPublisher>().LifestyleBoundTo<IService>(),
                    Classes.FromThisAssembly().BasedOn<IView>().WithService.FromInterface().LifestyleTransient(),
                    Classes.FromAssemblyNamed("BTE.RMS.Presentation.Logic.WPF")
                        .BasedOn<WorkspaceViewModel>()
                        .LifestyleTransient(),
                    Classes.FromAssemblyNamed("BTE.RMS.Presentation.Logic.WPF")
                        .BasedOn<IService>()
                        .WithService.FromInterface()
                        .LifestyleSingleton(),
                    Classes.FromAssemblyNamed("BTE.RMS.Presentation.Persistence.WPF")
                        .BasedOn<IRepository>()
                        .WithService.FromInterface()
                        .LifestyleBoundToNearest<IService>()
                );
            var locator = new WindsorServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);

            RMSClientConfig.BaseApiSiteAddress = "http://localhost:9461/";
        }
    }
}
