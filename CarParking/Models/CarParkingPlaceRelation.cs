using System;
using System.Collections.Generic;

namespace CarParking.Models;

public partial class CarParkingPlaceRelation
{
    public long CarId { get; set; }

    public int PlaceId { get; set; }
}
