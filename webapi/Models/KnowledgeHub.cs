using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class KnowledgeHub
    {
        [Key]
       public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
    }
}
