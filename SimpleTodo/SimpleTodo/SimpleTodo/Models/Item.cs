using System;

namespace SimpleTodo.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        public DateTimeOffset DueDate { get; set; }
    }
}