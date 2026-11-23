namespace Orders.Core.ViewModels
{
    public class LoginResponseViewModel
    {
        public AccessTokenViewModel AccessToken { get; set; } = null!;
        public UserViewModel User { get; set; } = null!;
    }
}
