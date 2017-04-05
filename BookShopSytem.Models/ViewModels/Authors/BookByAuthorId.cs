using System;
using System.Collections.Generic;

namespace BookShopSytem.Models.ViewModels
{
   public class BookByAuthorId
    {
        public int Id { get; set; }

       
        public string Title { get; set; }
        public string Description { get; set; }

        public EditionType EditionType { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

     
        public IEnumerable<string> Categories { get; set; }

      
    }
}
