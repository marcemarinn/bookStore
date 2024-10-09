using AutoMapper;
using Core.Entities;
using Core.Request;

namespace Infrastructure.Mapping;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<BookRequest, Book>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
            .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate))
            .ForMember(dest => dest.isActive, opt => opt.MapFrom(src => src.IsActive));



        CreateMap<Book, BookRequest>()
           .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
           .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
           .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate))
           .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.isActive));
           

    }
}
