using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using BookShopSystem.Services;
using BookShopSytem.Models.BindingModels;
using BookShopSytem.Models.ViewModels;

namespace BookShopSystem.WebApi.Controllers
{
    [RoutePrefix("api/authors")]
    public class AuthorsController : ApiController
    {
        private IAuthorsService service;

        public AuthorsController(IAuthorsService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {

            AuthorViewModel authorVm = this.service.FindAuthor(id);
            if (authorVm != null)
            {
               return this.Ok(authorVm);
            }

            return this.NotFound();
        }

        [HttpPost]
        [Route]
        public IHttpActionResult Post(CreateAuthorBm authorBm)
        {
            if (this.ModelState.IsValid)
            {
                this.service.CreateAuthor(authorBm);
                return this.StatusCode(HttpStatusCode.Created);
            }
            return this.BadRequest(this.ModelState);
        }

      
        [HttpGet]
        [Route("{id:int}/books")]
        public IHttpActionResult Books(int id)
        {
            IEnumerable<BookByAuthorId> booksByAuthorId = this.service.FindBooks(id);

            if (booksByAuthorId == null)
            {
                
                return this.StatusCode(HttpStatusCode.NoContent);
            }

            return this.Ok(booksByAuthorId);
        }

    }
}
