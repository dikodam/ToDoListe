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
        /// Fügt das neue Element so ein, dass aktuellere Tasks am Anfang der Liste sind
        /// </summary>
        /// <param name="taskToBeAdded">Task, der neu hinzugefügt wird</param>
        public void AddSorted(Task taskToBeAdded)
        {
            if (first == null)
            {
                first = taskToBeAdded;
            }
            else
            {
                for (Task currentTask = first; currentTask != null; currentTask = currentTask.Next)
                {
                    if (taskToBeAdded.Datum < currentTask.Datum)
                    {
                        InsertBefore(taskToBeAdded, currentTask);

                        // es wird nur an einer Stelle eingefügt, d.h. nach dem Einfügen muss die Liste nicht weiter iteriert werden
                        return;
                    }
                    // falls das neue Element ans Ende der Liste muss:
                    if (currentTask.Next == null)
                    {
                        InsertAfter(taskToBeAdded, currentTask);

                        // auch her gilt: sobald das Element eingefügt ist, ist die Methode beendet
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Fügt den ersten Task hinter den zweiten ein
        /// </summary>
        /// <param name="taskToBeAdded">Der Task der hinzugefügt wird</param>
        /// <param name="afterThis"></param>
        private void InsertAfter(Task taskToBeAdded, Task afterThis)
        {
            taskToBeAdded.Previous = afterThis;
            if (afterThis.Next != null)
            {
                afterThis.Next.Previous = taskToBeAdded;
                taskToBeAdded.Next = afterThis.Next;
            }
            afterThis.Next = taskToBeAdded;
        }

        /// <summary>
        /// Fügt den ersten Task vor den zweiten Task ein
        /// </summary>
        /// <param name="taskToBeAdded">Der Task, der hinzugefügt wird</param>
        /// <param name="beforeThis">Der Task, vor den der taskToBeAdded hinzugefügt wird</param>
        private void InsertBefore(Task taskToBeAdded, Task beforeThis)
        {
            // vor dem 1. element -> taskToBeAdded an den Anfang der Liste
            if (beforeThis.Previous == null)
            {
                first = taskToBeAdded;
            }
            else
            {
                // nur wenn ein beforeThis.Previous existiert:
                taskToBeAdded.Previous = beforeThis.Previous;
                beforeThis.Previous.Next = taskToBeAdded;
            }
            taskToBeAdded.Next = beforeThis;
            beforeThis.Previous = taskToBeAdded;
        }

        public void PrintList()
        {
            if (first == null)
            {
                Console.WriteLine("Leere Liste!");
            }
            else
            {
                for (Task task = first; task != null; task = task.Next)
                {
                    Console.WriteLine(task.ToString());
                }
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
            for (Task curr = first; curr != null; curr = curr.Next)
            {
                if (curr is PrivateTask && curr.Taskname == taskname && (curr as PrivateTask).Location == oldLocation)
                {
                    (curr as PrivateTask).Location = newLocation;
                    return true;
                }
            }
            return false;
        }

        public ToDoList GetBusinessList()
        {
            ToDoList businessList = new ToDoList();
            for (Task currentTask = first; currentTask != null; currentTask = currentTask.Next)
            {
                if (currentTask is BusinessTask)
                {
                    businessList.AddSorted((currentTask as BusinessTask).Copy());
                }
            }
            return businessList;
        }

        public ToDoList GetPrivateList()
        {
            ToDoList privateList = new ToDoList();
            for (Task currentTask = first; currentTask != null; currentTask = currentTask.Next)
            {
                if (currentTask is PrivateTask)
                {
                    // hier darf nicht die Referenz übergebenen werden, da sonst die ursprüngliche Liste in Leidenschaft gezogen wird
                    // die Copy() Methode return eine neue Instanz mit den gleichen Werten, jedoch mit leeren Next und Previous
                    privateList.AddSorted((currentTask as PrivateTask).Copy());
                }
            }
            return privateList;
        }

        public Task Top()
        {
            if (first == null)
            {
                throw new Exception("Liste ist leer!");
            }
            return first;

            // TODO Element entnehmen (löschendes lesen):
//            Task result = first;
//            first = first.Next;
//            return result;
        }
    }
}