using CarParking.DTO_s;

namespace CarParking.Services.Interfaces
{
    public interface IParkingService
    {
        public Task<UserDTO?> GetUserByIdAsync(long id);
    }
}
