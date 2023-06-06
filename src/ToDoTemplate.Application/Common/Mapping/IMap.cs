using AutoMapper;

namespace ToDoTemplate.Application.Common.Mapping
{
    public interface IMap<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
