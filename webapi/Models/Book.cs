using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Author { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
        [NotMapped]
        public byte[] ImgByte { get; set; }
        [Required]
        [MaxLength(13)] // Assuming ISBN-13 format
        public string ISBN { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int BookCategoryId { get; set; }
        public Category Category { get; set; }

        public bool NoReads { get; set; }

        public int Pages { get; set; }

        public string ApiUserId { get; set; } // Assuming Publisher is an ASP.NET User
        public ApiUser ApiUser { get; set; }

        public DateTime RecordDate  { get; set; } = DateTime.Now;

        public int ImprintId { get; set; }
        

        public string PDFUrl { get; set; }

        public int DaysToRead { get; set; }
    }
}
