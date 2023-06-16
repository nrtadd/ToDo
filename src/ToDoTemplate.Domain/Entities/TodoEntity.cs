using System.Text.Json.Serialization;
using ToDoTemplate.Domain.Enums;

namespace ToDoTemplate.Domain.Entities
{
    public class TodoEntity : BaseEntity
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Title { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string? Description { get; set; }
        public Priority PriorityToDo { get; set; } = Priority.None;

        public bool IsDone { get; set; }
        [JsonIgnore]
        public TodoList? todoList { get; set; }

    }
}
