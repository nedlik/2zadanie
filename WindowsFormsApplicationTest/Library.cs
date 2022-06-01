using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;

namespace WindowsFormsApplicationTest
{
    /// <summary>
    /// Класс библиотеки, наследум от BindingList, чтобы получать уведомления при изменении.
    /// </summary>
    public class Library : BindingList<Book>
    {
        public void Load(string fileName)
        {
            Clear();
            XElement document = XElement.Load(fileName);
            IEnumerable<XElement> elements = document.Elements();
            foreach (XElement element in elements)
            {
                Add(new Book
                        {
                            Author = (string) element.Element(Book.Nodes.BookAuthorElement),
                            Name = (string) element.Element(Book.Nodes.BookNameElement),
                            NumberOfCopiesInLibrary =
                                (int) element.Attribute(Book.Nodes.NumberOfCopiesInLibraryAttribute),
                            PublicationDate = (int) element.Attribute(Book.Nodes.PublicationDateAttribute),
                            UdcNumber = (int) element.Attribute(Book.Nodes.UdcNumberAttribute),
                        });
            }
        }

        public void Save(string fileName)
        {
            var element = new XElement(Book.Nodes.Root,
                                       this.Select(book => book.ToXElement())
                );
            element.Save(fileName);
        }
    }
}