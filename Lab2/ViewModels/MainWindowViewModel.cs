using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Lab1.Models;
using Lab1.Utils;
using Lab2.Exceptions;

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

        private static void ValidateEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return;
            else
                throw new InvalidEmail(email + " is Invalid Email Address");
        }

        private async void Submit()
        {
            try
            {
                if (_user.Birthday > _user.today)
                {
                    throw new InvalidFutureDate("Invalid future date");
                }
                if (_user.Age > 135)
                {
                    throw new InvalidPastDate("Invalid past date");
                }
                ValidateEmail(_user.Email);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
            if (_user.IsBirthday)
            {
                MessageBox.Show("Happy birthday!");
            }
            
            await _user.DetermineWesternZodiacSign();
            await _user.DetermineEasternZodiacSign();

            Age = _user.Age;
            WesternZodiacSign = _user.SunSign;
            EasternZodiacSign = _user.ChineseSign;
            NameToDisplay = _user.Name;
            SurnameToDisplay = _user.Surname;
            EmailToDisplay = _user.Email;

        }
        #endregion


    }
}
