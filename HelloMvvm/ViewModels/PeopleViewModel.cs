using HelloMvvm.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace HelloMvvm.ViewModels
{
    public class PeopleViewModel: ViewModel
    {
        public PeopleViewModel()
        {
            People = new ObservableCollection<Person>()
            {
                new Person { FirstName="Tom", LastName="Jones", Age=80 }, 
                new Person { FirstName="Dick", LastName="Tracey", Age=40 }, 
                new Person { FirstName="Harry", LastName="Hill", Age=60 }, 
            };

            AddPersonCommand = new RelayCommand(AddPerson);
        }

        public ICommand AddPersonCommand { get; set; }

        public ObservableCollection<Person> People { get; set; }
        
        public Person SelectedPerson
        {
            get
            {
                return this.selectedPerson;
            }
            set
            {
                if (this.selectedPerson != value)
                {
                    RaisePropertyChanging("SelectedPerson");
                    this.selectedPerson = value;
                    RaisePropertyChanged("SelectedPerson");
                }
            }
        }
        private Person selectedPerson;

        private void AddPerson(object parameter)
        {
            if (parameter != null)
            {
                People.Add(new Person() { FirstName = parameter.ToString(), LastName = parameter.ToString(), Age = DateTime.Now.Second });
            }
            else
            {
                MessageBox.Show("parameter == null");
            }
        }
    }
}
