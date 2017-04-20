using System;

namespace ToDoListe
{
    public abstract class Task
    {
        public string Taskname { get; }
        protected string datum;

        protected Task(string name, string datum)
        {
            Taskname = name;
            this.datum = datum;
        }
    }
}