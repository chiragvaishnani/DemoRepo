namespace TaskManagement.Models.Models
{
    public class RegisterUserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime LastLogin { get; set; } = DateTime.Now;
    }
}
