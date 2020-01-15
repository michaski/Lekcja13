using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lekcja13
{
    public class ProductionCheef
    {
        readonly IBuilder Builder;

        public Car BuildCar(IBuilder builder)
        {
            builder.AddEngine();
            builder.AddSeats();
            builder.AddWheels();
            builder.AddEquipment();

            return builder.GetCar();
        }
    }
}