using AutoMapper;
using ToDoTemplate.Application.Common.Mapping;
using ToDoTemplate.Domain.Entities;

namespace ToDoTemplate.Application.TodoLists.Queries.Common
{
    public class GetTodoListVm : IMap<TodoList>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public IList<TodoEntity>? Todos { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoList, GetTodoListVm>()
                 .ForMember(vm => vm.Id, en => en.MapFrom(s => s.Id))
                .ForMember(vm => vm.Title, en => en.MapFrom(s => s.Title))
                .ForMember(vm => vm.CreationDate, en => en.MapFrom(s => s.CreationDate))
                .ForMember(vm => vm.EditDate, en => en.MapFrom(s => s.EditDate))
                .ForMember(vm => vm.Todos, en => en.MapFrom(s => s.Todos));
        }

    }
}
