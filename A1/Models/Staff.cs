using Microsoft.AspNetCore.Identity;

namespace A1.Models
{
    public class Staff : IdentityUser
    {
        public string StaffId{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public string WorkEmail { get; set; }
        public string WorkPhone { get; set; }
    }
}
