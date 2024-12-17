using System;

using System.Collections.Generic;

using System.IO;



namespace TaskManager

{

    class Program

    {

        static List<string> tasks = new List<string>();



        static void Main(string[] args)

        {

            LoadTasks();

            while (true)

            {

                Console.Clear();

                Console.WriteLine("Task Manager");

                Console.WriteLine("1. Add Task");

                Console.WriteLine("2. View Tasks");

                Console.WriteLine("3. Delete Task");

                Console.WriteLine("4. Exit");

                Console.Write("Select an option: ");



                string choice = Console.ReadLine();



                switch (choice)

                {

                    case "1":

                        AddTask();

                        break;

                    case "2":

                        ViewTasks();

                        break;

                    case "3":

                        DeleteTask();

                        break;

                    case "4":

                        SaveTasks();

                        return;

                    default:

                        Console.WriteLine("Invalid option. Please try again.");

                        break;

                }

            }

        }



        static void AddTask()

        {

            Console.Write("Enter the task description: ");

            string task = Console.ReadLine();

            tasks.Add(task);

            Console.WriteLine("Task added! Press any key to continue...");

            Console.ReadKey();

        }



        static void ViewTasks()

        {

            Console.WriteLine("Tasks:");

            if (tasks.Count == 0)

            {

                Console.WriteLine("No tasks available.");

            }

            else

            {

                for (int i = 0; i < tasks.Count; i++)

                {

                    Console.WriteLine($"{i + 1}. {tasks[i]}");

                }

            }

            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();

        }



        static void DeleteTask()

        {

            ViewTasks();

            Console.Write("Enter the task number to delete: ");

            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)

            {

                tasks.RemoveAt(taskNumber - 1);

                Console.WriteLine("Task deleted! Press any key to continue...");

            }

            else

            {

                Console.WriteLine("Invalid task number. Press any key to continue...");

            }

            Console.ReadKey();

        }



        static void LoadTasks()

        {

            if (File.Exists("tasks.txt"))

            {

                tasks = new List<string>(File.ReadAllLines("tasks.txt"));

            }

        }



        static void SaveTasks()

        {

            File.WriteAllLines("tasks.txt", tasks);

        }

    }

}