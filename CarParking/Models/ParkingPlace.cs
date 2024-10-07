using System;
using System.Collections.Generic;

namespace CarParking.Models;

public partial class ParkingPlace
{
    public int Id { get; set; }

    public int Floor { get; set; }

    public int PlaceNumber { get; set; }

    public TimeOnly? ReservationDate { get; set; }

    public long? UserId { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual UserDatum? User { get; set; }
}
