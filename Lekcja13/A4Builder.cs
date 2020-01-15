using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lekcja13
{
    public class A4Builder : IBuilder
    {
        private Car car = new AudiA4();

        public void AddEngine()
        {
            car.Engine = "Klasyczny 136 konny Diesel";
        }

        public void AddEquipment()
        {
            car.Equipment = new List<string>();
            car.Equipment.Add("Standardowe radio CD");
            car.Equipment.Add("Lakier matowy, kolor biały");
        }

        public void AddSeats()
        {
            car.Seats = "Klasyczne fotele. Kolor szaro-czarny";
        }

        public void AddWheels()
        {
            car.Wheels = "16 calowe stalowe felgi. Opona 205/55 Continental.";
        }

        public Car GetCar()
        {
            return car;
        }
    }
}