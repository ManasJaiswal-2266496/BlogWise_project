namespace VoteMicroservice.BusinessLayer.ModelDto
{
    public class VoteDto
    {
        public int VoteId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public bool IsUpvote { get; set; }
        public string VoteType { get; set; }
        public DateTime CreatedAt { get; set; } // Add this line
        public DateTime ModifiedAt { get; set; } // Add this line
    }
}
