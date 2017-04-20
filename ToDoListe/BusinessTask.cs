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
    }
}