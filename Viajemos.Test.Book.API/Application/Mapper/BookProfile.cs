using AutoMapper;
using Viajemos.Test.Book.API.Application.Models;
using BookDomain = Viajemos.Test.Book.Domain.Book;
using System.Linq;

namespace Viajemos.Test.Book.API.Application.Mapper
{
    public class BookProfile: Profile
    {
        public BookProfile()
        {
            CreateMap<BookDomain, BookModel>(MemberList.Destination)
                .ForMember(dest => dest.ISBN, or => or.MapFrom(it => it.ISBN))
                .ForMember(dest => dest.Title, or => or.MapFrom(it => it.Title))
                .ForMember(dest => dest.Sypnosis, or => or.MapFrom(it => it.Sypnosis))
                .ForMember(dest => dest.NumberPages, or => or.MapFrom(it => it.NumberPages))
                .ForPath(dest => dest.Editorial.Id, or => or.MapFrom(it => it.Editorial.Id))
                .ForPath(dest => dest.Editorial.Name, or => or.MapFrom(it => it.Editorial.Name))
                .ForPath(dest => dest.Editorial.Campus, or => or.MapFrom(it => it.Editorial.Campus))
                .ForPath(dest => dest.Authors, or => or.MapFrom(it => it.AuthorsHasBooks.Select(it => it.Author)));
        }
    }
}
