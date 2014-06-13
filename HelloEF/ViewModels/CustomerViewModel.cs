using HelloEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEF.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        private IEnumerable<Customer> _customers;
        private Customer _currentCustomer;
        private ICustomerRepository _repository;

        public CustomerViewModel()
        {
            _repository = new HelloEF.Data.CustomerRepository(); //TODO: here need instantiate repository
            _customers = _repository.FindAll();

            WireCommands();
        }

        private void WireCommands()
        {
            AddCustomerCommand = new RelayCommand(AddCustomer);
            AddCustomerCommand.IsEnabled = true;
            UpdateCustomerCommand = new RelayCommand(UpdateCustomer);
        }

        public RelayCommand AddCustomerCommand
        {
            get;
            private set;
        }

        public RelayCommand UpdateCustomerCommand
        {
            get;
            private set;
        }

        public IEnumerable<Customer> Customers
        {
            get { return _customers; }
            set { _customers = value; }
        }

        public Customer CurrentCustomer
        {
            get
            {
                return _currentCustomer;
            }

            set
            {
                if (_currentCustomer != value)
                {
                    _currentCustomer = value;
                    OnPropertyChanged("CurrentCustomer");
                    UpdateCustomerCommand.IsEnabled = true;
                }
            }
        }

        public void AddCustomer()
        {
            _repository.Add(CurrentCustomer);
            _customers = _repository.FindAll();
        }

        public void UpdateCustomer()
        {
            _repository.Update(CurrentCustomer);
        }
    }
}
