using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;

namespace BookExtension
{
    public class BookFormatExtension : IFormatProvider, ICustomFormatter
    {
        private IFormatProvider parent;

        public BookFormatExtension() : this(CultureInfo.CurrentCulture)
        {
        }

        public BookFormatExtension(IFormatProvider parent)
        {
            this.parent = parent;
        }
        
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            format = format.Trim().ToUpperInvariant();
            Book book = (Book)arg;

            switch (format)
            {
                case "A":
                    return book.Author + " " + book.Title + " " + book.Year.ToString() + " " + book.PublishingHous + " " + book.Edition.ToString() + " " + book.Pages.ToString() + " " + book.Price.ToString();
                case "F":
                    return book.Author + " " + book.Title + " " + book.Price.ToString();
                default:
                    try
                    {
                        return HandleOtherFormats(format, book);
                    }
                    catch (FormatException e)
                    {
                        throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
                    }
            }
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }
    }
}
