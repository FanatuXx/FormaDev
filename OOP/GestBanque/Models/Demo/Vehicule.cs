using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Demo
{
    public abstract class Vehicule
    {
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

        // 10 = valeur par défaut de supSpeed, mais peut être modifié en mettant une autre valeur entre parenthèses 
        // Les fonctions qui ne retournent rien (void) sont appelées "procédures"
        // Virtual permet de dire que les classes enfants qui hériteront de cette classe pourront modifier le comportement de la fonction grâce au mot clé "override"
        public virtual void Accelerate(int supSpeed = 10)
        {
            Speed += supSpeed;
        }

        public virtual void Decelerate(int dropSpeed = 10)
        {
            Speed -= dropSpeed;
        }

        //public override string ToString()
        //{
        //    return base.ToString();
        //}
    }
}
