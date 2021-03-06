﻿using System;

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
        ///  ein ist größeres Datum ist ein Datum, das weiter in der Zukunft liegt
        /// </summary>
        /// <param name="d1">erstes zu vergleichendes Datum</param>
        /// <param name="d2">zweites zu vergleichendes Datum</param>
        /// <returns>true, wenn d1 ein älteres Datum ist als d2</returns>
        public static bool operator >(Datum d1, Datum d2)
        {
            return !(d1 < d2);
        }

        /// <summary>
        ///  ein Datum, das näher in der Zukunft liegt, ist kleiner
        /// </summary>
        /// <param name="d1">erstes zu vergleichendes Datum</param>
        /// <param name="d2">zweites zu vergleichendes Datum</param>
        /// <returns>true, wenn d1 ein neueres Datum ist als d2</returns>
        public static bool operator <(Datum d1, Datum d2)
        {
            if (d1.year < d2.year)
            {
                return true;
            }
            if (d1.year > d2.year)
            {
                return false;
            }
            // d1.year == d2.year
            if (d1.month < d2.month)
            {
                return true;
            }
            if (d1.month > d2.month)
            {
                return false;
            }
            // d1.month == d2.month
            if (d1.day < d2.day)
            {
                return true;
            }
            // wenn der Tag später oder gleich ist, wird das zweite Datum als das spätere betrachtet
            else return false;
        }

        public override string ToString()
        {
            return $"{day:D2}.{month:D2}.{year:D4}";
        }
    }
}