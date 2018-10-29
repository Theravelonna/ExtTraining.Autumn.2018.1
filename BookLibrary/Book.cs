using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book : IFormattable
    {
        private string title;
        private string author;
        private int year;
        private string publishingHous;
        private int edition;
        private int pages;
        private int price;

        public Book(string author, string title, int year, string publishingHous, int edition, int pages, int price)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("title mustn't be empty!");
            }
            else
            {
                this.title = title;
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("author mustn't be empty!");
            }
            else
            {
                this.author = author;
            }

            if (year < 0 && year >= 2018)
            {
                throw new ArgumentException("year must be more than 0 and less than 2018!");
            }
            else
            {
                this.year = year;
            }

            if (string.IsNullOrWhiteSpace(publishingHous))
            {
                throw new ArgumentException("publishingHous mustn't be empty!");
            }
            else
            {
                this.publishingHous = publishingHous;
            }

            if (edition < 0)
            {
                throw new ArgumentException("edition must be more than 0!");
            }
            else
            {
                this.edition = edition;
            }

            if (pages < 0)
            {
                throw new ArgumentException("pages must be more than 0!");
            }
            else
            {
                this.pages = pages;
            }

            if (price < 0)
            {
                throw new ArgumentException("price must be more than 0!");
            }
            else
            {
                this.price = price;
            }
        }

        public string AuthorTitleYearPublishingHous
        {
            get { return author + " " + title + " " + year.ToString() + " " + publishingHous; }
        }

        public string AuthorTitleYear
        {
            get { return author + " " + title + " " + year.ToString(); }
        }

        public string AuthorTitle
        {
            get { return author + " " + title; }
        }

        public string TitleYearPublishingHous
        {
            get { return title + " " + year.ToString() + " " + publishingHous; }
        }

        public string Title
        {
            get { return title; }
        }

        public override string ToString()
        {
            return this.ToString("G", CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format))
            {
                format = "G";
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            format = format.Trim().ToUpperInvariant();

            switch (format)
            {
                case "G":
                    return this.AuthorTitleYearPublishingHous.ToString(formatProvider);
                case "B":
                    return this.AuthorTitleYear.ToString(formatProvider);
                case "C":
                    return this.AuthorTitle.ToString(formatProvider);
                case "D":
                    return this.TitleYearPublishingHous.ToString(formatProvider);
                case "E":
                    return this.Title.ToString(formatProvider);
                default:
                    throw new FormatException(String.Format("The '{0}' format string is not supported.", format));
            }
        }
    }
}
