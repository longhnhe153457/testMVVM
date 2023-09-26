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
    public class BookAuthorMapper : Profile
    {
        public BookAuthorMapper()
        {
            CreateMap<BookAuthor, BookAuthorDTO>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.FullName))
                .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book.Title));
            CreateMap<CreateUpdateBookAuthorDTO, BookAuthor>();
            CreateMap<BookAuthor, CreateUpdateBookAuthorDTO>();

        }
    }
}
