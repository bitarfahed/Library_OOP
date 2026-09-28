using System;
using System.Collections.Generic;
 // coded by ChatGPT
namespace Library
{
    internal class Library
    {
        private List<Book> _Books_In_Library;
        private List<Author> _Authors_In_Library;
        private List<LibraryMember> _Members_In_Library;

        public Library()
        {
            this._Books_In_Library = new List<Book>();
            this._Authors_In_Library = new List<Author>();
            this._Members_In_Library = new List<LibraryMember>();
        }

        // -------------------- Books --------------------

        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (!this._Books_In_Library.Contains(book))  this._Books_In_Library.Add(book);

            if (!this._Authors_In_Library.Contains(book.GetAuthor()))
                this._Authors_In_Library.Add(book.GetAuthor());
        }

        public void RemoveBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (!this._Books_In_Library.Contains(book))
                return;

            // Remove the book from every member who borrowed it
            foreach (LibraryMember member in this._Members_In_Library)
            {
                member.ReturnBook(book);
            }

            // Remove the book from its author
            book.GetAuthor().RemoveBook(book);

            // Remove the book from the library
            this._Books_In_Library.Remove(book);
        }

        // -------------------- Authors --------------------

        public void AddAuthor(Author author)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author));

            if (!_Authors_In_Library.Contains(author)) this._Authors_In_Library.Add(author);
        }

        public void RemoveAuthor(Author author)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author));

            if (!_Authors_In_Library.Contains(author))
                return;

            // Get a copy so RemoveBook() can safely modify the library
            List<Book> books = author.GetWrittenBooks();

            foreach (Book book in books)
            {
                RemoveBook(book);
            }

            this._Authors_In_Library.Remove(author);
        }

        // -------------------- Members --------------------

        public void AddMember(LibraryMember member)
        {
            if (member == null) throw new ArgumentNullException(nameof(member));
            if (!this._Members_In_Library.Contains(member))
                this._Members_In_Library.Add(member);
        }

        public void RemoveMember(LibraryMember member)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member));

            if (!this._Members_In_Library.Contains(member))
                return;

            // The books remain in the library.
            member.ReturnAllBook();

            this._Members_In_Library.Remove(member);
        }
    }
}