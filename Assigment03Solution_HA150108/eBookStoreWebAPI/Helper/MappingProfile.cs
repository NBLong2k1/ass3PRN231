using AutoMapper;
using BusinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStoreWebAPI.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Author, AuthorDTO>();
            CreateMap<Book, BookDTO>();
            CreateMap<BookAuthor, BookAuthorDTO>();
            CreateMap<Publisher, PublisherDTO>();
            CreateMap<Role, RoleDTO>();
            CreateMap<User, UserDTO>();


            CreateMap<AuthorDTO, Author>();
            CreateMap<BookDTO, Book>();
            CreateMap<BookAuthorDTO, BookAuthor>();
            CreateMap<PublisherDTO, Publisher>();
            CreateMap<RoleDTO, Role>();
            CreateMap<UserDTO, User>();


        }
            
    }
}
