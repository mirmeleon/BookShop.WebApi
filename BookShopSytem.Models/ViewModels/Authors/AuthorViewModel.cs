using System.Collections.Generic;

namespace BookShopSytem.Models.ViewModels
{
  public class AuthorViewModel
    {
       
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<string> BookTitles { get; set; }
    }
}
