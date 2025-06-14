namespace UnicomTIC_Management_System.Models
{
    public class User
    {
        public int Id { get; set; }             // User ID from database
        public string Username { get; set; }    // Username
        public string Password { get; set; }    // Password (consider hashing later)
        public string Role { get; set; }        // Role like Admin, User, etc.
    }
}
