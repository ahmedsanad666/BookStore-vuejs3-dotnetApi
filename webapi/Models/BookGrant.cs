using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class BookGrant
    {
        [Key]
        public int Id { get; set; }
        public string ApiUserId { get; set; } // Assuming Publisher is an ASP.NET User
        public ApiUser ApiUser { get; set; }
        public string BookTitle { get; set; }
        public string ISBN { get; set; }
        public int BookId { get; set; }
        public DateTime RecordedDate { get; set; } = DateTime.Now;
        public string GrantCode { get; set; }
        public int ValidTillDate { get; set; }
        public DateTime GrantDate { get; set; }

    }
}
