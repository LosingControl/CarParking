using CarParking.DTO_s;
using CarParking.Models;

namespace CarParking.DataBase.Interfaces
{
    public interface IParkingRepository
    {
        public Task<bool> CheckUserAsync(long id);
        public Task<UserDatum?> GetUserAsync(long id);
    }
}
