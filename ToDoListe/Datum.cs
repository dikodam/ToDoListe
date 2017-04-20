using System;

namespace ToDoListe
{
    public class Datum
    {
        private int day;
        private int month;
        private int year;

        public Datum(string datum)
        {
            string[] datumSplit = datum.Split('.');


            if (datumSplit.Length != 3)
            {
                throw new ArgumentException("Falsches Datumsformat");
            }

            day = Convert.ToInt32(datumSplit[0]);
            month = Convert.ToInt32(datumSplit[1]);
            year = Convert.ToInt32(datumSplit[2]);
        }

        /// <summary>
        ///  ein jüngeres Datum ist größer als ein älteres Datum
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static bool operator >(Datum d1, Datum d2)
        {
            // 12.03.2017 > 12.03.2016
            if (d1.year > d2.year)
            {
                return true;
            }
            // 12.05.2000 > 12.03.2000
            if (d1.month > d2.month)
            {
                return true;
            }
            // 02.01.2000 > 01.01.2000
            if (d1.day > d2.day)
            {
                return true;
            }
            return false;
        }

        public static bool operator <(Datum d1, Datum d2)
        {
            return !(d1 > d2);
        }

        public override string ToString()
        {
            return $"{day:D2}.{month:D2}.{year:D4}";
        }
    }
}