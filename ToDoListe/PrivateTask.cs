namespace ToDoListe
{
    public class PrivateTask : Task
    {
        public string Location { get; set; }

        public PrivateTask(string name, string datum, string location) : base(name, datum)
        {
            Location = location;
        }
    }
}