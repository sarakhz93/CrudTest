using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaraKhezriCrudTest.Models;

namespace SaraKhezriCrudTest.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            List<Customer> customers = new List<Customer>();
            customers = _customerRepository.GetAllCustomers().ToList();

            return View(customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Customer customer)
        {
            Customer customerWithDuplicateEmail = _customerRepository.GetCustomerDataWithEmail(customer.Email);
            if (customerWithDuplicateEmail != null)
            {
                return Forbid();
            }

            Customer duplicateCustomer = _customerRepository.GetCustomerDataWithNameAndDOB(customer.FirstName, customer.LastName, customer.DateOfBirth);
            if (duplicateCustomer != null)
            {
                return Forbid();
            }

            if (ModelState.IsValid)
            {
                _customerRepository.AddCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer customer = _customerRepository.GetCustomerData(id);

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Customer customer)
        {
            Customer customerWithDuplicateEmail = _customerRepository.GetCustomerDataWithEmail(customer.Email);
            if(customerWithDuplicateEmail != null)
            {
                return Forbid();
            }

            Customer duplicateCustomer = _customerRepository.GetCustomerDataWithNameAndDOB(customer.FirstName, customer.LastName, customer.DateOfBirth);
            if (duplicateCustomer != null)
            {
                return Forbid();
            }

            if (id != customer.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _customerRepository.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer customer = _customerRepository.GetCustomerData(id);

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer customer = _customerRepository.GetCustomerData(id);

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            _customerRepository.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}
