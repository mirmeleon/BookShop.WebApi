using System.Collections.Generic;
using BookShopSytem.Models.BindingModels.Books;
using BookShopSytem.Models.ViewModels.Books;

namespace BookShopSystem.Services
{
    public interface IBooksService
    {
        BookByIdVm GetBook(int id);
        IEnumerable<BookByTitleVm> SearchForWord(string word);
        void EditBook(int id, EditBookBm editBookBm);
        void Delete(int id);
        bool HasThisBook(int id);
        bool CheckForAuthor(AddBookBm addBookBm);
        void AddBook(AddBookBm addBookBm);
    }
}