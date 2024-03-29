﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pitch_perfect.Models
{
    public class User : IdentityUser
    {
        //    [Required]
        //[Display(Name = "Username")]
        //public string Username { get; set; }

        //[Required]
        //[Display(Name = "Email")]
        //    public string Email { get; set; }

        public string ImagePath { get; set; }

        public virtual ICollection<Pitch> Pitches { get; set; }

        public virtual ICollection<Publication> Publications { get; set; }
    }
    }
