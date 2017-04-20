using System;

namespace ToDoListe
{
    public abstract class Task
    {
        public string Taskname { get; }
        protected Datum datum;

        public Task Next
        {
            get;
            set;
        }

        protected Task(string name, string datum)
        {
            Taskname = name;
            this.datum = new Datum(datum);
        }
    }
}