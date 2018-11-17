using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book : IFormattable, IComparable, IComparable<Book>
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
            this.title = title;
            this.author = author;
            this.year = year;
            this.publishingHous = publishingHous;
            this.edition = edition;
            this.pages = pages;
            this.price = price;
        }

        public string Title
        {
            get { return title; }
            private set
            {
                if (string.IsNullOrWhiteSpace(title))
                {
                    throw new ArgumentException("title mustn't be empty!");
                }
                else
                {
                    title = value;
                }
            }
        }

        public string Author
        {
            get { return author; }
            private set
            {
                if (string.IsNullOrWhiteSpace(author))
                {
                    throw new ArgumentException("author mustn't be empty!");
                }
                else
                {
                    author = value;
                }
            }
        }

        public int Year
        {
            get { return year; }
            private set
            {
                if (year < 0 && year >= 2018)
                {
                    throw new ArgumentException("year must be more than 0 and less than 2018!");
                }
                else
                {
                    year = value;
                }
            }
        }

        public string PublishingHous
        {
            get { return publishingHous; }
            private set
            {
                if (string.IsNullOrWhiteSpace(publishingHous))
                {
                    throw new ArgumentException("publishingHous mustn't be empty!");
                }
                else
                {
                    publishingHous = value;
                }
            }
        }

        public int Edition
        {
            get { return edition; }
            private set
            {
                if (edition < 0)
                {
                    throw new ArgumentException("edition must be more than 0!");
                }
                else
                {
                    edition = value;
                }
            }
        }

        public int Pages
        {
            get { return pages; }
            private set
            {
                if (pages < 0)
                {
                    throw new ArgumentException("pages must be more than 0!");
                }
                else
                {
                    pages = value;
                }
            }
        }

        public int Price
        {
            get { return price; }
            private set
            {
                if (price < 0)
                {
                    throw new ArgumentException("price must be more than 0!");
                }
                else
                {
                    price = value;
                }
            }
        }

        private string AuthorTitleYearPublishingHous
        {
            get
            {
                return $"{author} {title} {year.ToString()} {publishingHous}";
            }
        }

        private string AuthorTitleYear
        {
            get { return $"{author} {title} {year.ToString()}"; }
        }

        private string AuthorTitle
        {
            get { return $"{author} {title}"; }
        }

        private string TitleYearPublishingHous
        {
            get { return $"{title} {year.ToString()} {publishingHous}"; }
        }

        public int CompareTo(object obj)
        {
            Book book = (Book)obj;
            return this.CompareTo(book);
        }

        public int CompareTo(Book book)
        {
            if (this == null)
            {
                if (book == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }

            if (book == null)
            {
                return 1;
            }

            if (this.Author == book.Author && this.Edition == book.Edition && this.Pages == book.Pages && this.Price == book.Price && this.Title == book.Title && this.Year == book.Year)
            {
                return 0;
            }

            return this.Price - book.Price;
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
                    throw new FormatException(string.Format("The '{0}' format string is not supported.", format));
            }
        }
    }
}
