using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models
{
    internal class User
    {
        #region Fields
        private DateTime _birthday = DateTime.Today;
        private string _easternZodiacSign;
        private string _westernZodiacSign;
        private int _age;
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
        #endregion

    }
}
