using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Library
{
    internal class Human 
    {
        private string _Name;
        private int _BirthYear;
        private string _Nationality;

        //protected virtual string ToString();

        protected Human(string name, int birthyear, string nationality)
        {
            if (birthyear > DateTime.Now.Year) throw new ArgumentException("invalid birth-year. ", nameof(birthyear));
            if (name == null) throw new ArgumentException("name cannot be empty.", nameof(name));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("name cannot be whitespaces", nameof(name));
            if (nationality == null) throw new ArgumentException("nationality cannot be empty.", nameof(nationality));
            if (string.IsNullOrWhiteSpace(nationality)) throw new ArgumentException("nationality cannot be whitespaces", nameof(nationality));

            this._Name = name;
            this._BirthYear = birthyear;
            this._Nationality = nationality;
        }

        protected string GetName()
        {
            return this._Name;
        }

        protected string GetNationality()
        {
            return this._Nationality;
        }
        protected int GetBirthYear()
        {
            return this._BirthYear;
        }

        protected void SetNationality(string nationality)
        {
            if (nationality == null) throw new ArgumentException("Nationality cannot be empty.", nameof(nationality));
            if (string.IsNullOrWhiteSpace(nationality)) throw new ArgumentException("Nationality cannot be whitespaces", nameof(nationality));
            this._Nationality = nationality;
        }
        protected void SetBirthYear(int year)
        {
            if (year > DateTime.Now.Year) throw new ArgumentException("invalid birth-year. ", nameof(year));
            this._BirthYear = year;
        }
        protected void SetName(string name)
        {
            if (name == null) throw new ArgumentException("human name cannot be empty.", nameof(name));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("human name cannot be whitespaces", nameof(name));
            this._Name = name;
        }
    }
}
