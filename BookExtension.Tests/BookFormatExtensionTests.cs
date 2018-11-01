using System;
using NUnit.Framework;
using BookLibrary;
using System.Globalization;

namespace BookExtension.Tests
{
    [TestFixture]
    public class BookFormatExtensionTests
    {
        [Test]
        public void Format_SetDatAndArhumentA_GetExpectedResult()
        {
            Book book = new Book("Jon Skeet", "C# in Depth", 2019, "Manning", 4, 900, 40);
            string result = String.Format(new BookFormatExtension(), "{0:A}", book);
            string expectedResult = "Jon Skeet C# in Depth 2019 Manning 4 900 40,00 ₽";
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Format_SetDatAndArhumentF_GetExpectedResult()
        {
            Book book = new Book("Jon Skeet", "C# in Depth", 2019, "Manning", 4, 900, 40);
            string result = String.Format(new BookFormatExtension(new CultureInfo("en-US")), "{0:F}", book);
            string expectedResult = "Jon Skeet C# in Depth $40.00";
            Assert.AreEqual(expectedResult, result);
        }
    }
}
