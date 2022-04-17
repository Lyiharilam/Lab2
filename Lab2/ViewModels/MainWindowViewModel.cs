using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Lab1.Models;
using Lab1.Utils;

namespace Lab1.ViewModels
{
    internal class MainWindowViewModel: INotifyPropertyChanged
    {
        #region Fields
        private User _user = new();
        #endregion

        #region Commands
        private RelayCommand<object> _submitCommand;
        #endregion

        #region Properties
        public DateTime Birthday
        {
            get { return _user.Birthday; }
            set
            {
                _user.Birthday = value;
            }
        }

        public string EasternZodiacSign
        {
            get { return _user.EasternZodiacSign; }
            set
            {
                _user.EasternZodiacSign = value;
                NotifyPropertyChanged();
            }
        }

        public string WesternZodiacSign
        {
            get { return _user.WesternZodiacSign; }
            set
            {
                _user.WesternZodiacSign = value;
                NotifyPropertyChanged();
            }
        }

        public int Age
        {
            get { return _user.Age; }
            set 
            {
                _user.Age = value;
                NotifyPropertyChanged();
            }
        }

        public RelayCommand<object> SubmitCommand
        {
            get
            {
                return _submitCommand ??= new RelayCommand<object>(_ => Submit(), CanExecute);
            }
            
        }
        #endregion

        #region Methods
        private bool CanExecute(object obj)
        {
            return true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void Submit()
        {
            var today = DateTime.Today;
            int userAge = today.Year - _user.Birthday.Year;
            if (_user.Birthday.Date > today.AddYears(-userAge)) userAge--;
            if (_user.Birthday > today || userAge > 135)
            {
                MessageBox.Show("Invalid date");
                return;
            }
            if (_user.Birthday == today)
            {
                MessageBox.Show("Happy birthday!");
            }
            Age = userAge;
            WesternZodiacSign = DetermineWesternZodiacSign(_user.Birthday);
            EasternZodiacSign = DetermineEasternZodiacSign(_user.Birthday);

        }

        private string DetermineWesternZodiacSign(DateTime birthday)
        {
            int month = birthday.Month;
            int day = birthday.Day;

            if (month == 12)
            {

                if (day < 22)
                    return "Sagittarius";
                else
                    return "Capricorn";
            }

            else if (month == 1)
            {
                if (day < 20)
                    return "Capricorn";
                else
                    return "Aquarius";
            }

            else if (month == 2)
            {
                if (day < 19)
                    return "Aquarius";
                else
                    return "Pisces";
            }

            else if (month == 3)
            {
                if (day < 21)
                    return "Pisces";
                else
                    return "Aries";
            }
            else if (month == 4)
            {
                if (day < 20)
                    return "Aries";
                else
                    return "Taurus";
            }

            else if (month == 5)
            {
                if (day < 21)
                    return "Taurus";
                else
                    return "Gemini";
            }

            else if (month == 6)
            {
                if (day < 21)
                    return "Gemini";
                else
                    return "Cancer";
            }

            else if (month == 7)
            {
                if (day < 23)
                    return "Cancer";
                else
                    return "Leo";
            }

            else if (month == 8)
            {
                if (day < 23)
                    return "Leo";
                else
                    return "Virgo";
            }

            else if (month == 9)
            {
                if (day < 23)
                    return "Virgo";
                else
                    return "Libra";
            }

            else if (month == 10)
            {
                if (day < 23)
                    return "Libra";
                else
                    return "Scorpio";
            }

            else if (month == 11)
            {
                if (day < 22)
                    return "Scorpio";
                else
                    return "Sagittarius";
            }

            return "";
        }

        private string DetermineEasternZodiacSign(DateTime birthday)
        {
            int year = birthday.Year;
             string[] animals = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
             string[] elements = { "Wood", "Fire", "Earth", "Metal", "Water" };
             string[] animalChars = { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };
             string[,] elementChars = { { "甲", "丙", "戊", "庚", "壬" }, { "乙", "丁", "己", "辛", "癸" } };
             int ei = (int)Math.Floor((year - 4.0) % 10 / 2);
             int ai = (year - 4) % 12;
             return
                 $"{elements[ei]} {animals[ai]}. " +
                 $"{elementChars[year % 2, ei]}" +
                 $"{animalChars[(year - 4) % 12]}";
        }
        #endregion


    }
}
