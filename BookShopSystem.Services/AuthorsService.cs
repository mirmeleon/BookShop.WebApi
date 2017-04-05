using System.Collections.Generic;
using AutoMapper;
using BookShopSytem.Models;
using BookShopSytem.Models.BindingModels;
using BookShopSytem.Models.ViewModels;

namespace BookShopSystem.Services
{
  public class AuthorsService : Service, IAuthorsService
  {
        public AuthorViewModel FindAuthor(int id)
        {
            Author author = this.Context.Authors.Find(id);
            AuthorViewModel authorVm = Mapper.Map<Author, AuthorViewModel>(author);

            return authorVm;
        }

        public void CreateAuthor(CreateAuthorBm authorBm)
        {
            Author author = Mapper.Map<CreateAuthorBm, Author>(authorBm);
            this.Context.Authors.Add(author);
            this.Context.SaveChanges();

        }

        public IEnumerable<BookByAuthorId> FindBooks(int id)
        {
            if (this.Context.Authors.Find(id) == null)
            {
                return null;
            }
            else
            {
                IEnumerable<Book> books = this.Context.Authors.Find(id).Books;

                IEnumerable<BookByAuthorId> mappedBooks = Mapper.Map<IEnumerable<Book>, IEnumerable<BookByAuthorId>>(books);

                return mappedBooks;
            }
       
        }
    }
}
