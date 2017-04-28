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

        /// <summary>
        /// kopiert den Task und gibt einen neuen mit den gleichen Eigenschaften zurück, AUSSCLIESSLICH Previous und Next
        /// </summary>
        /// <returns></returns>
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