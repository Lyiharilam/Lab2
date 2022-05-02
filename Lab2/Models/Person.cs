using Lab2.Exceptions;
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
        public readonly DateTime today = DateTime.Today;
        #endregion

        #region Properties
        public DateTime Birthday
        {
            get { return _birthday; }
            set 
            {
                _birthday = value;
                CalculateAge();
            }
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

        public bool IsBirthday => (Birthday.Day == DateTime.Today.Day && Birthday.Month == DateTime.Today.Month);
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

        #region Methods
        public async Task DetermineWesternZodiacSign()
        {
            await Task.Run(() => 
            {
                int month = Birthday.Month;
                int day = Birthday.Day;
                string sign = "";

                if (month == 12)
                {

                    if (day < 22)
                        sign = "Sagittarius";
                    else
                        sign = "Capricorn";
                }

                else if (month == 1)
                {
                    if (day < 20)
                        sign = "Capricorn";
                    else
                        sign = "Aquarius";
                }

                else if (month == 2)
                {
                    if (day < 19)
                        sign = "Aquarius";
                    else
                        sign = "Pisces";
                }

                else if (month == 3)
                {
                    if (day < 21)
                        sign = "Pisces";
                    else
                        sign = "Aries";
                }
                else if (month == 4)
                {
                    if (day < 20)
                        sign = "Aries";
                    else
                        sign = "Taurus";
                }

                else if (month == 5)
                {
                    if (day < 21)
                        sign = "Taurus";
                    else
                        sign = "Gemini";
                }

                else if (month == 6)
                {
                    if (day < 21)
                        sign = "Gemini";
                    else
                        sign = "Cancer";
                }

                else if (month == 7)
                {
                    if (day < 23)
                        sign = "Cancer";
                    else
                        sign = "Leo";
                }

                else if (month == 8)
                {
                    if (day < 23)
                        sign = "Leo";
                    else
                        sign = "Virgo";
                }

                else if (month == 9)
                {
                    if (day < 23)
                        sign = "Virgo";
                    else
                        sign = "Libra";
                }

                else if (month == 10)
                {
                    if (day < 23)
                        sign = "Libra";
                    else
                        sign = "Scorpio";
                }

                else if (month == 11)
                {
                    if (day < 22)
                        sign = "Scorpio";
                    else
                        sign = "Sagittarius";
                }

                else if (month > 12 || month <= 0)
                {
                    sign = "";
                }

                WesternZodiacSign = sign;
            }
            );
        }

        public async Task DetermineEasternZodiacSign()
        {
            await Task.Run(() => 
            {
                int year = Birthday.Year;
                string[] animals = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
                string[] elements = { "Wood", "Fire", "Earth", "Metal", "Water" };
                string[] animalChars = { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };
                string[,] elementChars = { { "甲", "丙", "戊", "庚", "壬" }, { "乙", "丁", "己", "辛", "癸" } };
                int ei = (int)Math.Floor((year - 4.0) % 10 / 2);
                int ai = (year - 4) % 12;

                EasternZodiacSign = $"{elements[ei]} {animals[ai]}. " +
                    $"{elementChars[year % 2, ei]}" +
                    $"{animalChars[(year - 4) % 12]}";
            });
           
        }

        private void CalculateAge()
        {
            int userAge = today.Year - Birthday.Year;
            if (Birthday.Date > today.AddYears(-userAge)) userAge--;
            Age = userAge;
        }

        #endregion

    }
}
