using System;


namespace Library
{
    public enum BookType
    {
        Fiction, NonFiction, Kids, Academic, Reference
    }
    public class Book
    {
        private string _Name;
        private int _Year_of_publication;
        private Author _Author;
        private BookType _Type;

        public override string ToString()
        {
            return "Book's details: " + "\n"+
                              "book's name: " + this._Name + " \n" + 
                              "published at: " + this._Year_of_publication + "\n" +
                              "written by: " + this._Author + " \n" +
                              "it is about: " + this._Type;
        }
        public Book(string name, int year, Author author, BookType type)
        {
            DateTime now = DateTime.Now;
            if (author == null) throw new ArgumentNullException(nameof(author));
            if (!Enum.IsDefined(typeof(BookType), type)) throw new ArgumentException("invalid book type.", nameof(type));
            if (year > now.Year) throw new ArgumentException("invalid publication year.", nameof(year));
            if (name == null) throw new ArgumentException("book name cannot be null");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("book name cannot be whitespaces");

            this._Name = name;
            this._Year_of_publication = year;
            this._Author = author;
            this._Type = type;
            author.AddBook(this);
        }

        public string GetName()
        {
            return this._Name;
        }
        public int GetPublicationYear()
        {
            return this._Year_of_publication;
        }
        public Author GetAuthor()
        { 
            return this._Author;
        }
        public BookType GetBookType()
        {
            return this._Type;
        }

        public void SetName(string name)
        {
            if (name==null) throw new ArgumentException("Book name cannot be empty.", nameof(name));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("book name cannot be whitespaces", nameof(name));
            this._Name = name;
        }
        public void SetYearOfPublication(int year)
        {
            DateTime now = DateTime.Now;
            if (year> now.Year) throw new ArgumentException("invalid publication year.", nameof(year));
            this._Year_of_publication = year;
        }
        public void SetAuthor(Author other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            if (other == this._Author)
            {
                return;
            }

            Author oldAuthor = this._Author;

            oldAuthor.RemoveBook(this);

            this._Author = other;

            this._Author.AddBook(this);
        }
        public void SetType(BookType type)
        {
            if (!Enum.IsDefined(typeof(BookType), type)) throw new ArgumentException("invalid book type.", nameof(type));
            this._Type = type;
        }

    }
}
