using System;
using System.Data.OleDb;

namespace ToDoListe
{
    public class ToDoList
    {
        Task First = null;

        public void AddSorted(Task taskToAdd)
        {
            // TODO
        }

        public void PrintList()
        {
            Task task = First;
            if (!ReferenceEquals(task, null))
            {
                Console.WriteLine(task.ToString());
                task = task.Next;
            }
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