using Xunit;
using Moq;

namespace ClassLibrary1.Moq3
{
	public class Moq3
    {
		//Exception Should be thrown
		[Fact]
		public void TheExceptionShouldBeThrown()
		{
			// Arrange
			var mockRepository = new Mock<ICustomerRepository>();
			var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();

			var customerService = new CustomerService(mockRepository.Object, mockAddressBuilder.Object);

			var customerToCreateDto = new CustomerToCreateDto { Name = "Name1", City = "City1" };

			mockAddressBuilder
				.Setup(x => x.From(It.IsAny<CustomerToCreateDto>()))
				.Returns(() => null); //new Address()

			// Assert
			Assert.Throws<InvalidCustomerMailingAddressException>(() => customerService.Create(customerToCreateDto));
		}

		[Fact]
		public void SaveCustomerWhenAddressIsCreated()
		{
			// Arrange
			var mockRepository = new Mock<ICustomerRepository>();
			var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();

			var customerService = new CustomerService(mockRepository.Object, mockAddressBuilder.Object);

			var customerToCreateDto = new CustomerToCreateDto { Name = "Name1", City = "City1" };

			mockAddressBuilder
				.Setup(x => x.From(It.IsAny<CustomerToCreateDto>()))
				.Returns(() => new Address());

			// Act
			customerService.Create(customerToCreateDto);

			// Assert
			mockRepository.Verify(x => x.Save(It.IsAny<Customer>()), Times.Once);
		}
	}	
}
