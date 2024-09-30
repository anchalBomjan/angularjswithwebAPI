using AutoMapper;
using TodoList.Data;
using TodoList.Interface;

namespace TodoList.Mappings
{
    public class AutoMapperProfile : Profile
    {

       
            public AutoMapperProfile()
            {

                CreateMap<ITodo, ToDoRepository>();
            }
        
    }
}
