using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Author : Human
    {
        private List<string> _Awards;
        private List<Book> _Written_books;

        public Author(
            string name,
            int birthYear,
            string nationality,
            Gender gender)
            : base(name, birthYear, nationality, gender)
        {
            _Awards = new List<string>();
            _Written_books = new List<Book>();
        }
        public override string ToString()
        {
            return $"Author: {GetName()}, " +
                   $"Birth Year: {GetBirthYear()}, " +
                   $"Age: {GetAge()}, " +
                   $"Nationality: {GetNationality()}, " +
                   $"Gender: {GetGender()}, " +
                   $"Books Written: {_Written_books.Count}, " +
                   $"Awards: {_Awards.Count}";
        }

        public int GetWrittenBooksNumber()
        {
            return this._Written_books.Count;
        }
        public void AddBook(Book book)
        {

            if (book == null) throw new ArgumentNullException(nameof(book));
            
            if(book.GetAuthor()!=this) throw new ArgumentException("This book doesn't belong to this author.");

            if (this._Written_books.Contains(book)) throw new ArgumentException("This book is already associated with the author.");

            this._Written_books.Add(book);
        }
        public void RemoveBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            for (int i = 0; i < this._Written_books.Count; i++)
            {
                if (this._Written_books[i] == book)
                {
                    this._Written_books.RemoveAt(i);
                    i--;
                }
            }
        }
        public List<string> GetAwards()
        {
            return new List<string>(this._Awards);
        }
        public void AddAward(string award)
        {
            if (string.IsNullOrWhiteSpace(award))
            {
                throw new ArgumentException("Award cannot be null or whitespace.");
            }

            this._Awards.Add(award);
        }


        //set awards


        //set written books

        //remove book
    }
}
