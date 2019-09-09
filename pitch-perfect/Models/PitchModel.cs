using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pitch_perfect.Models
{
    public class Pitch
    {
        [Key]
        public int PitchId { get; set; }

        [Required]
        [StringLength(55, ErrorMessage = "Please shorten the title to 55 characters")]
        public string Title { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Please shorten the product title to 300 characters")]
        public string Synopsis { get; set; }

        [Required]
        [StringLength(55, ErrorMessage = "Please shorten the publication title to 55 characters")]
        public string SubmittedTo { get; set; }

        [Required]
        public DateTime DateSubmitted { get; set; }

        [StringLength(55, ErrorMessage = "Please shorten the note to 55 characters")]
        public string Notes { get; set; }

       
        public string Accepted { get; set; }

        public DateTime DateAccepted { get; set; }

        [Required]
        public string UserId { get; set; }


    }
}
