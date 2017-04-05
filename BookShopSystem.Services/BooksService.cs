using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using AutoMapper;
using BookShopSytem.Models;
using BookShopSytem.Models.BindingModels.Books;
using BookShopSytem.Models.ViewModels.Books;

namespace BookShopSystem.Services
{
   public class BooksService : Service, IBooksService
   {
        public BookByIdVm GetBook(int id)
        {
            if (this.Context.Books.Find(id) != null)
            {
                Book book = this.Context.Books.Find(id);
                BookByIdVm mapped = Mapper.Map<Book, BookByIdVm>(book);
                return mapped;
            }
            return null;
        }

        public IEnumerable<BookByTitleVm> SearchForWord(string word)
        {

          
          IEnumerable<Book> books = this.Context.Books.Where(t => t.Title.Contains(word)).Take(10).OrderBy(b=>b.Title);
          IEnumerable<BookByTitleVm> mapped = Mapper.Map<IEnumerable<Book>, IEnumerable<BookByTitleVm>>(books);

            return mapped;
        }

        public void EditBook(int id, EditBookBm editBookBm)
        {
            Book book = this.Context.Books.Find(id);
       
            Author author = this.Context.Authors.Find(editBookBm.AuthorId);
            book.Author = author;
            book.Title = editBookBm.Title;
            book.AgeRestriction = editBookBm.AgeRestriction;
            book.Copies = editBookBm.Copies;
            book.Description = editBookBm.Description;
            book.EditionType = editBookBm.EditionType;
            book.ReleaseDate = editBookBm.ReleaseDate;
            book.Price = editBookBm.Price;
            
            this.Context.Books.AddOrUpdate(book);
            this.Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Book book = this.Context.Books.Find(id);
                this.Context.Books.Remove(book);
                this.Context.SaveChanges();
      
        }

        public bool HasThisBook(int id)
        {
            return this.Context.Books.Find(id) != null;
        }

        public bool CheckForAuthor(AddBookBm addBookBm)
        {
            return this.Context.Authors.FirstOrDefault(a => a.FirstName == addBookBm.AuthorFirstName) == null;
        }

        public void AddBook(AddBookBm addBookBm)
        {
            Author author = this.Context.Authors.FirstOrDefault(a => a.FirstName == addBookBm.AuthorFirstName);
        

           
                Book book = new Book();
                book.Author = author;
                book.AgeRestriction = addBookBm.AgeRestriction;
                var cats = addBookBm.CategoryNames.Split(' ');

                foreach (var cat in cats)
                {
                    book.Categories.Add(new Category()
                    {
                        Name = cat,
                        Books = new List<Book>()
                        {
                           book
                        }
                    });
                }

                book.Copies = addBookBm.Copies;
                book.Description = addBookBm.Description;
                book.EditionType = addBookBm.EditionType;
                book.Price = addBookBm.Price;
                book.ReleaseDate = addBookBm.ReleaseDate;
                book.Title = addBookBm.Title;

                this.Context.Books.Add(book);
                this.Context.SaveChanges();
         
           
        }
    }
}
