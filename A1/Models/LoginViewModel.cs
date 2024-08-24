namespace A1.Models
{
    public class LoginViewModel
    {
        public string StaffId { get; set; }
        public string Password { get; set; }
        public HttpContext HttpContext { get; set; }

        public LoginViewModel()
        {
            HttpContext = new DefaultHttpContext();
        }
    }
}
