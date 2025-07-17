using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
public class Program
{
    // public static object TaskManagerApp { get; private set; }

    public static TaskManager taskManager { get;  set; }

    /// <summary>
    /// The main entry point for the Task Manager application.  
    /// </summary>

    public static void Initialize()
    {
        // Initialization logic for the Task Manager application can go here.
        // This could include setting up services, loading configurations, etc.

        Console.WriteLine("Initializing Task Manager Application...");

        //create a instance of takmanager class.
         taskManager = new TaskManager();
        // You can also initialize the task manager with some predefined tasks if needed.
        // For example, you could load tasks from a file or database.
        Console.WriteLine("Task Manager Application initialized successfully.");
    }

    public static void Run()
    {
        // Logic to run the Task Manager application can go here.
        // This could include starting the main loop, handling user input, etc.

        Initialize(); // Call the initialization method to set up the application.
        // For now, we will just print a welcome message.
        Console.WriteLine("Task Manager Application is running...");
        //Enter a loop to keep the application running.
        do
        {
            // Here you can implement the logic to handle user commands, display tasks, etc.
            // For example, you could prompt the user for input and call the appropriate methods.
            Console.WriteLine("Type 'exit' to quit the application.");
            Console.WriteLine("Available commands: 'list tasks', 'create task', 'delete task', 'mark completed', 'exit'");
            Console.Write("Enter command: ");
            // Read user input and process commands.
            // For simplicity, we will just read a command and print a message.
            string input;
            do
            {
                input = Console.ReadLine()!.ToLower();
            }
            while (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input));
            // Process the input command.
            if (input?.ToLower() == "exit")
            {
                break;
            }
            else if (input?.ToLower() == "list tasks")
            {
                // Call the method to list all tasks.
                ListAllTasks(taskManager.userTasks);
                Console.WriteLine("Listing all tasks...");
            }
            else if (input?.ToLower() == "create task")
            {
                // Call the method to create a new task.
                // For simplicity, we will just prompt the user for task details.
                Console.Write("Enter task ID: ");
                int id;
                while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                {
                    Console.Write("Invalid input. Please enter a valid task ID: ");
                }
                Console.Write("Enter task name: ");
                do
                {
                    input = Console.ReadLine()!;
                } while (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input));
                string name = input;
                Console.Write("Enter task description: ");
                string description = Console.ReadLine()!;
                Console.Write("Enter due date (yyyy-mm-dd): ");
                DateTime dueDate;
                while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
                {
                    Console.Write("Invalid date format. Please enter a valid due date (yyyy-mm-dd): ");
                }
                Console.Write("Enter task priority (Normal, High, Low): ");
                do
                {
                    input = Console.ReadLine()!;
                } while (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input) || 
                         (input.ToLower() != "normal" && input.ToLower() != "high" && input.ToLower() != "low"));
                string priority = input;
                // Create a new task using the provided details.
                UserTask newTask = CreateTask(id, name, false, dueDate, priority, description);
                // Add the new task to the TaskManager's list of tasks.
                taskManager.userTasks.Add(newTask);
                // CreateTask(...);
                Console.WriteLine("Creating a new task...");
            }
            else if (input?.ToLower() == "delete task")
            {
                // Prompt the user for the task ID to delete.
                Console.Write("Enter the task ID to delete: ");
                int id;
                while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                {
                    Console.Write("Invalid input. Please enter a valid task ID: ");
                }
                // Call the method to delete a task.
                DeleteTask(taskManager.userTasks,id);
                Console.WriteLine("Deleting a task...");
            }

            else if (input?.ToLower() == "mark completed")
            {
                // Call the method to mark a task as completed.
                Console.Write("Enter the task ID to mark as completed: ");
                int id;
                while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                {
                    Console.Write("Invalid input. Please enter a valid task ID: ");
                }   
                // Find the task by ID and mark it as completed.
                UserTask taskToComplete = taskManager.userTasks.Find(t => t.taskID == id)!;
                if (taskToComplete == null)
                {
                    Console.WriteLine($"Task with ID {id} not found.");
                    continue;
                }   
                markedAsCompleted(taskToComplete,isCompleted: true);
                Console.WriteLine("Marking a task as completed...");
            }

            else
            {
                Console.WriteLine("Unknown command. Please try again.");
            }
        } while (true);
    }

    /// <summary>
    /// 1.create a class UserTask to represent a task in the Task Manager Application.
    /// The class will have propeties such  as taskID, taskName, taskDescription, isCompleted, dueDate, and priority.
    /// /// The class will also have a constructor to initialize these properties.
    /// 2.create a class to store the collection of tasks as List<UserTask>.
    /// </summary>
    public class UserTask
    {
        public int taskID { get; set; }
        public string taskName { get; set; }
        public Boolean isCompleted { get; set; }
        public DateTime dueDate { get; set; }
        public string? priority { get; set; }
        public string? taskDescription { get; set; }

        public UserTask(int id, string name, bool completed, DateTime due, string description = "", string _priority = "Normal")
        {
            taskID = id;
            taskName = name;
            taskDescription = description;
            isCompleted = completed;
            dueDate = due;
            priority = _priority;
        }
    }

    public class TaskManager
    {
        public List<UserTask> userTasks { get; set; }

        // Constructor to initialize the TaskManager with a list of UserTask objects.
        public TaskManager()
        {
            userTasks = new List<UserTask>();
        }
        public TaskManager(List<UserTask> tasks)
        {
            userTasks = tasks;
        }


    }

    public static void Main(string[] args)
    {

        System.Console.WriteLine("Welcome to the Task Manager Application!");
        Run();

        //initialize an variable with data typr Task
        UserTask task1 = new UserTask(1, "Create a console application", false, DateTime.Now.AddDays(1), "Create a dotnet console application for managing tasks", "High");

        Console.WriteLine($"TaskID:\t\t{task1.taskID}\n" +
                            $"Task:\t\t{task1.taskName}\n" +
                            $"Description:\t{task1.taskDescription}\n" +
                            $"Priority:\t{task1.priority}\n" +
                            $"Status:\t\t{task1.isCompleted}\n" +
                            $"Due Date:\t{task1.dueDate}\n");
        // Console.WriteLine($"TaskID :{task1.taskID} {} {} {} {} {}");

        ///
        /// <summary>
        /// 1.Create a method to create a new task.
        /// This method should take parameters for task details such as ID, name, description, completion
        /// /// status, due date, and priority.
        /// The method should return a new instance of the UserTask class.
        /// 2. Create a method to display task details.
        /// This method should take a UserTask object as a parameter and print its details to the console.
        /// 3. Create a method to mark a task as completed.
        /// This method should take a UserTask object as a parameter and update its completion status.
        /// 4. Create a method to list all tasks.
        /// /// This method should take a list of UserTask objects and print the details of each task to the console.
        /// 5. Create a method to filter tasks by priority.
        /// This method should take a list of UserTask objects and a priority level as parameters,
        /// /// and return a list of tasks that match the specified priority.
        /// /// 6. Create a method to sort tasks by due date.
        /// This method should take a list of UserTask objects and return a sorted list based on 
        /// due date.
        /// /// 7. Create a method to save tasks to a file.
        /// This method should take a list of UserTask objects and save their details to a text file.
        /// 8.Create a method to delete task from the list.
        /// This method should take a list of UserTask objects and a task ID as parameters,
        /// /// and remove the task with the specified ID from the list.
        ///  
        /// </summary>


        // Initialize the TaskManager with an empty list of tasks.
        TaskManager taskManager = new TaskManager();

        // Add the created task to the TaskManager's list of tasks.
        taskManager.userTasks.Add(task1);
        // foreach (UserTask task in taskManager.userTasks)
        // {
        //     Console.WriteLine($"TaskID: {task.taskID}, Task: {task.taskName}, Status: {task.isCompleted}, Due Date: {task.dueDate}");
        // }

        // Display the details of the created task.
        DisplayTask(task1);

        SaveTasksToFile(taskManager.userTasks, "TaskStorage\\tasks.csv");
        Console.WriteLine("Press any key to exit...");
    }


    // Additional methods for task management can be added here.
    //private methods for creating, displaying, updating, deleting tasks, etc.

    // Create a method to create a new task.
    public static UserTask CreateTask(int id, string name, bool completed, DateTime due, string priority = "Normal", string description = "")
    {
        return new UserTask(id, name, completed, due, priority, description);
    }

    // Create a method to display task details. 
    public static void DisplayTask(UserTask task)
    {
        Console.WriteLine($"TaskID: {task.taskID}, Task: {task.taskName}, Description: {task.taskDescription}, " +
                          $"Priority: {task.priority}, Status: {task.isCompleted}, Due Date: {task.dueDate}");
    }

    //Create a method to dealete a task.
    public static void DeleteTask(List<UserTask> tasks, int taskId)
    {
        // Logic to delete a task from the list of tasks.
        UserTask taskToDelete = tasks.Find(t => t.taskID == taskId)!;
        if (taskToDelete != null)
        {
            tasks.Remove(taskToDelete); 
            Console.WriteLine($"Deleting task: {taskToDelete.taskName}");
        }
        else
        {
            Console.WriteLine($"Taskwith ID {taskId} not found.");
        }
    }

    // Create a method to mark a task as completed.
    public static void markedAsCompleted(UserTask task, bool isCompleted)
    {
        // Logic to mark a task as completed can be implemented here.
        // This could involve updating the isCompleted property of a UserTask object.
        task.isCompleted = isCompleted;
        Console.WriteLine($"Task {task.taskName} marked as completed: {task.isCompleted}");
    }

    // Create a method to list all tasks.
    public static void ListAllTasks(List<UserTask> tasks)
    {
        Console.WriteLine("Listing all tasks:");
        foreach (var task in tasks)
        {
            DisplayTask(task);
        }
    }

    // Create a method to filter tasks by priority.
    public static List<UserTask> FilterTasksByPriority(List<UserTask> tasks, string priority)
    {
        List<UserTask> filteredTasks = new List<UserTask>();
        foreach (var task in tasks)
        {
            if (task.priority != null && task.priority.ToLower() == priority.ToLower())
            {
                filteredTasks.Add(task);
            }
        }
        return filteredTasks;
    }

    public static List<UserTask> SortTasksByPriority(List<UserTask> tasks)
    {
        // Create a method to sort tasks by priority.
        // This method should take a list of UserTask objects and return a sorted list based on priority.
        List<UserTask> sortedTasks = new List<UserTask>(tasks);
        sortedTasks.Sort((x, y) => string.Compare(x.priority, y.priority, StringComparison.OrdinalIgnoreCase));
        return sortedTasks;
    }

    // Create a method to sort tasks by due date.
    public static List<UserTask> sortTaskByDueDate(List<UserTask> tasks)
    {

        List<UserTask> sortedTasks = new List<UserTask>(tasks);
        sortedTasks.Sort((x, y) => DateTime.Compare(x.dueDate, y.dueDate));
        return sortedTasks;
    }

    public static List<UserTask> filterTasksByCompletionStatus(List<UserTask> tasks, bool isCompleted)
    {
        List<UserTask> filteredTasks = new List<UserTask>();
        foreach (UserTask task in tasks)
        {
            if (isCompleted == task.isCompleted)

            {
                filteredTasks.Add(task);
            }
        }
        return filteredTasks;
    }

    //Create a method to save tasks to a file 
    public static void SaveTasksToFile(List<UserTask> tasks, string filepath)
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath))
        {
                // TaskID:  Task:  Description " +
                //                $"Priority: {task.priority}, Status: {task.isCompleted}, Due Date: {task.dueDate}");
            file.WriteLine("TaskID,Task,Description,Status,Priority,Status,Due Date");
            // file.WriteLine("TaskID\t|\tTask\t|\tDescription\t|\tStatus\t|\tPriority\t|\tStatus\t|\tDue Date");
            foreach (UserTask task in tasks)
                file.WriteLine($"{task.taskID},{task.taskName},{task.taskDescription},{task.isCompleted},{task.dueDate},{task.priority}");
                // file.WriteLine($"{task.taskID}\t\t|\t{task.taskName}\t|\t{task.taskDescription}\t|\t{task.isCompleted}\t|\t{task.dueDate}\t|\t{task.priority}");
            {
            }
        }

    }
}