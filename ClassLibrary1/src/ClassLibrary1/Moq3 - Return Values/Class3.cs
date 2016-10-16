using System;

namespace ClassLibrary1.Moq3
{
	#region Setup
	public class Customer
	{
		public Customer(string name, string city)
		{

		}

		public Address MailingAddress { get; set; }
	}

	public class Address
	{
		public string Country { get; set; }
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

	public interface ICustomerAddressBuilder
	{
		Address From(CustomerToCreateDto customer);
		bool TryParse(string address, out Address outAddress);
	}

	public class InvalidCustomerMailingAddressException : SystemException
	{
		public InvalidCustomerMailingAddressException()
		{

		}
	}

	#endregion

	///////////////////////////////////////////
	//CustomerService
	///////////////////////////////////////////

	public class CustomerService
	{
		private readonly ICustomerRepository _customerRepository;
		private readonly ICustomerAddressBuilder _customerAddressBuilder;
		public CustomerService(ICustomerRepository customerRepository, ICustomerAddressBuilder customerAddressBuilder)
		{
			_customerRepository = customerRepository;
			_customerAddressBuilder = customerAddressBuilder;
		}

		public void Create(CustomerToCreateDto customerToCreateDto)
		{
			var customer = new Customer(customerToCreateDto.Name, customerToCreateDto.City);
			customer.MailingAddress = _customerAddressBuilder.From(customerToCreateDto);

			if (customer.MailingAddress == null)
			{
				throw new InvalidCustomerMailingAddressException();
			}

			_customerRepository.Save(customer);
		}
	}
}
