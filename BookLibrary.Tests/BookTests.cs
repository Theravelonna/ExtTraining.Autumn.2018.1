﻿using System;
using System.Globalization;
using NUnit.Framework;

namespace BookLibrary.Tests
{
    [TestFixture]
    public class BookTets
    {
        [Test]
        public void ToString_SetDatAndArhumentG_GetExpectedResult()
        {
            CultureInfo nl = CultureInfo.CurrentCulture;
            Book book = new Book("Jon Skeet", "C# in Depth", 2019, "Manning", 4, 900, 40);
            string title = book.ToString("G", nl);
            string result = $"{book.Author} {book.Title} {book.Year.ToString()} {book.PublishingHous}";
            Assert.AreEqual(result, title);
        }

        [Test]
        public void ToString_SetDatAndArhumentB_GetExpectedResult()
        {
            CultureInfo nl = CultureInfo.CurrentCulture;
            Book book = new Book("Jon Skeet", "C# in Depth", 2019, "Manning", 4, 900, 40);
            string title = book.ToString("B", nl);
            string result = $"{book.Author} {book.Title} {book.Year.ToString()}";
            Assert.AreEqual(result, title);
        }

        [Test]
        public void ToString_SetDatAndArhumentC_GetExpectedResult()
        {
            CultureInfo nl = CultureInfo.CurrentCulture;
            Book book = new Book("Jon Skeet", "C# in Depth", 2019, "Manning", 4, 900, 40);
            string title = book.ToString("C", nl);
            string result = $"{book.Author} {book.Title}";
            Assert.AreEqual(result, title);
        }

        [Test]
        public void ToString_SetDatAndArhumentD_GetExpectedResult()
        {
            CultureInfo nl = CultureInfo.CurrentCulture;
            Book book = new Book("Jon Skeet", "C# in Depth", 2019, "Manning", 4, 900, 40);
            string title = book.ToString("D", nl);
            string result = $"{book.Title} {book.Year.ToString()} {book.PublishingHous}";
            Assert.AreEqual(result, title);
        }

        [Test]
        public void ToString_SetDatAndArhumentE_GetExpectedResult()
        {
            CultureInfo nl = CultureInfo.CurrentCulture;
            Book book = new Book("Jon Skeet", "C# in Depth", 2019, "Manning", 4, 900, 40);
            string title = book.ToString("E", nl);
            string result = string.Format("{0}", book.Title);
            Assert.AreEqual(result, title);
        }
    }
}
