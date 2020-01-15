using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lekcja13
{
    public interface IBuilder
    {
        void AddSeats();
        void AddWheels();
        void AddEquipment();
        void AddEngine();
        Car GetCar();
    }
}