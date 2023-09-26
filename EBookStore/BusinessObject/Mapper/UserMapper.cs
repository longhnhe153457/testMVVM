using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.RoleDesc))
                .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Pub.PublisherName));
            CreateMap<CreateUpdateUserDTO, User>();
            CreateMap<User, CreateUpdateUserDTO>();
        }
    }
}
