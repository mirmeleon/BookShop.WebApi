using System.ComponentModel.DataAnnotations;

namespace BookShopSytem.Models.BindingModels
{
  public class CreateAuthorBm
    {
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
