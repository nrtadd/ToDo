namespace ToDoTemplate.Domain.Entities
{
    public class TodoList : BaseEntity
    {
        public string? Title { get; set; }
        public List<TodoEntity> Todos { get; set; } = new List<TodoEntity>();
    }
}
