using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekcja13
{
    class S80Builder : IBuilder
    {
        private Car _car = new VolvoS80();

        public void AddEngine()
        {
            _car.Engine = "Diesel T4";
        }

        public void AddEquipment()
        {
            List<string> equipmentList = new List<string>();
            equipmentList.Add("Automatyczna klimatyzacja");
            equipmentList.Add("Zwykłe radio");
            equipmentList.Add("Komputer pokładowy");
            _car.Equipment = equipmentList;
        }

        public void AddSeats()
        {
            _car.Seats = "Szare, podgrzewane fotele";
        }

        public void AddWheels()
        {
            _car.Wheels = "Klasyczne, stalowe felgi";
        }

        public Car GetCar()
        {
            return _car;
        }
    }
}
