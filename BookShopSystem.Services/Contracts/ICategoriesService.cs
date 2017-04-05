using System.Collections.Generic;
using BookShopSytem.Models.BindingModels.Categories;
using BookShopSytem.Models.ViewModels.Categories;

namespace BookShopSystem.Services
{
    public interface ICategoriesService
    {
        IEnumerable<CategoryVm> GetCategories();
        bool GetCategoryById(int id);
        CategoryVm GetCategoryId(int id);
        void CreateCategoryByName(EditCategoryBm editCategoryBm, int id);
        bool DeleteCategory(int id);
        void AddNewCategory(EditCategoryBm addCat);
    }
}