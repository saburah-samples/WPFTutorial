namespace BusyIndicator.StartUp
{
    using Autofac;
    using Controls;
    using Services;
    using ViewModels;

    public static class BootStrapper
    {
        private static IContainer _container;

        public static IContainer Container
        {
            get { return _container ?? (_container = Start()); }
        }

        private static IContainer Start()
        {
            var builder = new ContainerBuilder();

            // Configuration & Infrastructure...
            builder.RegisterType<Configuration>().As<IConfiguration>().InstancePerLifetimeScope();
            builder.RegisterType<SchedulerService>().As<ISchedulerService>().InstancePerLifetimeScope();

            // Services...
            builder.RegisterType<ApplicationService>().As<IApplicationService>().InstancePerLifetimeScope();

            // ViewModels...
            builder.RegisterType<BusyMonitor>().As<IBusyMonitor>().InstancePerLifetimeScope();

            builder.RegisterType<MainViewModel>().As<IMainViewModel>();
            builder.RegisterType<HeaderViewModel>().As<IHeaderViewModel>();
            builder.RegisterType<ContentViewModel>().As<IContentViewModel>();
            builder.RegisterType<FooterViewModel>().As<IFooterViewModel>();

            return builder.Build();
        }
    }
}