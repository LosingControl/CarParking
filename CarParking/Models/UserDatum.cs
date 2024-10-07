using System;
using System.Collections.Generic;

namespace CarParking.Models;

public partial class UserDatum
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string? Email { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string PassportId { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual ICollection<ParkingPlace> ParkingPlaces { get; set; } = new List<ParkingPlace>();
}
