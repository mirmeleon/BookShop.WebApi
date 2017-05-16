using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using BookShopSystem.Services;
using BookShopSytem.Models.BindingModels.Categories;
using BookShopSytem.Models.ViewModels.Categories;

namespace BookShopSystem.WebApi.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        private ICategoriesService service;

        public CategoriesController()
        {
            this.service = new CategoriesService();
        }

        [HttpGet]
        [Route]
        public IHttpActionResult Get()
        {
            if (this.service.GetCategories() == null)
            {
                return this.NotFound();
            }

            IEnumerable<CategoryVm> cats = this.service.GetCategories();
            return this.Ok(cats);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            if (this.service.GetCategoryById(id))
            {
                return this.NotFound();
            }

            CategoryVm catVm = this.service.GetCategoryId(id);
            return this.Ok(catVm);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Edit( EditCategoryBm editCatBm, int id)
        {
            
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

             this.service.CreateCategoryByName(editCatBm, id);
            return this.Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            if (this.service.DeleteCategory(id))
            {
                return this.StatusCode(HttpStatusCode.OK);
            }

            return this.NotFound();

        }

        [HttpPost]
        [Route]
        public IHttpActionResult Post(EditCategoryBm editCat)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            this.service.AddNewCategory(editCat);
            return this.Ok();

        }
    }
}
