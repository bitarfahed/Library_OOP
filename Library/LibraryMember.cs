using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Library
{
    public enum MembershipType
    {
        paid, free
    }
    public class LibraryMember : Human
    {
        List<Book> _Borrowed_Books;
        int _Join_Year;
        static int _Max_Borrowed_books = 5;
        public LibraryMember(string name, int birthyear, string nationality, Gender gender, int join_year) : base(name, birthyear, nationality, gender)
        {
            this._Join_Year = join_year;
            _Join_Year = join_year;
            _Borrowed_Books = new List<Book>();

        }


        public void AddBook(Book book)
        {
            if (this.GetBorrowedBooksNumber() >=5) throw new ArgumentException("This Library Memebr has 5 books, Cannot borrow any additional book");
            if (book == null) throw new ArgumentNullException(nameof(book));

            if (this._Borrowed_Books.Contains(book)) throw new ArgumentException("This Library member already borrows this book. ");

            this._Borrowed_Books.Add(book);
        }



        public void RemoveBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            foreach (Book b in this._Borrowed_Books)
            {
                if (b == book) this._Borrowed_Books.Remove(b);
                break;
            }
        }

        public List<Book> GetBorrowedBooks()
        {
            return this._Borrowed_Books;
        }
        public int GetBorrowedBooksNumber()
        {
            return this._Borrowed_Books.Count;
        }


    }
}
