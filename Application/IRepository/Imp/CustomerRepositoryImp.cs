using Application.IGenericRepository.Imp;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class CustomerRepositoryImp : GenericRepositoryImp<Customer>, ICustomerRepository
    {
        public CustomerRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public Customer CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            return customer;
        }

        public void DeleteCustomer(Guid id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerID == id);
            _context.Customers.Remove(customer);
            SaveChange();
        }
        public List<Customer> GetAll()
        {
            var list = _context.Customers.ToList();
            return list;
        }

        public Customer GetCustomerById(Guid id)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerID == id);
        }


        public void SaveChange()
        {
            _context.SaveChanges();
        }

        public void UpdateCustomer(Guid id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerID == id);
            _context.Customers.Update(customer);
            SaveChange();
        }

    }
}
