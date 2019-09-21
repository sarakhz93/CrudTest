using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaraKhezriCrudTest.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();

        void AddCustomer(Customer customer);

        void UpdateCustomer(Customer customer);

        Customer GetCustomerData(int? id);

        Customer GetCustomerDataWithEmail(string email);

        Customer GetCustomerDataWithNameAndDOB(string firstName, string lastName, string DateOfBirth);

        void DeleteCustomer(int? id);

    }
}
