using System;
using System.Data.SqlClient;

namespace ToDoListe
{
    public abstract class Task
    {
        public string Taskname { get; }

        public Datum Datum { get; set; }

        public Task Previous { get; set; }

        public Task Next { get; set; }

        protected Task(string name, string datum)
        {
            Taskname = name;
            Datum = new Datum(datum);
        }

        public override string ToString()
        {
            return $"Task: {Taskname} Zeitpunkt: {Datum.ToString()}";
        }
    }
}