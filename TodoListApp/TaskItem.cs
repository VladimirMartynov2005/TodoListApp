using System;

namespace TodoListApp
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }

        public TaskItem(int id, string title)
        {
            Id = id;
            Title = title;
            IsCompleted = false;
            CreatedAt = DateTime.Now;
        }

        public override string ToString()
        {
            string status = IsCompleted ? "[X]" : "[ ]";
            return $"{Id}. {status} {Title} (создано: {CreatedAt.ToShortDateString()})";
        }
    }
}