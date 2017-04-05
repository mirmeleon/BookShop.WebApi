using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using BookShopSytem.Models;
using BookShopSytem.Models.BindingModels;
using BookShopSytem.Models.BindingModels.Categories;
using BookShopSytem.Models.ViewModels;
using BookShopSytem.Models.ViewModels.Books;
using BookShopSytem.Models.ViewModels.Categories;

namespace BookShopSystem.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureAutoMapper();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.Indent = true;
        }

        private void ConfigureAutoMapper()
        {
           
            Mapper.Initialize(expression =>
            {
                //view models 
                expression.CreateMap<Author, AuthorViewModel>()
                    .ForMember(dest => dest.BookTitles, o => o.MapFrom(sr => sr.Books.Select(b=>b.Title)));
                expression.CreateMap<Book, BookByAuthorId>()
                    .ForMember(dest => dest.Categories,
                        os => os.MapFrom(sr => sr.Categories.Select(cat => cat.Name)));
                expression.CreateMap<Book, BookByIdVm>()
                .ForMember(des=>des.CategoryName,
                os=>os.MapFrom(cat=>cat.Categories.Select(c=>c.Name)))
                .ForMember(des=>des.AuthorName, 
                os=>os.MapFrom(au=>
                au.Author.FirstName + " "+ au.Author.LastName));
                expression.CreateMap<Book, BookByTitleVm>();
                expression.CreateMap<Category, CategoryVm>();

                //bindings
                expression.CreateMap<CreateAuthorBm, Author>();
                expression.CreateMap<EditCategoryBm, Category>();
            });
        }
    }
}
