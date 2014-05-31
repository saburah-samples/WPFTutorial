using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HelloMvvm.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private ViewModel contentPane;
        public MainViewModel()
        {
            ContentPane = new HomeViewModel();
            HomeCommand = new RelayCommand(ShowHome);
            PeopleCommand = new RelayCommand(ShowPeople);
        }

        public ViewModel ContentPane {
            get { return contentPane; }
            set
            {
                RaisePropertyChanging("ContentPane");
                contentPane = value;
                RaisePropertyChanged("ContentPane");
            }
        }
        public ICommand HomeCommand { get; set; }
        public ICommand PeopleCommand { get; set; }

        private void ShowHome(object obj)
        {
            ContentPane = new HomeViewModel();
        }
        private void ShowPeople(object obj)
        {
            ContentPane = new PeopleViewModel();
        }
    }
}
