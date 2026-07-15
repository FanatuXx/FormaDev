using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Voiture
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

        private int speed;

        public int Speed
        {
            get { return speed; }
            set 
            {
                if (value >= 0)
                {
                    speed = value; 
                }
            }
        }

        // 10 = valeur par défaut de supSpeed, mais peut être modifié en mettant une autre valeur entre parenthèses 
        // Les fonctions qui ne retournent rien (void) sont appelées "procédures"
        public void Accelerate(int supSpeed = 10)
        {
            Speed += supSpeed;
        }

        public void Decelerate(int dropSpeed = 10)
        {
            Speed -= dropSpeed;
        }


    }
}
