namespace CarParking.DTO_s
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string? Email { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string PassportId { get; set; } = null!;
    }
}
