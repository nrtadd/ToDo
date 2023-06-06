using AutoMapper;
using System.Reflection;

namespace ToDoTemplate.Application.Common.Mapping
{
    public class AssemblyMap : Profile
    {
        public AssemblyMap(Assembly assembly)
        {
            MappingAssembly(assembly);
        }

        private void MappingAssembly(Assembly assembly)
        {
            var maps = assembly.GetExportedTypes()
                 .Where(x => x.GetInterfaces()
                 .Any(c => c.IsGenericType && c.GetGenericTypeDefinition() == typeof(IMap<>))).ToList();
            foreach (var item in maps)
            {
                var instance = Activator.CreateInstance(item);
                var method = item.GetMethod("Mapping");
                method?.Invoke(instance, new object[] { this });
            }
        }
    }
}
