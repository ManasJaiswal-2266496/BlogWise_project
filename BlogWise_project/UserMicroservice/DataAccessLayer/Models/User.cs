using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VoteMicroservice.DataAccessLayer.Models;

namespace UserMicroservice.DataAccessLayer.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; } // Add this line

        [Required]
        public string Password { get; set; } // Add this line

        public string PhoneNumber { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        // Add this navigation property
        public ICollection<Vote> Votes { get; set; }
    }
}
