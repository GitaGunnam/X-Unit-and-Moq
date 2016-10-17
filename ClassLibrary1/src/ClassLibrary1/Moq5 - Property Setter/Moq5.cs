using Xunit;
using Moq;

namespace ClassLibrary1.Moq5
{
	public class Moq5
    {
		[Fact]
		public void TheLocalTimeZoneShouldBeSet()
		{
			//Arrange
			var mockCustomerRepository = new Mock<ICustomerRepository>();

			var customerService = new CustomerService(
				mockCustomerRepository.Object);

			//Act
			customerService.Create(new CustomerDto());

			//Assert that the property is being executed
			mockCustomerRepository.VerifySet(
				x => x.LocalTimeZone = It.IsAny<string>()); //Verify that it is set to any string
		}

	}	
}
