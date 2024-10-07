using System;
using System.Collections.Generic;

namespace CarParking.Models;

public partial class Car
{
    public long Id { get; set; }

    public string CarName { get; set; } = null!;

    public string CarNumber { get; set; } = null!;

    public string PtsNumber { get; set; } = null!;

    public int? ParkingPlaceId { get; set; }

    public long UserId { get; set; }

    public virtual ParkingPlace? ParkingPlace { get; set; }

    public virtual UserDatum User { get; set; } = null!;
}
