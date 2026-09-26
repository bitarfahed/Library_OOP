using System;

namespace Library
{
    public enum Gender
    {
        Male, Female
    }
    public class Human 
    {
        private string _Name;
        private int _BirthYear;
        private string _Nationality;
        private readonly Gender _Gender;
        private readonly int _ID;
        private static int _NextID=1;


        public override string ToString()
        {
            return "Name: " + this._Name + "\n" +
                   "Birth year: " + this._BirthYear + "\n" +
                   "Nationality: " + this._Nationality + "\n" +
                   "Gender: " + this._Gender;
        }
        protected Human(string name, int birthyear, string nationality, Gender gender)
        {

            if (birthyear > DateTime.Now.Year) throw new ArgumentException("invalid birth-year. ", nameof(birthyear));
            if (name == null) throw new ArgumentException("name cannot be empty.", nameof(name));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("name cannot be whitespaces", nameof(name));
            if (nationality == null) throw new ArgumentException("nationality cannot be empty.", nameof(nationality));
            if (string.IsNullOrWhiteSpace(nationality)) throw new ArgumentException("nationality cannot be whitespaces", nameof(nationality));
            if (!Enum.IsDefined(typeof(Gender), gender)) throw new ArgumentException("Invalid gender.", nameof(gender));

            _ID = _NextID;
            _NextID++;

            this._Name = name;
            this._BirthYear = birthyear;
            this._Nationality = nationality;
            this._Gender = gender;
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
        protected int GetAge()
        {
            return DateTime.Now.Year - this._BirthYear;
        }
        protected Gender GetGender()
        {
            return this._Gender;
        }
    }
}
