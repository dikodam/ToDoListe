using System;
using System.Data.OleDb;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;

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
        /// Ändert die Location des PrivateTask, der mit Taskname und aktueller Location angegeben wird
        /// </summary>
        /// <param name="taskname">Name des PrivateTask, dessen Location geändert werden soll</param>
        /// <param name="oldLocation">aktueller Name der Location</param>
        /// <param name="newLocation">neuer Name der Location</param>
        /// <returns>true wenn Änderung vorgenommen, false wenn Element nicht gefunden </returns>
        public bool ChangeLocation(string taskname, string oldLocation, string newLocation)
        {
            for(Task currentTask = first; currentTask != null; currentTask = currentTask.Next)
            {
                if (currentTask is PrivateTask && currentTask.Taskname == taskname && (currentTask as PrivateTask).Location == oldLocation)
                {
                    (currentTask as PrivateTask).Location = newLocation;
                    return true;
                }
            }
            return false;
        }

        public ToDoList GetBusinessList()
        {
            ToDoList businessList = new ToDoList();
            Task currentTask = first;
            while (currentTask != null)
            {
                if (currentTask is BusinessTask)
                {
                    businessList.AddSorted(currentTask);
                }
                currentTask = currentTask.Next;
            }
            return businessList;
        }

        public ToDoList GetPrivateList()
        {
            ToDoList privateList = new ToDoList();
            Task currentTask = first;
            while (currentTask != null)
            {
                if (currentTask is PrivateTask)
                {
                    privateList.AddSorted(currentTask);
                }
                currentTask = currentTask.Next;
            }
            return privateList;
        }

        public Task Top()
        {
            if (first == null)
            {
                throw new Exception("Liste ist leer!");
            }
            Task result = first;
            first = first.Next;
            return result;
        }
    }
}