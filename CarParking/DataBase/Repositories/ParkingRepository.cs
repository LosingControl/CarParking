using CarParking.DataBase.Context;
using CarParking.DataBase.Interfaces;
using CarParking.DTO_s;
using CarParking.Models;
using Microsoft.EntityFrameworkCore;

namespace CarParking.DataBase.Repositories
{
    public class ParkingRepository : IParkingRepository
    {
        private readonly ParkingDbContext _context;

        public ParkingRepository(ParkingDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckUserAsync(long id)
        {
            var user = await _context.UserData.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

            if (user != null) return true;

            return false;
        }

        public async Task<UserDatum?> GetUserAsync(long id)
        {
            var userFromDb = await _context.UserData.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

            return userFromDb;
        }
    }
}
