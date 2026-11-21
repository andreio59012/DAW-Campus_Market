using System.ComponentModel.DataAnnotations;

namespace CampusMarket.Models
{
    public class Reservation
    {
        public enum ReservationStateEnum { Upcoming, Confirmed, Cancelled }

        // DB
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public ReservationStateEnum ReservationState { get; set; } = ReservationStateEnum.Upcoming;
        public double Price { get; set; } = 0.0;
        public int ListingId { get; set; }

        // Virtual
        public virtual Listing Listing { get; set; } = null!;
    }
}
