using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassLibrary1.Moq2
{
	public class Customer
	{
		public Customer(string name, string city)
		{

		}
	}

	public class CustomerToCreateDto
	{
		public string Name { get; set; }
		public string City { get; set; }
	}

	public interface ICustomerRepository
	{
		void Save(Customer customer);
	}

	public class CustomerService
	{
		private readonly ICustomerRepository _customerRepository;
		public CustomerService(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public void Create(IEnumerable<CustomerToCreateDto> customerToCreateDto)
		{
			foreach(var customerDto in customerToCreateDto)
			{
				_customerRepository.Save(
					new Customer(
						customerDto.Name, 
						customerDto.City)
					);
			}
		}
	}
}
