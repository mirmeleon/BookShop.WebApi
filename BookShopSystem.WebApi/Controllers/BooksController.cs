using System.Net;
using System.Web.Http;
using BookShopSystem.Services;
using BookShopSytem.Models.BindingModels.Books;
using BookShopSytem.Models.ViewModels.Books;

namespace BookShopSystem.WebApi.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private IBooksService service;

        public BooksController(IBooksService service)
        {
            this.service = service;
        }

     
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            BookByIdVm bookVm = this.service.GetBook(id);
            if (bookVm == null)
            {
                return this.StatusCode(HttpStatusCode.NoContent);
            }

            return this.Ok(bookVm);
        }
       
        [HttpGet]
        [Route]
        public IHttpActionResult Get(string word)
        {
            if (word == null)
            {
                return this.NotFound();
            }
       
                var bookVm = this.service.SearchForWord(word);
                return this.Ok(bookVm);
        
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Edit(EditBookBm editBookBm, int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
                
            }

            this.service.EditBook(id, editBookBm);

            return this.Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            if (!this.service.HasThisBook(id))
            {
                return this.NotFound();
            }
            
            this.service.Delete(id);
            return this.StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [Route()]
        public IHttpActionResult Post(AddBookBm addBookBm)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            if (this.service.CheckForAuthor(addBookBm))
            {
                return this.BadRequest("no author found");
            }

            this.service.AddBook(addBookBm);
            return this.Ok("Suxxesfully added!");
        }
    }

}
