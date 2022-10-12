using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConditionCheck
{
    internal class DateClass
    {
        private readonly int year, month, day;
        internal DateClass(int year, int month, int day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
        }

        public int GetYear()
        {
            return year;
        }

        public int GetMonth()
        {
            return month;
        }

        public int GetDay()
        {
            return day;
        }

        public string GetStringDate()
        {
            return $"{day}.{month}.{year}";
        }
    }
}
