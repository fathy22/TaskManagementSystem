using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}