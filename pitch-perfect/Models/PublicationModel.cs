using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pitch_perfect.Models
{
    public class Publication
    {
        [Key]
        public int PublicationId { get; set; }

        [Required]
        [StringLength(55, ErrorMessage = "Please shorten the publication title to 55 characters")]
        public string Title { get; set; }


        [Required]
        [StringLength(55, ErrorMessage = "Please shorten the publication specialty to 55 characters")]
        public string Specialty { get; set; }


        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }

        [Required]
        public User User { get; set; }
    }
}
