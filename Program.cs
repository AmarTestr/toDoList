
using System;
using TaskManagementSystem;

class Program
{
    public static void Main(string[] args)
    {
        TaskManager manager = new TaskManager();

        while (true)
        {
            Console.WriteLine("\nTask System");
            Console.WriteLine("1. Add Work Task");
            Console.WriteLine("2. Add Personal Task");
            Console.WriteLine("3. View Tasks");
            Console.WriteLine("4. Complete Task");
            Console.WriteLine("5. Delete Task");
            Console.WriteLine("6. Filter Tasks");
            Console.WriteLine("7. Save file");
            Console.WriteLine("8. Exit");
            Console.Write("Enter choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Title: ");
                    string wtitle = Console.ReadLine();

                    Console.Write("Priority (Low/Medium/High): ");
                    string workinput = Console.ReadLine();
                    if (Enum.TryParse<TaskPriority>(workinput, true, out TaskPriority wpriority) || !Enum.IsDefined(typeof(TaskPriority), wpriority))
                    {
                        Console.WriteLine("Valid priority: " + wpriority);

                    }
                    else
                    {
                        Console.WriteLine("Outside the provided values");
                    }
                    Console.Write("Work Project Name: ");
                    string project = Console.ReadLine();

                    manager.AddTask(
                        new WorkTask(wtitle, wpriority, project));
                    break;

                case "2":
                    Console.Write("Title: ");
                    string ptitle = Console.ReadLine();

                    Console.Write("Priority (Low/Medium/High): ");
                    string personalinput = Console.ReadLine();
                    if (Enum.TryParse<TaskPriority>(personalinput, true, out TaskPriority ppriority) || !Enum.IsDefined(typeof(TaskPriority), ppriority))
                    {
                        Console.WriteLine("Valid priority: " + ppriority);

                    }
                    else
                    {
                        Console.WriteLine("Outside the provided values");
                    }

                    Console.Write("Personal Project Location: ");
                    string location = Console.ReadLine();

                    manager.AddTask(
                        new PersonalTask(ptitle, ppriority, location));
                    break;

                case "3":
                    manager.ViewTasks();
                    break;

                case "4":
                    Console.Write("Enter title: ");
                    manager.CompleteTask(Console.ReadLine());
                    break;

                case "5":
                    Console.Write("Enter title: ");
                    manager.DeleteTask(Console.ReadLine());
                    break;

                case "6":
                    Console.Write("Priority (Low/Medium/High): ");
                    TaskPriority fp =
                        Enum.Parse<TaskPriority>(Console.ReadLine(), true);

                    manager.FilterByPriority(fp);
                    break;
                case "7":
                    manager.SaveFiles();
                    break;

                case "8":
                    return;
            }
        }
    }
}
