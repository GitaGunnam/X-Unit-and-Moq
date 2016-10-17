namespace ClassLibrary1.Moq1
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

		public void Create(CustomerToCreateDto customerToCreateDto)
		{
			var customer = new Customer(customerToCreateDto.Name, customerToCreateDto.City);
			_customerRepository.Save(customer);
		}
	}
}
