using System.ComponentModel.DataAnnotations;

namespace CampusMarket.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele categoriei este obligatoriu")]
        public string CategoryName { get; set; } = string.Empty;

        public virtual ICollection<Listing> Listings { get; set; } = new List<Listing>();
    }
}
