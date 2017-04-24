using System.Security;

namespace ToDoListe
{
    public class BusinessTask : Task
    {
        public Priority Priority { get; }

        public BusinessTask(string name, string datum, Priority priority) : base(name, datum)
        {
            Priority = priority;
        }

        public BusinessTask Copy()
        {
            return new BusinessTask(Taskname, Datum.ToString(), Priority);
        }

        public override string ToString()
        {
            return $"{base.ToString()} Prio: {Priority}";
        }
    }
}