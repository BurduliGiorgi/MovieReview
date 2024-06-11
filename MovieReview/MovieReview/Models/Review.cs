namespace MovieReview.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public ApplicationUser User { get; set; }
        public Movie Movie { get; set; }

    }
}

