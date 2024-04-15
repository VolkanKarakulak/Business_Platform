namespace Business_Platform.ViewModel
{
    public class RegisterViewModel
    {
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public bool IsApproved { get; set; }
    }
}
