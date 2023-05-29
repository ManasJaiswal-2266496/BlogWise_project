using BlogWise_project.DataAccessLayer.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserMicroservice.DataAccessLayer.Models;

namespace VoteMicroservice.DataAccessLayer.Models
{
    public class Vote
    {
        [Key]
        public int VoteId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required]
        public bool IsUpVote { get; set; }

        [Required]
        public string VoteType { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; } // Add this line
    }
}
