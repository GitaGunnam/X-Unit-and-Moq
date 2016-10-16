using Xunit;
using Moq;


namespace ClassLibrary1.Moq1
{
	public class Moq1
    {
		//When creating a customer, the repository save should be called
		[Fact]
		public void TheRepositorySaveShouldBeCalled()
		{
			// Arrange
			var mockRepository = new Mock<ICustomerRepository>();
			//mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));
			var customerService = new CustomerService(mockRepository.Object);

			// Act
			customerService.Create(new CustomerToCreateDto());

			// Assert
			mockRepository.VerifyAll();
			mockRepository.Verify(x => x.Save(It.IsAny<Customer>()));
		}
    }	
}
