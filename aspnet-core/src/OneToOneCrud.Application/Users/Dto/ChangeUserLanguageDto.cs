using System.ComponentModel.DataAnnotations;

namespace OneToOneCrud.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}