using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekcja13
{
    class Q5Builder : IBuilder
    {
        private Car _car = new AudiQ5();

        public void AddEngine()
        {
            _car.Engine = "Jakiś silnik";
        }

        public void AddEquipment()
        {
            List<string> equipmentList = new List<string>();
            equipmentList.Add("Komputer pokładowy z dotykowym ekranem");
            equipmentList.Add("Klimatyzacja");
            equipmentList.Add("System dźwiękowy premium");
            _car.Equipment = equipmentList;
        }

        public void AddSeats()
        {
            _car.Seats = "Siedzenia skórzane, jasne";
        }

        public void AddWheels()
        {
            _car.Wheels = "Opony o zwiększonej przyczepności, alufelgi";
        }

        public Car GetCar()
        {
            return _car;
        }
    }
}
