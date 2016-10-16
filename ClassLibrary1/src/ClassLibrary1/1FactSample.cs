using Xunit;

namespace ClassLibrary1
{
	public class FactSample
    {
		//[Fact]
		//     public void PassingTest()
		//     {
		//Assert.Equal(4, Add(2, 2));
		//     }




		//[Fact]
		//public void FailingTest()
		//{
		//	Assert.Equal(6, Add(2, 2));
		//}



		//[Fact(Skip = "Don't want this test to run")]
		//public void SkippedTest()
		//{
		//	Assert.Equal(6, Add(2, 2));
		//}



		int Add(int x, int y)
		{
			return x + y;
		}

	}
}
