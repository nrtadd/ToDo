using AutoMapper;
using ToDoTemplate.Application.Common.Mapping;
using ToDoTemplate.Domain.Entities;
using ToDoTemplate.Domain.Enums;

namespace ToDoTemplate.Application.TodoEntities.Queries.Common
{
    public class GetTodoEntityVm : IMap<TodoEntity>
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string PiorityToDo { get; set; }
        public bool IsDone { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoEntity, GetTodoEntityVm>()
                .ForMember(vm => vm.PiorityToDo, en => en.MapFrom(s => s.PriorityToDo))
                .ForMember(vm => vm.Id, en => en.MapFrom(s => s.Id))
                .ForMember(vm => vm.CreationDate, en => en.MapFrom(s => s.CreationDate))
                .ForMember(vm => vm.EditDate, en => en.MapFrom(s => s.EditDate))
                .ForMember(vm => vm.IsDone, en => en.MapFrom(s => s.IsDone))
                .ForMember(vm => vm.Description, en => en.MapFrom(s => s.Description))
                .ForMember(vm => vm.Title, en => en.MapFrom(s => s.Title));

        }
    }
}
