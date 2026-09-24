using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Library
{
    enum Type
    {
        fiction, non_fiction, kids, academic, reference
    }
    internal class Book
    {
        private string _Name;
        private int _Year_of_publication;
        private Author _Author;
        private Type _Type;

        public void ToString()
        {
            Console.WriteLine("Book's details: \n" +
                              "book's name: " + this._Name + " \n" + 
                              "published at: " + this._Year_of_publication + "\n" +
                              "written by: " + this._Author + " \n" +
                              "it is about: " + this._Type);
        }
        public Book(string name, int year, Author author, Type type)
        {
            this._Name = name;
            this._Year_of_publication = year;
            this._Author = author;
            if(!Enum.IsDefined(typeof(Type), type)) throw new Exception("invalid value"); // maybe not needed
            else this._Type = type;
        }

        public string GetName()
        {
            return this._Name;
        }
        public int GetpublicationingYear()
        {
            return this._Year_of_publication;
        }
        public Author GetAuthor()
        {
            return this._Author;
        }
        public Enum GetType()
        {
            return this._Type;
        }

        public void SetName(string name)
        {
            this._Name = name;
        }
        public void SetYearOfPublication(int year)
        {
            DateTime now = DateTime.Now;
            if (year> now.Year) throw new Exception("invalid value"); // maybe not needed
            this._Year_of_publication = year;
        }
        public void SetAuthor(Author author)
        {
            this._Author = author;
        }
        public void SetType(Type type)
        {
            if (!Enum.IsDefined(typeof(Type), type)) throw new Exception("invalid value"); // maybe not needed
            else this._Type = type;
        }

    }

}
