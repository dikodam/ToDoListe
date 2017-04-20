namespace ToDoListe
{
    public class PrivateTask : Task
    {
        private string Location { get; }

        public PrivateTask(string name, string datum, string location) : base(name, datum)
        {
            Location = location;
        }
    }
}