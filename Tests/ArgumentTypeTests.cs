using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bow.Slap;
using System;

namespace Tests
{
	[TestClass]
	public class ArgumentTypeTests
	{
		[TestMethod]
		public void Parses_Int_Argument()
		{
			var app = new Application("Test")
				.Argument(new ValueArgument(typeof(int))
								.SetShort("-n")
								.SetName("number"));

			var result = app.Parse(new[] { "-n", "6" });

			Assert.IsTrue(result.number == 6);
			Assert.IsTrue(result.number.GetType() == typeof(int));
		}

		[TestMethod]
		public void Parses_UInt_Argument()
		{
			var app = new Application("Test")
				.Argument(new ValueArgument(typeof(uint))
								.SetShort("-n")
								.SetName("number"));

			var result = app.Parse(new[] { "-n", "6" });

			Assert.IsTrue(result.number == (uint)6);
			Assert.IsTrue(result.number.GetType() == typeof(uint));
		}

		[TestMethod]
		public void Parses_Short_Argument()
		{
			var app = new Application("Test")
				.Argument(new ValueArgument(typeof(short))
								.SetShort("-n")
								.SetName("number"));

			var result = app.Parse(new[] { "-n", "6" });

			Assert.IsTrue(result.number == (short)6);
			Assert.IsTrue(result.number.GetType() == typeof(short));
		}

		[TestMethod]
		public void Parses_UShort_Argument()
		{
			var app = new Application("Test")
				.Argument(new ValueArgument(typeof(ushort))
								.SetShort("-n")
								.SetName("number"));

			var result = app.Parse(new[] { "-n", "6" });

			Assert.IsTrue(result.number == (ushort)6);
			Assert.IsTrue(result.number.GetType() == typeof(ushort));
		}

		[TestMethod]
		public void Parses_Long_Argument()
		{
			var app = new Application("Test")
				.Argument(new ValueArgument(typeof(long))
								.SetShort("-n")
								.SetName("number"));

			var result = app.Parse(new[] { "-n", "6" });

			Assert.IsTrue(result.number == 6L);
			Assert.IsTrue(result.number.GetType() == typeof(long));
		}

		[TestMethod]
		public void Parses_ULong_Argument()
		{
			var app = new Application("Test")
				.Argument(new ValueArgument(typeof(ulong))
								.SetShort("-n")
								.SetName("number"));

			var result = app.Parse(new[] { "-n", "6" });

			Assert.IsTrue(result.number == 6UL);
			Assert.IsTrue(result.number.GetType() == typeof(ulong));
		}

		[TestMethod]
		public void Parses_String_Argument()
		{
			var app = new Application("Test")
				.Argument(new ValueArgument(typeof(string))
								.SetShort("-s")
								.SetName("str"));

			var result = app.Parse(new[] { "-s", "test" });

			Assert.IsTrue(result.str == "test");
			Assert.IsTrue(result.str.GetType() == typeof(string));
		}

		[TestMethod]
		public void Parses_Char_Argument()
		{
			var app = new Application("Test")
				.Argument(new ValueArgument(typeof(char))
								.SetShort("-c")
								.SetName("ch"));

			var result = app.Parse(new[] { "-c", "t" });

			Assert.IsTrue(result.ch == 't');
			Assert.IsTrue(result.ch.GetType() == typeof(char));
		}

		[TestMethod]
		public void Parses_Byte_Argument()
		{
			var app = new Application("Test")
				.Argument(new ValueArgument(typeof(byte))
								.SetShort("-b")
								.SetName("byt"));

			var result = app.Parse(new[] { "-b", "6" });

			Assert.IsTrue(result.byt == (byte)6);
			Assert.IsTrue(result.byt.GetType() == typeof(byte));
		}

		[TestMethod]
		public void Parses_SByte_Argument()
		{
			var app = new Application("Test")
				.Argument(new ValueArgument(typeof(sbyte))
								.SetShort("-b")
								.SetName("byt"));

			var result = app.Parse(new[] { "-b", "6" });

			Assert.IsTrue(result.byt == (sbyte)6);
			Assert.IsTrue(result.byt.GetType() == typeof(sbyte));
		}

		[TestMethod]
		public void Parses_Float_Argument()
		{
			var app = new Application("Test")
				.Argument(new ValueArgument(typeof(float))
								.SetShort("-n")
								.SetName("number"));

			var result = app.Parse(new[] { "-n", "6.0" });

			Assert.IsTrue(result.number == 6.0f);
			Assert.IsTrue(result.number.GetType() == typeof(float));
		}

		[TestMethod]
		public void Parses_Double_Argument()
		{
			var app = new Application("Test")
				.Argument(new ValueArgument(typeof(double))
								.SetShort("-n")
								.SetName("number"));

			var result = app.Parse(new[] { "-n", "6.0" });

			Assert.IsTrue(result.number == 6.0d);
			Assert.IsTrue(result.number.GetType() == typeof(double));
		}

		[TestMethod]
		public void Parses_Decimal_Argument()
		{
			var app = new Application("Test")
				.Argument(new ValueArgument(typeof(decimal))
								.SetShort("-n")
								.SetName("number"));

			var result = app.Parse(new[] { "-n", "6.0" });

			Assert.IsTrue(result.number == 6.0m);
			Assert.IsTrue(result.number.GetType() == typeof(decimal));
		}

		[TestMethod]
		public void Parses_Guid_Argument()
		{
			var app = new Application("Test")
				.Argument(new ValueArgument(typeof(Guid))
								.SetShort("-g")
								.SetName("guid"));

			var result = app.Parse(new[] { "-g", "25e5a2c8-a0ea-452c-809c-df288a4c444c" });

			Assert.IsTrue(result.guid == new Guid("25e5a2c8-a0ea-452c-809c-df288a4c444c"));
			Assert.IsTrue(result.guid.GetType() == typeof(Guid));
		}

		[TestMethod]
		public void Parses_DateTime_Argument()
		{
			// Uses the .NET DateTime.Parse method. Does not give a particular culture, so it should use the machine's culture.
			// This will probably go into the configuration object at some point so that it can be injected, so the test can pass in other cultures.
			var app = new Application("Test")
				.Argument(new ValueArgument(typeof(DateTime))
								.SetShort("-d")
								.SetName("date"));

			var result = app.Parse(new[] { "-d", "11/9/2018" });

			Assert.IsTrue(result.date == new DateTime(2018,11,9));
			Assert.IsTrue(result.date.GetType() == typeof(DateTime));
		}

		[TestMethod]
		public void Parses_Bool_Argument()
		{
			// I don't know why you would do this instead of a switch, but it should probably be handled.
			var app = new Application("Test")
				.Argument(new ValueArgument(typeof(bool))
								.SetShort("-b")
								.SetName("boolean"));

			var result = app.Parse(new[] { "-b", "true" });

			Assert.IsTrue(result.boolean == true);
			Assert.IsTrue(result.boolean.GetType() == typeof(bool));
		}

		[TestMethod]
		public void Parses_Switch()
		{
			var app = new Application("Test")
				.Argument(new Switch()
							.SetShort("-k")
							.SetName("kay"));

			var result = app.Parse(new[] { "-k" });

			Assert.IsTrue(result.kay == true);
			Assert.IsTrue(result.kay.GetType() == typeof(bool));
		}
	}
}
