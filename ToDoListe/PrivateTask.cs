namespace ToDoListe
{
    public class PrivateTask : Task
    {
        public string Location { get; set; }

        public PrivateTask(string name, string datum, string location) : base(name, datum)
        {
            Location = location;
        }

        /// <summary>
        /// kopiert den Task und gibt einen neuen mit den gleichen Eigenschaften zurück, AUSSCLIESSLICH Previous und Next
        /// </summary>
        /// <returns></returns>
        public PrivateTask Copy()
        {
            return new PrivateTask(Taskname, Datum.ToString(), Location);
        }

        public override string ToString()
        {
            return $"{base.ToString()} Ort: {Location}";
        }
    }
}