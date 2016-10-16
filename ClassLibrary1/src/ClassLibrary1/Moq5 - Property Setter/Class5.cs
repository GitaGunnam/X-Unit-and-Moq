using System;

namespace ClassLibrary1.Moq5
{
	#region Setup
	public class Customer
	{
		public Customer(string firstName, string lastName)
		{

		}
	}

	public class CustomerDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}

	public interface ICustomerRepository
	{
		void Save(Customer customer);
		string LocalTimeZone { get; set; }
	}

	#endregion

	///////////////////////////////////////////
	//CustomerService
	///////////////////////////////////////////

	public class CustomerService
	{
		private readonly ICustomerRepository _customerRepository;
		public CustomerService(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public void Create(CustomerDto customerToCreateDto)
		{
			var customer = new Customer(
				customerToCreateDto.FirstName,
				customerToCreateDto.LastName);

			_customerRepository.LocalTimeZone = "TimeZone";

			_customerRepository.Save(customer);
		}
	}
}
