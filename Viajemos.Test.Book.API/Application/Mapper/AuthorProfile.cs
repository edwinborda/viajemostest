using AutoMapper;
using Viajemos.Test.Book.API.Application.Models;
using Viajemos.Test.Book.Domain;

namespace Viajemos.Test.Book.API.Application.Mapper
{
    public class AuthorProfile: Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorModel>();
        }
    }
}
