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
        private Person _user = new();
        private bool _isFormFilled = false;
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

        public string Name
        {
            get { return _user.Name; }
            set
            {
                _user.Name = value;
                ValidateForm();
                NotifyPropertyChanged();
            }
        }

        public string NameToDisplay
        {
            get { return _user.Name; }
            set
            {
                _user.Name = value;
                NotifyPropertyChanged();
            }
        }

        public string Surname
        {
            get { return _user.Surname; }
            set
            {
                _user.Surname = value;
                ValidateForm();
                NotifyPropertyChanged();
            }
        }

        public string SurnameToDisplay
        {
            get { return _user.Surname; }
            set
            {
                _user.Surname = value;
                NotifyPropertyChanged();
            }
        }

        public string Email
        {
            get { return _user.Email; }
            set
            {
                _user.Email = value;
                ValidateForm();
                NotifyPropertyChanged();
            }
        }

        public string EmailToDisplay
        {
            get { return _user.Email; }
            set
            {
                _user.Email = value;
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
                ValidateForm();
                NotifyPropertyChanged();
            }
        }

        public bool IsFormFilled
        {
            get { return _isFormFilled; }
            set
            {
               _isFormFilled = value;
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

        private void ValidateForm()
        {
            IsFormFilled =
                !(
                String.IsNullOrWhiteSpace(_user.Name)
                || String.IsNullOrWhiteSpace(_user.Email)
                || String.IsNullOrWhiteSpace(_user.Surname)
                );
        }

        private async void Submit()
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
            WesternZodiacSign = await DetermineWesternZodiacSign(_user.Birthday);
            EasternZodiacSign = await DetermineEasternZodiacSign(_user.Birthday);
            NameToDisplay = _user.Name;
            SurnameToDisplay = _user.Surname;
            EmailToDisplay = _user.Email;

        }

        private Task <string> DetermineWesternZodiacSign(DateTime birthday)
        {
            int month = birthday.Month;
            int day = birthday.Day;

            if (month == 12)
            {

                if (day < 22)
                    return Task.FromResult("Sagittarius");
                else
                    return Task.FromResult("Capricorn");
            }

            else if (month == 1)
            {
                if (day < 20)
                    return Task.FromResult("Capricorn");
                else
                    return Task.FromResult("Aquarius");
            }

            else if (month == 2)
            {
                if (day < 19)
                    return Task.FromResult("Aquarius");
                else
                    return Task.FromResult("Pisces");
            }

            else if (month == 3)
            {
                if (day < 21)
                    return Task.FromResult("Pisces");
                else
                    return Task.FromResult("Aries");
            }
            else if (month == 4)
            {
                if (day < 20)
                    return Task.FromResult("Aries");
                else
                    return Task.FromResult("Taurus");
            }

            else if (month == 5)
            {
                if (day < 21)
                    return Task.FromResult("Taurus");
                else
                    return Task.FromResult("Gemini");
            }

            else if (month == 6)
            {
                if (day < 21)
                    return Task.FromResult("Gemini");
                else
                    return Task.FromResult("Cancer");
            }

            else if (month == 7)
            {
                if (day < 23)
                    return Task.FromResult("Cancer");
                else
                    return Task.FromResult("Leo");
            }

            else if (month == 8)
            {
                if (day < 23)
                    return Task.FromResult("Leo");
                else
                    return Task.FromResult("Virgo");
            }

            else if (month == 9)
            {
                if (day < 23)
                    return Task.FromResult("Virgo");
                else
                    return Task.FromResult("Libra");
            }

            else if (month == 10)
            {
                if (day < 23)
                    return Task.FromResult("Libra");
                else
                    return Task.FromResult("Scorpio");
            }

            else if (month == 11)
            {
                if (day < 22)
                    return Task.FromResult("Scorpio");
                else
                    return Task.FromResult("Sagittarius");
            }

            return Task.FromResult("");
        }

        private Task <string> DetermineEasternZodiacSign(DateTime birthday)
        {
            int year = birthday.Year;
             string[] animals = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
             string[] elements = { "Wood", "Fire", "Earth", "Metal", "Water" };
             string[] animalChars = { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };
             string[,] elementChars = { { "甲", "丙", "戊", "庚", "壬" }, { "乙", "丁", "己", "辛", "癸" } };
             int ei = (int)Math.Floor((year - 4.0) % 10 / 2);
             int ai = (year - 4) % 12;
             return
                 Task.FromResult($"{elements[ei]} {animals[ai]}. " +
                 $"{elementChars[year % 2, ei]}" +
                 $"{animalChars[(year - 4) % 12]}");
        }
        #endregion


    }
}
