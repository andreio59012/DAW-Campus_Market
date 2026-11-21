using System.ComponentModel.DataAnnotations;

namespace CampusMarket.Models
{
    public class Review
    {
        // DB
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Conținutul recenziei este obligatoriu")]
        public string Content { get; set; } = string.Empty;

        public int ListingId { get; set; }
        public DateTime Date { get; set; }

        // Virtual
        public virtual Listing Listing { get; set; } = null!;
    }
}
