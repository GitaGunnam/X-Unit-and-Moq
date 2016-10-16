using System;

namespace ClassLibrary1.Moq4
{
	#region Setup
	public class Customer
	{
		public Customer(string FullName)
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
	}

	public interface ICustomerFullNameBuilder
	{
		string From(string FirstName, string LastName);
	}


	#endregion

	///////////////////////////////////////////
	//CustomerService
	///////////////////////////////////////////

	public class CustomerService
	{
		private readonly ICustomerRepository _customerRepository;
		private readonly ICustomerFullNameBuilder _customerFullNameBuilder;
		public CustomerService(ICustomerRepository customerRepository, ICustomerFullNameBuilder customerFullNameBuilder)
		{
			_customerRepository = customerRepository;
			_customerFullNameBuilder = customerFullNameBuilder;
		}

		public void Create(CustomerDto customerToCreateDto)
		{
			var fullName = _customerFullNameBuilder.From(
				customerToCreateDto.FirstName,
				customerToCreateDto.LastName);

			var customer = new Customer(fullName);

			_customerRepository.Save(customer);
		}
	}
}
