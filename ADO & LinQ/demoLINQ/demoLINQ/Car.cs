using System;
using System.Collections.Generic;
using System.Text;

namespace demoLINQ
{
    public class Car
    {
        public int CarID { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public int OwnerID { get; set; }

        public Car(int carID, string color, string name, int ownerID)
        {
            CarID = carID;
            Color = color;
            Name = name;
            OwnerID = ownerID;
        }
    }
}
