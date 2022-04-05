﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Username must contain 3 - 30 characters", MinimumLength = 3)]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string? Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Max lenght 50")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Max lenght 50")]
        public string? LastName { get; set; }


        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }



    }
}