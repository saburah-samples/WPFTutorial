namespace BusyIndicator.Services
{
    using System;

    public class ApplicationService : IApplicationService, IDisposable
    {
        private bool _isDisposed;

        public ApplicationService(ISchedulerService schedulerService)
        {
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
            }
        }
    }
}