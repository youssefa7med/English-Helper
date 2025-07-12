using EnglishHelper.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishHelper.Core.Models
{
    public class UserPoints
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Points must be greater than 0")]
        public int Points { get; set; }

        [Required]
        [MaxLength(50)]
        public string ActivityType { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        [ForeignKey("UserId")]
        public User User { get; set; }
    }

}
