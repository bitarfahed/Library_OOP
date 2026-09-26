using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Author : Human
    {
        List<string> _Awards;
        List<Book> _Written_books;

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

        public int GetWrittenBooksNumber()
        {
            return this._Written_books.Count;
        }
        public void AddBook(Book book)
        {
            this._Written_books.Add(book);
        }
        public List<string> GetAwards()
        {
            return this._Awards;
        }
    }
}
