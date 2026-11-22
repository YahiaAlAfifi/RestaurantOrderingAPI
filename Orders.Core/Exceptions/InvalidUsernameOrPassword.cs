namespace Orders.Core.Exceptions
{
    public class InvalidUsernameOrPassword : Exception
    {
        public InvalidUsernameOrPassword()
            : base("Invalid username or password")
        {
        }
    }
}
