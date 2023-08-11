using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int Index { get; set; }
            
        [NotMapped]
        public ICollection<string> Choices { get; set; }
        public string ChoicesString
        {
            get { return string.Join(",", Choices); }
            set { Choices = value.Split(',').ToList(); }
        }
        public int Answer { get; set; }
        public int Point { get; set; }
        //fk
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
