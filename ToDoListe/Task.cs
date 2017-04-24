using System;

namespace ToDoListe
{
    public abstract class Task
    {
        public string Taskname { get; }

        public Datum Datum { get; set; }

        public Task Next { get; set; }

        protected Task(string name, string datum)
        {
            Taskname = name;
            Datum = new Datum(datum);
        }
    }
}