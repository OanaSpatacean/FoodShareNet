﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShareNet.Domain.Enums
{
    public enum OrderStatusEnum : int
    {
        Unconfirmed = 1,
        Confirmed = 2,
        InDelivery = 3,
        Delivered = 4
    }
}
