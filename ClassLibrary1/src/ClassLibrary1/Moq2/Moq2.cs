using Xunit;
using Moq;
using System.Collections.Generic;


namespace ClassLibrary1.Moq2
{
	public class Moq2
    {
		[Fact]
		public void TheRepositorySaveShouldBeCalled()
		{
			// Arrange
			var mockRepository = new Mock<ICustomerRepository>();
			var customerService = new CustomerService(mockRepository.Object);

			var listOfCustomersToCreateDtos = new List<CustomerToCreateDto>
			{
				new CustomerToCreateDto {Name = "Name1", City = "City1" },
				new CustomerToCreateDto {Name = "Name2", City = "City2" }
			};

			// Act
			customerService.Create(listOfCustomersToCreateDtos);

			// Assert
			mockRepository.Verify(x => x.Save(It.IsAny<Customer>()), Times.Exactly(listOfCustomersToCreateDtos.Count));
		}
    }	
}
