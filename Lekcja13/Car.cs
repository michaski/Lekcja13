using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lekcja13
{
    public abstract class Car
    {
        protected string Name;
        protected string Model;
        readonly string VIN;
        public string Wheels;
        public string Seats;
        public string Engine;
        public List<string> Equipment;
    }
}