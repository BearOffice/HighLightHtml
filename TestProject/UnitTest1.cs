using HighLightHtml;

namespace TestProject;

[TestClass]
public class UnitTest1
{
	[TestMethod]
	public void TestMethod1()
	{
		var htmlA = new HighLight().GetHtml("function a()");
		Console.WriteLine(htmlA);

		var htmlB = new HighLight().GetHtml("cs", @"using HighLightHtml;

namespace TestProject;

[TestClass]
public class UnitTest1
{
	[TestMethod]
	public void TestMethod1()
	{
		var htmlA = new HighLight().GetHtml(""function"");
		Console.WriteLine(htmlA);

		var htmlB = new HighLight().GetHtml(""function"");
		Console.WriteLine(htmlB);
	}
}");
		Console.WriteLine(htmlB);
	}
}