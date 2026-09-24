using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Library
{
    internal class Book
    {
        private string _Name;
        private string _Year_of_publish;
        private string _Author;
        private string _Type; 

        public void ToString()
        {
            Console.WriteLine("Book's details: " + this._Name +
                              "published at: " + this._Year_of_publish,
                              "written by: " + this._Author,
                              "it is about: " + this._Type);
        }
        public Book(string name, string year, string author, string type)
        {
            this._Name = name;
            this._Year_of_publish = year;
            this._Author = author;
            this._Type = type;
        }


    }

}
