using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    internal class Library
    {
        private List<Book> _Books_In_Library;
        private List<Author> _Authors_In_Library;
        private List<LibraryMember> _Members_In_Library;

        public Library()
        {
            
        }

        public void AddBookToLibrary(Book b)
        {
            if(!this._Books_In_Library.Contains(b))
                this._Books_In_Library.Add(b);
        }
        public void AddAuthorToLibrary(Author a)
        {
            if (!this._Authors_In_Library.Contains(a)) this._Authors_In_Library.Add(a);
        }
        public void AddMemberToLibrary(LibraryMember m)
        {
            if (!this._Members_In_Library.Contains(m)) this._Members_In_Library.Add(m);
        }

        public void RemoveBookFromLibrary(Book b)
        {
            if (this._Books_In_Library.Contains(b)) this._Books_In_Library.Remove(b); 
        }
        public void RemoveMemberFromLibrary(LibraryMember m)
        {
            if (this._Members_In_Library.Contains(m)) this._Members_In_Library.Remove(m);
        }
        public void RemoveAuthorFromLibrary(Author a)
        {
            if (this._Authors_In_Library.Contains(a)) this._Authors_In_Library.Remove(a);
            for(int i =0; i<this._Books_In_Library.Count; i++)
            {
                Book b = this._Books_In_Library[i];
                if (b.GetAuthor() == a)
                { this._Books_In_Library.Remove(b); i--; }

            }
        }
        public void PrintBooks()
        {
            foreach (Book b in this._Books_In_Library) { b.ToString(); Console.WriteLine(); }
        }
        public void PrintMembers()
        {
            foreach (LibraryMember m in this._Members_In_Library) { m.ToString(); Console.WriteLine(); }
        }
        public void PrintAuthors()
        {
            foreach (Author a in this._Authors_In_Library) { a.ToString(); Console.WriteLine(); }
        }
    }
}
