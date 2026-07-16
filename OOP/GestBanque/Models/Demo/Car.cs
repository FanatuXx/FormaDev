using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Demo
{
    public class Car : Vehicule
    {
        private string fuelType;
        private int wheelNumber;

        // prop + Tab pour généter un template get/set
        public string FuelType 
        {
            get 
            {
                return fuelType;
            }
            set 
            {
                fuelType = value;
            } 
        }

        public int WheelNumber
        {
            get
            {
                return wheelNumber;
            }
            set
            {
                if (value >= 0 && value <= 6)
                {
                    wheelNumber = value;
                }
            }
        }

        // prop + Tab pour générer un template get/set
        public int MyProperty { get; set; }

        // propfull + tab pour générer variable + constructor 


        internal Garage garage;

        protected int speed;

        public int Speed
        {
            get { return speed; }
            protected set 
            {
                if (value >= 0)
                {
                    speed = value; 
                }
            }
        }
       
        // override permet de réécrire le comportement d'une fonction dans une classe enfant qui hérite d'une classe parent
        public override void Accelerate(int supSpeed = 10)
        {
            //Speed += supSpeed;
            base.Accelerate(supSpeed);
        }

        // new permet de réécrire le comportement d'une fonction dans une classe enfant qui hérite d'une classe parent MAIS il ne changera pas le comportement si l'objet enfant est considéré comme l'objet parent 
        // Ex : Car mazda3 = new Car();
        //      Vehicule v = mazda3;
        //      v.Accelerate();    => Appelera la fonction de la classe Vehicule si jamais c'est le mot clé "new" qui est utilisé, et celui de la classe enfant si c'est le mot clé "override" qui est utilisé 
        public new void Decelerate(int dropSpeed = 10)
        {
            base.Decelerate(dropSpeed);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
