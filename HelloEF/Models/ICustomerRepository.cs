using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEF.Models
{
    public interface ICustomerRepository
    {

        Customer FindById(int id);
        IEnumerable<Customer> FindAll();
        IEnumerable<Customer> FindByName(string name);
        
        void Add(Customer customer);
        void Update(Customer customer);
    }
}
