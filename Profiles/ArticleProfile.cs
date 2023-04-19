using AutoMapper;
using Conduit1.Dtos;
using Conduit1.Models;

namespace Conduit1.dd
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleCreateDto,Article>();


        }
    }
}
