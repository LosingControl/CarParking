using CarParking.DataBase.Interfaces;
using CarParking.DTO_s;
using CarParking.Services.Interfaces;

namespace CarParking.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IParkingRepository _parkingRepository;

        public ParkingService(IParkingRepository parkingRepository)
        {
            _parkingRepository = parkingRepository;
        }

        public async Task<UserDTO?> GetUserByIdAsync(long id)
        {
            var userFromDb = await _parkingRepository.GetUserAsync(id);

            if (userFromDb == null) return null;

            UserDTO userDTO = new UserDTO
            {
                Id = userFromDb.Id,
                Name = userFromDb.Name,
                LastName = userFromDb.LastName,
                MiddleName = userFromDb.MiddleName,
                Email = userFromDb.Email ?? "-",
                PassportId = userFromDb.PassportId,
                PhoneNumber = userFromDb.PhoneNumber,
            };

            return userDTO;
        }
    }
}
