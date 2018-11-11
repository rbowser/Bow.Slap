using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bow.Slap;

namespace Tests
{
	[TestClass]
	public class GeneralArgumentTests
	{
		[TestMethod]
		public void Parses_Multiple_Arguments_In_Order()
		{
			var app = new Application("Test")
				.Argument(new ValueArgument(typeof(int))
								.SetShort("-n")
								.SetName("number"))
				.Argument(new ValueArgument(typeof(double))
								.SetShort("-d")
								.SetName("dub"));

			var result = app.Parse(new[] { "-n", "6", "-d", "2.0" });

			Assert.IsTrue(result.number == 6);
			Assert.IsTrue(result.dub == 2.0);
		}

		[TestMethod]
		public void Parses_Multiple_Arguments_With_Only_One_Passed()
		{
			var app = new Application("Test")
				.Argument(new ValueArgument(typeof(int))
								.SetShort("-n")
								.SetName("number"))
				.Argument(new ValueArgument(typeof(double))
								.SetShort("-d")
								.SetName("dub"));

			var result = app.Parse(new[] { "-n", "6" });

			Assert.IsTrue(result.number == 6);
			Assert.IsTrue(result.dub == default(double));
		}

		[TestMethod]
		public void Parses_Multiple_Arguments_Out_Of_Order()
		{
			var app = new Application("Test")
				.Argument(new ValueArgument(typeof(int))
								.SetShort("-n")
								.SetName("number"))
				.Argument(new ValueArgument(typeof(double))
								.SetShort("-d")
								.SetName("dub"));

			var result = app.Parse(new[] { "-d", "2.0", "-n", "6" });

			Assert.IsTrue(result.number == 6);
			Assert.IsTrue(result.dub == 2.0);
		}

		[TestMethod]
		public void Parses_Two_Switches()
		{
			var app = new Application("Test")
				.Argument(new Switch()
							.SetShort("-k")
							.SetName("kay"))
				.Argument(new Switch()
							.SetShort("-t")
							.SetName("tee"));

			var result = app.Parse(new[] { "-k", "-t" });

			Assert.IsTrue(result.kay == true);
			Assert.IsTrue(result.tee == true);
		}

		[TestMethod]
		public void Parses_Two_Switches_With_One_Not_Passed()
		{
			var app = new Application("Test")
				.Argument(new Switch()
							.SetShort("-k")
							.SetName("kay"))
				.Argument(new Switch()
							.SetShort("-t")
							.SetName("tee"));

			var result = app.Parse(new[] { "-k" });

			Assert.IsTrue(result.kay == true);
			Assert.IsTrue(result.tee == false);
		}
	}
}
