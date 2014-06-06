using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelloAsync
{
    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/ms228969(v=vs.100).aspx
    /// Asynchronous Programming Design Patterns
    /// http://msdn.microsoft.com/ru-ru/magazine/dd419663.aspx
    /// Приложения WPF с шаблоном проектирования модель-представление-модель представления
    /// http://www.wpf-tutorial.com/list-controls/itemscontrol/
    /// The ItemsControl
    /// http://msdn.microsoft.com/en-us/library/gg405484(v=pandp.40).aspx
    /// 5: Implementing the MVVM Pattern Using the Prism Library 5.0 for WPF
    /// https://code.google.com/p/sch200905/source/browse/trunk/?r=2#trunk%2FExchangeRateService
    /// examples
    /// </summary>
    public class ShellViewModel: ViewModel
    {
        public delegate void AsyncProcessCaller(int duaration);

        public ShellViewModel()
        {
            isBusy = false;
            Duaration = 5;
            Commands = CreateCommands();
        }

        public ReadOnlyCollection<CommandViewModel> Commands { get; private set; }

        protected ReadOnlyCollection<CommandViewModel> CreateCommands()
        {
            var list = new List<CommandViewModel>();

            var cmd = new RelayCommand(
                param => { StartProcess(); },
                (param) => { return CanStartProcess(); }
                );
            list.Add(new CommandViewModel("Start process", cmd));

            cmd = new RelayCommand(
                param => { CancelProcess(); },
                (param) => { return CanCancelProcess(); }
                );
            list.Add(new CommandViewModel("Cancel process", cmd));

            return new ReadOnlyCollection<CommandViewModel>(list);
        }

        private bool CanStartProcess()
        {
            return !IsBusy;
        }

        private void StartProcess()
        {
            // Create the delegate.
            var caller = new AsyncProcessCaller((p) => { Thread.Sleep(1000 * p); WaitEnd(); });

            WaitBegin();
            // Initiate the asychronous call.
            IAsyncResult result = caller.BeginInvoke(Duaration, null, null);
            // Call EndInvoke to wait for the asynchronous call to complete,
            // and to retrieve the results.
            caller.EndInvoke(result);            
        }

        private bool CanCancelProcess()
        {
            return IsBusy;
        }

        private void CancelProcess()
        {
            WaitEnd();
        }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            private set
            {
                isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }
        public void WaitBegin() { IsBusy = true; }
        public void WaitEnd() { IsBusy = false; }

        public int Duaration { get; set; }
    }
}
