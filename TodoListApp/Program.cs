using System;

namespace TodoListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "TodoList Console App";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=====================================");
            Console.WriteLine("   ДОБРО ПОЖАЛОВАТЬ В TODO LIST!");
            Console.WriteLine("=====================================");
            Console.ResetColor();

            var todo = new TodoList();
            bool isRunning = true;

            while (isRunning)
            {
                ShowMenu();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Введите название задачи: ");
                        string title = Console.ReadLine();
                        todo.AddTask(title);
                        break;

                    case "2":
                        todo.ShowAllTasks();
                        break;

                    case "3":
                        Console.Write("Введите ID задачи для отметки как выполненной: ");
                        if (int.TryParse(Console.ReadLine(), out int completeId))
                            todo.MarkAsCompleted(completeId);
                        else
                            Console.WriteLine(" Некорректный ID!");
                        break;

                    case "4":
                        Console.Write("Введите ID задачи для удаления: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                            todo.DeleteTask(deleteId);
                        else
                            Console.WriteLine(" Некорректный ID!");
                        break;

                    case "5":
                        todo.ShowStats();
                        break;

                    case "6":
                        todo.ShowPendingTasks();
                        break;

                    case "7":
                        todo.ShowCompletedTasks();
                        break;

                    case "8":
                        isRunning = false;
                        Console.WriteLine(" До свидания! Спасибо за использование TodoList.");
                        break;

                    default:
                        Console.WriteLine(" Неверный выбор! Пожалуйста, выберите от 1 до 8.");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("============= ГЛАВНОЕ МЕНЮ =============");
            Console.ResetColor();
            Console.WriteLine("1.  Добавить задачу");
            Console.WriteLine("2.  Показать все задачи");
            Console.WriteLine("3.  Отметить задачу как выполненную");
            Console.WriteLine("4.  Удалить задачу");
            Console.WriteLine("5.  Показать статистику");
            Console.WriteLine("6.  Показать активные задачи");
            Console.WriteLine("7.  Показать выполненные задачи");
            Console.WriteLine("8.  Выход");
            Console.Write("Выберите опцию: ");
        }
    }
}