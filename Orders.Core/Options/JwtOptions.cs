namespace Orders.Core.Options
{
    public class JwtOptions
    {
        public string SecurityKey { get; set; } = null!;
        public string Issuer { get; set; } = null!;
    }
}
