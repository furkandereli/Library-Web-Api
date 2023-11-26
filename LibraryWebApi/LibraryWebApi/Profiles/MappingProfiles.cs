using AutoMapper;
using LibraryWebApi.Dtos.Requests;
using LibraryWebApi.Dtos.Responses;
using LibraryWebApi.Models;

namespace LibraryWebApi.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateBookRequestDto, Book>().ReverseMap();
            CreateMap<UpdateBookRequestDto, Book>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Publisher, PublisherDto>().ReverseMap();
        }
    }
}
