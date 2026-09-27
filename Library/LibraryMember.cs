using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Library
{
    public enum MembershipType
    {
        Paid, Free
    }
    public enum MembershipStatus
    {
        Passive, Active
    }
    public class LibraryMember : Human
    {
        public List<Book> _Borrowed_Books;
        private int _Join_Year;
        public readonly int _Max_Borrowed_books;
        private MembershipType _Type;
        private MembershipStatus _Status;
        public LibraryMember(string name, int birthyear, string nationality, Gender gender,
            int join_year, MembershipType type, MembershipStatus status)
            : base(name, birthyear, nationality, gender)
        {

            if(join_year>DateTime.Now.Year) throw new ArgumentException("invalid join-year. ", nameof(birthyear));
            this._Join_Year = join_year;
            _Borrowed_Books = new List<Book>();
            this._Type = type;
            if (this._Type == MembershipType.Paid) this._Max_Borrowed_books = 10;
            else this._Max_Borrowed_books = 5;
            this._Status = status;
        }
        public int GetJoinYear()
        {
            return this._Join_Year;
        }
        public MembershipType GetMembershipType()
        {
            return this._Type;
        }
        public void SetMembershipType(MembershipType type)
        {
            this._Type = type;
        }
        public MembershipStatus GetMembershipStatus()
        {
            return this._Status;
        }
        public void SetMembershipStatus(MembershipStatus status)
        {
            this._Status = status;
            if (this._Status == MembershipStatus.Passive)
                this._Borrowed_Books.Clear();
        }
        public void BorrowBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            if (this._Status == MembershipStatus.Passive) throw new ArgumentException("This is a Passive member and couldn't borrow any book."); 
            if (this.GetBorrowedBooksNumber() >= _Max_Borrowed_books) throw new ArgumentException("This Library Memebr has many books, Cannot borrow any additional book");
            if (this._Borrowed_Books.Contains(book)) throw new ArgumentException("This Library member already borrows this book. ");

            this._Borrowed_Books.Add(book);
        }

        public void ReturnBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            if (this._Borrowed_Books.Contains(book)) this._Borrowed_Books.Remove(book); // if book exists
            //if book doesn't exist,
        }

        public List<Book> GetBorrowedBooks()
        {
            return new List<Book>(this._Borrowed_Books);
        }
        public int GetBorrowedBooksNumber()
        {
            return this._Borrowed_Books.Count;
        }


    }
}
