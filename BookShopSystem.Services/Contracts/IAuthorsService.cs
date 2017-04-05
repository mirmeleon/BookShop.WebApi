using System.Collections.Generic;
using BookShopSytem.Models.BindingModels;
using BookShopSytem.Models.ViewModels;

namespace BookShopSystem.Services
{
    public interface IAuthorsService
    {
        AuthorViewModel FindAuthor(int id);
        void CreateAuthor(CreateAuthorBm authorBm);
        IEnumerable<BookByAuthorId> FindBooks(int id);
    }
}