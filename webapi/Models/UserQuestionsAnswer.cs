using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class UserQuestionsAnswer
    {
        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public string ApiUserId { get; set; } 
        public ApiUser ApiUser { get; set; }

    }
}
