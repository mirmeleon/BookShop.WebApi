using System;

namespace BookShopSytem.Models.BindingModels.Books
{
  public class AddBookBm
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public EditionType EditionType { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public string AuthorFirstName { get; set; }

        public string CategoryNames { get; set; }
    }
}
