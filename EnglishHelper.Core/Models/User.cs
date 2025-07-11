using System.ComponentModel.DataAnnotations;

namespace EnglishHelper.Models
{
    public class User
    {
        // Core/Entities/User.cs
            [Key]
            public int Id { get; set; }

            [Required, StringLength(100)]
            public string FullName { get; set; }

            [Required, EmailAddress]
            public string Email { get; set; }

            [Required]
            public string PasswordHash { get; set; }

            [Range(1, 10)]
            public int Level { get; set; }

            [Range(0, int.MaxValue)]
            public int TotalPoints { get; set; }
        

    }
}
