using AutoMapper;
using Directionary.Model.Models;
using Directionary.Web.Models;

namespace Directionary.Web.Mappings
{
    public class AutoMapperConfigurtaion
    {
        public static void Configure()
        {
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<PostCategory, PostCategoryViewModel>();
            Mapper.CreateMap<Tag, TagViewModel>();
        }
    }
}