namespace MovieReview.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Rating { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}

