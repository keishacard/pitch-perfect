using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pitch_perfect.Models
{
    public class PublicationPitch
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }

        [Required]
        public User User { get; set; }

        [ForeignKey("Pitch")]
        public int PitchId { get; set; }

        [Required]
        [ForeignKey("Publication")]
        public Publication Publication { get; set; }


    }
}
