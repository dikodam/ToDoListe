using System;
using System.Data.OleDb;
using System.Diagnostics.Eventing.Reader;

namespace ToDoListe
{
    public class ToDoList
    {
        Task first = null;

        /// <summary>
        /// Fügt das neue Element so ein, dass jüngere Ereignisse näher am Anfang der Liste sind
        /// </summary>
        /// <param name="taskToAdd"></param>
        public void AddSorted(Task taskToAdd)
        {
            if (ReferenceEquals(first, null))
            {
                first = taskToAdd;
            }
            else if (taskToAdd.Datum > first.Datum)
            {
                taskToAdd.Next = first;
                first = taskToAdd;
            }
            else
            {
            // TODO
            }
        }

        public void PrintList()
        {
            Task task = first;
            while (!ReferenceEquals(task, null))
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
            if (ReferenceEquals(first, null))
            {
                throw new Exception("Liste ist leer!");
            }
            Task result = first;
            first = first.Next;
            return result;
        }
    }
}