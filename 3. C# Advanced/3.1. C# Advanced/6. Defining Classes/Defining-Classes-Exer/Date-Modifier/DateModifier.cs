using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        private int dayDifference;

        public int DayDifference
        {
            get { return this.dayDifference; }
        }

        public void CalculateDayDifference(string firstDateString, string secondDateString)
        {
            DateTime firstDate = DateTime.ParseExact(firstDateString, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact(secondDateString, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
            TimeSpan timeSpan = firstDate > secondDate ? firstDate - secondDate : secondDate - firstDate;
            this.dayDifference = timeSpan.Days;
        }
    }
}
