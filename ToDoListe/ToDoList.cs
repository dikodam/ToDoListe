using System.Data.OleDb;

namespace ToDoListe
{
    public class ToDoList
    {
        public void AddSorted(Task taskToAdd)
        {
            // TODO
        }

        public void PrintList()
        {
            // TODO
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="taskname"></param>
        /// <param name="oldName"></param>
        /// <param name="newName"></param>
        /// <returns>true wenn Änderung vorgenommen, false wenn Element nicht gefunden </returns>
        public bool ChangeLocation(string taskname, string oldName, string newName)
        {
            // TODO
            return false;
        }

        public ToDoList GetBusinessList()
        {
            // TODO
            return null;
        }

        public ToDoList GetPrivateList()
        {
            // TODO
            return null;
        }

        public Task Top()
        {
            // TODO
            return null;
        }

        public override string ToString()
        {
            // TODO
            return base.ToString();
        }
    }
}