using System.Linq;
using BTE.Core;
using BTE.Presentation;
using BTE.Presentation.UI.WPF;
using BTE.RMS.Presentation.Logic.Controller;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using Castle.MicroKernel.ModelBuilder.Inspectors;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Releasers;
using Castle.Windsor;

namespace BTE.RMS.Presentation.WPF
{
    public class Bootstrapper : IBootStrapper
    {
        public void Execute()
        {
            var container = new WindsorContainer();
            container.Kernel.ComponentModelBuilder.RemoveContributor(
                container.Kernel.ComponentModelBuilder.Contributors.OfType<PropertiesDependenciesModelInspector>().Single());
            container.Kernel.ReleasePolicy = new NoTrackingReleasePolicy();
            //container.AddFacility<EventAggregatorFacility>();
            container.Register
                (
                Component.For<IWindsorContainer>().Instance(container),
                Component.For<IViewManager>().ImplementedBy<ViewManager>().LifestyleSingleton(),
                Component.For<IRMSController>().ImplementedBy<RMSController>().LifestyleSingleton(),
                Classes.FromThisAssembly().BasedOn<IView>().WithService.FromInterface().LifestyleTransient(),
                Classes.FromAssemblyNamed("BTE.RMS.Presentation.Logic.WPF").BasedOn<WorkspaceViewModel>().LifestyleTransient(),
                Classes.FromAssemblyNamed("BTE.RMS.Presentation.Logic.WPF").BasedOn<IServiceWrapper>().WithService.FromInterface().LifestyleSingleton()
                );
            var locator = new WindsorServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);
        }
    }
}
