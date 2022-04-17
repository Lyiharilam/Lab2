using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models
{
    internal class Person
    {
        #region Fields
        private DateTime _birthday = DateTime.Today;
        private string _name = "";
        private string _surname = "";
        private string _email = "";
        private string _easternZodiacSign = "";
        private string _westernZodiacSign = "";
        private int _age = 0;
        #endregion

        #region Properties
        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public string EasternZodiacSign
        {
            get { return _easternZodiacSign; }
            set { _easternZodiacSign = value; }
        }

        public string Name 
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname 
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public string Email 
        {
            get { return _email; }
            set { _email = value; }
        }

        public string WesternZodiacSign
        {
            get { return _westernZodiacSign; }
            set { _westernZodiacSign = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public bool IsAdult => _age > 18;

        public string SunSign => _westernZodiacSign;

        public string ChineseSign => _easternZodiacSign;

        public bool IsBirthday => (_birthday.Day == DateTime.Today.Day);
        #endregion

        public Person(string name, string surname, string email, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Birthday = birthday;
        }

        public Person(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public Person(string name, string surname, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
        }

        public Person() { }

    }
}
