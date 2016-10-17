using Xunit;
using Moq;

namespace ClassLibrary1.Moq4
{
	public class Moq4
    {
		//Ensure that the correct values are passed through the dependency
		[Fact]
		public void FullNameCreatedFromFirstAndLastName()
		{
			//Arrange
			var mockCustomerRepository = new Mock<ICustomerRepository>();
			var mockFullNameBuilder = new Mock<ICustomerFullNameBuilder>();

			//We expect the full name builder to be called and don't care about the values sent
			mockFullNameBuilder.Setup(
				x => x.From(It.IsAny<string>(), It.IsAny<string>()));

			var customerService = new CustomerService(
				mockCustomerRepository.Object, mockFullNameBuilder.Object);

			var customerToCreateDto = new CustomerDto
				{
					FirstName = "first",
					LastName = "last"
				};

			//Act
			customerService.Create(customerToCreateDto);

			//Assert
			//Exact values
			//It is a string, and that string is going to be checking the equals.
			//ON the string run the equals and make sure the string value being passed
			//is the first name
			mockFullNameBuilder.Verify(x => x.From(
				It.Is<string>(
					fn => fn.Equals(customerToCreateDto.FirstName, System.StringComparison.InvariantCultureIgnoreCase)),
				It.Is<string>(
					ln => ln.Equals(customerToCreateDto.LastName, System.StringComparison.InvariantCultureIgnoreCase))));
		}

	}	
}
