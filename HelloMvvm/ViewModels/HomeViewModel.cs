using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HelloMvvm.ViewModels
{
    public class HomeViewModel : ViewModel
    {
        public HomeViewModel()
        {
            ShowPeopleCommand = new RelayCommand(ShowPeople);
        }
        public string Title { get { return "Home"; } }
        public ICommand ShowPeopleCommand { get; private set; }

        private void ShowPeople(object parameter)
        {
            var model = new PeopleViewModel();
        }
    }
}
