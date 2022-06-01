using System;
using System.Xml.Linq;

namespace WindowsFormsApplicationTest
{
    /// <summary>
    ///  Книга.
    /// </summary>
    public class Book
    {
        private string _author;
        private string _name;
        public int UdcNumber { get; set; }

        public string Name
        {
            get { return _name; }
            set { _name = value.Trim(); }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value.Trim(); }
        }

        public int PublicationDate { get; set; }
        public int NumberOfCopiesInLibrary { get; set; }

        // Преобразуем в XElement
        public XElement ToXElement()
        {
            return new XElement(Nodes.BookElement,
                                new XAttribute(Nodes.UdcNumberAttribute, UdcNumber),
                                new XAttribute(Nodes.PublicationDateAttribute, PublicationDate),
                                new XAttribute(Nodes.NumberOfCopiesInLibraryAttribute, NumberOfCopiesInLibrary),
                                new XElement(Nodes.BookNameElement, Name),
                                new XElement(Nodes.BookAuthorElement, Author)
                );
        }

        #region Nested type: Nodes

        public static class Nodes
        {
            public const string Root = "Library";
            public const string BookElement = "Book";
            public const string UdcNumberAttribute = "UdcNumber";
            public const string PublicationDateAttribute = "PublicationDate";
            public const string NumberOfCopiesInLibraryAttribute = "NumberOfCopiesInLibrary";
            public const string BookNameElement = "Name";
            public const string BookAuthorElement = "Author";
        }

        #endregion
    }
}