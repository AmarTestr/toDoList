using System;
using TaskManagementSystem;
namespace Test
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("enter the task");
            TaskPriority task = TaskPriority.Low;
            //Console.WriteLine(task);
           while (true)
            {

            
            Console.WriteLine("\n1.Add Task");
            Console.WriteLine("2.View Task");
            Console.WriteLine("3.Complete Task");
            Console.WriteLine("4.Filter Task");
            Console.WriteLine("5.Exit");
            Console.WriteLine("Enter your choice");
            string choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Add the Task");
                        AddTask Task = new AddTask();
                        Task.CreateTask();
                        break;


                    case "2":
                        Console.WriteLine("View Task");
                        ViewTask view = new ViewTask();
                        view.ShowTasks();
                        break;

                    case "3":
                        Console.WriteLine("Complete Task");
                        CompleteTask complete = new CompleteTask();
                        complete.Completed();
                        break;

                    case "4":
                        Console.WriteLine("Filter Task");
                        FilterTask filter = new FilterTask();
                        filter.Filter();
                        break;
                    case "5":
                        Console.WriteLine("Exiting");
                        return;

                }
            }
        }
    }

}
