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
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.Pub, opt => opt.MapFrom(src => src.Pub.PublisherName));
            CreateMap<CreateUpdateBookDTO, Book>();
            CreateMap<Book, CreateUpdateBookDTO>();
        }
    }
}
