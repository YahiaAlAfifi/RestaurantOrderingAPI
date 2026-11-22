namespace Orders.Core.Dtos
{
    public class UpdateUserDto
    {
        public string Id { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string Address { get; set; } = null!;
    }
}