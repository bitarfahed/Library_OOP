using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Library
{
    enum BookType
    {
        Fiction, NonFiction, Kids, Academic, Reference
    }
    internal class Book
    {
        private string _Name;
        private int _Year_of_publication;
        private Author _Author;
        private BookType _Type;

        public override string ToString()
        {
            return "Book's details: \n" +
                              "book's name: " + this._Name + " \n" + 
                              "published at: " + this._Year_of_publication + "\n" +
                              "written by: " + this._Author + " \n" +
                              "it is about: " + this._Type;
        }
        public Book(string name, int year, Author author, BookType type)
        {
            DateTime now = DateTime.Now;
            if (!Enum.IsDefined(typeof(BookType), type)) throw new ArgumentException("invalid book type.", nameof(type));
            if (year > now.Year) throw new ArgumentException("invalid publication year.", nameof(year));
            if (name == null) throw new ArgumentException("book name cannot be null");
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("book name cannot be whitespaces");

            this._Name = name;
            this._Year_of_publication = year;
            this._Author = author;
            this._Type = type;
        }

        public string GetName()
        {
            return this._Name;
        }
        public int GetpublicationYear()
        {
            return this._Year_of_publication;
        }
        public Author GetAuthor()
        {
            return this._Author;
        }
        public BookType GetType()
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
        public void SetAuthor(Author author)
        {
            this._Author = author;
        }
        public void SetType(BookType type)
        {
            if (!Enum.IsDefined(typeof(BookType), type)) throw new ArgumentException("invalid book type.", nameof(type));
            this._Type = type;
        }

    }
}
