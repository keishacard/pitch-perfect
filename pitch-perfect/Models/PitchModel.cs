using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pitch_perfect.Models
{
    public class Pitch
    {
        [Key]
        public int PitchId { get; set; }

        public int PublicationId { get; set; }

        public Publication Publication { get; set; }

        [Required]
        [StringLength(55, ErrorMessage = "Please shorten the title to 55 characters")]
        public string Title { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Please shorten the synopsis to 300 characters")]
        public string Synopsis { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Required]
        public DateTime DateSubmitted { get; set; }

        [StringLength(55, ErrorMessage = "Please shorten the note to 55 characters")]
        public string Notes { get; set; }

       
        public bool Accepted { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? DateAccepted { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }

        [Required]
        public User User { get; set; }


    }
}
