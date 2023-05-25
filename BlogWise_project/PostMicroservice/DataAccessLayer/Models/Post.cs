using System;

namespace BlogWise_project.DataAccessLayer.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        // other properties as needed

        public DateTime CreatedAt { get; set; }
    }
}
