using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusMarket.Models
{
    public enum ProductStatus
    {
        [Display(Name = "Nou")]
        New = 1,
        [Display(Name = "Ca nou")]
        LikeNew = 2,
        [Display(Name = "Folosit")]
        Used = 3
    }
    public enum ListingStatus
    {
        [Display(Name = "În așteptare")]
        Pending = 0,

        [Display(Name = "Aprobat")]
        Approved = 1,

        [Display(Name = "Respins")]
        Rejected = 2
    }
    public class Listing
    {
        // DB
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Titlul este obligatoriu")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Descrierea este obligatorie")]
        public string Description { get; set; } = string.Empty;

        // Decimal is standard option for prices in C# / SQL Server
        [Required(ErrorMessage = "Prețul este obligatoriu")]
        [Range(0.01, 100000000, ErrorMessage = "Prețul trebuie să fie mai mare decât 0 și maximum 100.000.000")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Categoria este obligatorie")]
        public int CategoryId { get; set; }

        public string? ImagePath { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? PublishedAt { get; set; }

        public ProductStatus ProductStatus { get; set; } = ProductStatus.Used;
        public ListingStatus ListingStatus { get; set; } = ListingStatus.Pending;
        public string? ListingAdminFeedback { get; set; }

        [Range(0,100000, ErrorMessage = "Stocul nu trebuie să fie negativ")]
        public int Stock { get; set; } = 1;

        // Virtual Getters
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

        // Stuff for the UI
        [NotMapped]
        public IEnumerable<SelectListItem> CategorySelection { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
