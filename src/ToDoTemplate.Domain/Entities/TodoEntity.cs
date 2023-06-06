using System.Text.Json.Serialization;
using ToDoTemplate.Domain.Enums;

namespace ToDoTemplate.Domain.Entities
{
    public class TodoEntity : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public Priority PriorityToDo { get; set; } = Priority.None;

        public bool IsDone { get; set; }
        [JsonIgnore]
        public TodoList? todoList { get; set; }

    }
}
