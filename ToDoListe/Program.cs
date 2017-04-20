using System;

namespace ToDoListe
{
    class Program
    {
        public static void Main(string[] args)
        {
            ToDoList allMyTasks = new ToDoList();
            allMyTasks.AddSorted(new BusinessTask("Besprechung", "2.5.2017", Priority.high));
            allMyTasks.AddSorted(new PrivateTask("Stammtisch", "24.5.2017", "Eckkneipe"));
            allMyTasks.AddSorted(new BusinessTask("Mitarbeitergespräch", "10.5.2017",
                Priority.normal));
            allMyTasks.AddSorted(new PrivateTask("Sport", "12.5.2017", "Turnhalle"));
            allMyTasks.AddSorted(new BusinessTask("Abteilungsversammlung", "12.6.2017",
                Priority.low));
            allMyTasks.AddSorted(new PrivateTask("Kino", "6.5.2017", "Nürnberg"));
            allMyTasks.PrintList();
            if (allMyTasks.ChangeLocation("Kino", "Nürnberg", "Erlangen"))
            {
                Console.WriteLine("Ort geändert");
            }
            else
            {
                Console.WriteLine("Ort nicht gefunden");
            }
            Console.WriteLine("Geschäftstermine:");
            ToDoList businessList = allMyTasks.GetBusinessList();
            businessList.PrintList();
            Console.WriteLine("Private Termine:");
            ToDoList privateList = allMyTasks.GetPrivateList();
            privateList.PrintList();
            Console.WriteLine($"nächster privater Termin: {privateList.Top().ToString()}");
            Console.WriteLine($"nächster Geschäftstermin: {businessList.Top().ToString()}");
        }

    }
}