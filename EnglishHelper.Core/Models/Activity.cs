using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishHelper.Core.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; } // "chat", "image", "voice"
        public string Description { get; set; }
    }

}
