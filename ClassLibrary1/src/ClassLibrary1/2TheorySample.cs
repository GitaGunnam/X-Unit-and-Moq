using Xunit;
using System.Collections.Generic;

namespace ClassLibrary1
{
	public class TheorySample
    {
		//[Fact]
		//      public void ForDataDrivenTestsEven()
		//      {
		//	Assert.Equal(true, Even(2));
		//      }


		//[Fact]
		//public void ForDataDrivenTestsOdd()
		//{
		//	Assert.Equal(false, Even(3));
		//}















		[Theory]
		[InlineData(2, true)]
		[InlineData(3, false)]
		public void ForDataDriven(int number, bool expectedResult)
		{
			var actualResult = Even(number);
			Assert.Equal(expectedResult, actualResult);
		}


		bool Even(int x)
		{
			return (x % 2) == 0;
		}



		//public static IEnumerable<object[]> TestData
		//{
		//	get
		//	{
		//		yield return new object[] { 2, true };
		//		yield return new object[] { 3, false };
		//	}
		//}

		//[Theory]
		//[MemberData("TestData")]
		//public void ForDataDrivenUsingMemberData(int number, bool expectedResult)
		//{
		//	var actualResult = Even(number);
		//	Assert.Equal(expectedResult, actualResult);
		//}
	}
}
