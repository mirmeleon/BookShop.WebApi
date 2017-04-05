using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using AutoMapper;
using BookShopSytem.Models;
using BookShopSytem.Models.BindingModels.Categories;
using BookShopSytem.Models.ViewModels.Categories;

namespace BookShopSystem.Services
{
  public class CategoriesService : Service, ICategoriesService
  {
        public IEnumerable<CategoryVm> GetCategories()
        {
            IEnumerable<Category> categories = this.Context.Categories;
            IEnumerable<CategoryVm> categoriesVms =
                Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryVm>>(categories);

            return categoriesVms;
        }

        public bool GetCategoryById(int id)
        {
            return this.Context.Categories.Find(id) == null;
        }

        public CategoryVm GetCategoryId(int id)
        {
            Category category = this.Context.Categories.Find(id);
            var catVm = Mapper.Map<Category, CategoryVm>(category);
            return catVm;
        }

      

        public void CreateCategoryByName(EditCategoryBm editCategoryBm, int id)
        {
            Category cat = this.Context.Categories.Find(id);
         //  Category catMapped = Mapper.Map<EditCategoryBm, Category>(editCategoryBm);
            cat.Name = editCategoryBm.Name;
           this.Context.Categories.AddOrUpdate(cat);
           this.Context.SaveChanges();
        }

        public bool DeleteCategory(int id)
        {
            if (this.Context.Categories.Find(id) != null)
            {
                Category cat = this.Context.Categories.Find(id);
                this.Context.Categories.Remove(cat);
                this.Context.SaveChanges();
                return true;
            }
            return false;
        }

        public void AddNewCategory(EditCategoryBm addCat)
        {
            if (this.Context.Categories.FirstOrDefault(cat => cat.Name == addCat.Name) == null)
            {
                Category cat = Mapper.Map<EditCategoryBm, Category>(addCat);
                this.Context.Categories.Add(cat);
                this.Context.SaveChanges();
            }
        }
    }
}
