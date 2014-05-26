namespace BusyIndicator.ViewModels
{
    public interface IMainViewModel
    {
        IViewModel HeaderPane { get; }

        IViewModel ContentPane { get; }
    }
}