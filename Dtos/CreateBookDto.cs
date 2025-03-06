using BookManagementAPI.Entities;

namespace BookManagementAPI.Dtos
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishedYear { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public Genre Genre { get; set; }
    }
}
