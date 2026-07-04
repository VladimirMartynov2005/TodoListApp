using System;
using System.Collections.Generic;
using System.Linq;

namespace TodoListApp
{
    public class TodoList
    {
        private List<TaskItem> _tasks = new List<TaskItem>();
        private int _nextId = 1;

        public void AddTask(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine(" Название задачи не может быть пустым!");
                return;
            }

            var task = new TaskItem(_nextId++, title);
            _tasks.Add(task);
            Console.WriteLine($" Задача \"{title}\" добавлена (ID: {task.Id})");
        }

        public void ShowAllTasks()
        {
            if (_tasks.Count == 0)
            {
                Console.WriteLine(" Список задач пуст.");
                return;
            }

            Console.WriteLine("\n=== ВСЕ ЗАДАЧИ ===");
            foreach (var task in _tasks)
            {
                Console.WriteLine(task);
            }
            Console.WriteLine($"Всего задач: {_tasks.Count}");
        }

        public void MarkAsCompleted(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                Console.WriteLine($" Задача с ID {id} не найдена!");
                return;
            }

            if (task.IsCompleted)
            {
                Console.WriteLine($" Задача \"{task.Title}\" уже выполнена.");
                return;
            }

            task.IsCompleted = true;
            Console.WriteLine($" Задача \"{task.Title}\" отмечена как выполненная!");
        }

        public void DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                Console.WriteLine($" Задача с ID {id} не найдена!");
                return;
            }

            _tasks.Remove(task);
            Console.WriteLine($" Задача \"{task.Title}\" удалена.");
        }

        public void ShowStats()
        {
            int total = _tasks.Count;
            int completed = _tasks.Count(t => t.IsCompleted);
            int pending = total - completed;

            Console.WriteLine("\n=== СТАТИСТИКА ===");
            Console.WriteLine($" Всего: {total}");
            Console.WriteLine($" Выполнено: {completed}");
            Console.WriteLine($" Ожидает: {pending}");
        }

        // Доп. функция: показать только выполненные задачи
        public void ShowCompletedTasks()
        {
            var completed = _tasks.Where(t => t.IsCompleted).ToList();
            if (completed.Count == 0)
            {
                Console.WriteLine(" Нет выполненных задач.");
                return;
            }

            Console.WriteLine("\n=== ВЫПОЛНЕННЫЕ ЗАДАЧИ ===");
            foreach (var task in completed)
                Console.WriteLine(task);
        }

        // Доп. функция: показать только активные задачи
        public void ShowPendingTasks()
        {
            var pending = _tasks.Where(t => !t.IsCompleted).ToList();
            if (pending.Count == 0)
            {
                Console.WriteLine(" Все задачи выполнены!");
                return;
            }

            Console.WriteLine("\n=== АКТИВНЫЕ ЗАДАЧИ ===");
            foreach (var task in pending)
                Console.WriteLine(task);
        }
    }
}