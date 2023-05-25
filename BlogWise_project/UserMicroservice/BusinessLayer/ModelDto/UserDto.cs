namespace UserMicroservice.BusinessLayer.ModelDto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } // Add this property
        public DateTime ModifiedAt { get; set; } // Add this property
        // Add any additional properties as needed
    }
}
