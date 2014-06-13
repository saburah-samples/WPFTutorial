using HelloEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEF.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> customers;

        public CustomerRepository()
        {
            //customers = new List<Customer>
            //{
            //    new Customer(){ CustomerID = 1, FullName="Dana Birkby", Phone="394-555-0181"},
            //    new Customer(){ CustomerID = 2, FullName="Adriana Giorgi", Phone="117-555-0119"},
            //    new Customer(){ CustomerID = 3, FullName="Wei Yu", Phone="798-555-0118"}
            //};
            customers = new List<Customer>();
            using (var db = new HelloEFContext())
            {
                customers = db.Customers.ToList<Customer>();
            }
        }

        public Customer FindById(int id)
        {
            return customers.Single(c => c.CustomerID == id);
        }

        public IEnumerable<Customer> FindAll()
        {
            return customers;
        }

        public IEnumerable<Customer> FindByName(string name)
        {
            return customers.FindAll(c => c.FullName == name);
        }

        public void Add(Customer customer)
        {
            var customerForAdd = new Customer()
            {
                FullName = customer.FullName,
                Phone = customer.Phone
            };
            customers.Add(customerForAdd);
        }

        public void Update(Customer customer)
        {
            var customerForUpdate = FindById(customer.CustomerID);
            customerForUpdate = customer;
        }
    }
}
