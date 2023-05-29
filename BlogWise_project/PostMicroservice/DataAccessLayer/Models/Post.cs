using System;
using System.Collections.Generic;
using VoteMicroservice.DataAccessLayer.Models;

namespace BlogWise_project.DataAccessLayer.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public DateTime CreatedAt { get; set; }

        // Add this navigation property
        public ICollection<Vote> Votes { get; set; }
    }
}
