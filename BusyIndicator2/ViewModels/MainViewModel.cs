namespace BusyIndicator.ViewModels
{
    public class MainViewModel : ViewModel, IMainViewModel
    {
        public MainViewModel(IBusyMonitor busyMonitor,
            IHeaderViewModel headerViewModel,
            IContentViewModel contentViewModel,
            IFooterViewModel footerViewModel)
            : base(busyMonitor)
        {
            HeaderPane = headerViewModel;
            ContentPane = contentViewModel;
            FooterPane = footerViewModel;
        }

        public IViewModel HeaderPane { get; private set; }

        public IViewModel ContentPane { get; private set; }

        public IViewModel FooterPane { get; private set; }

        public override void Dispose()
        {
            if (IsDiposed)
            {
                return;
            }

            base.Dispose();

            HeaderPane = null;
            ContentPane = null;
        }
    }
}