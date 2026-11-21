using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusMarket.Models
{
    public class Listing
    {
        public enum ProductStatusEnum { Nou, CaNou, Folosit }
        public enum ListingStatusEnum { Draft, WaitingForReview, NeedsChanges, Published }

        // DB
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Titlul este obligatoriu")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Descrierea este obligatorie")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Pretul este obligatorie")]
        public double Price { get; set; } = 0.0;

        [Required(ErrorMessage = "Categoria este obligatorie")]
        public int CategoryId { get; set; }

        public ProductStatusEnum ProductStatus { get; set; } = ProductStatusEnum.Folosit;
        public ListingStatusEnum ListingStatus { get; set; } = ListingStatusEnum.Draft;
        public string ListingAdminFeedback { get; set; } = string.Empty;
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
