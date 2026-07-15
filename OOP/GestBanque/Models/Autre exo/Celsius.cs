using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Autre_exo
{
    public class Celsius
    {
        public float Degree { get; set; }

        public static implicit operator Fahrenheit(Celsius celsius)
        {
            Fahrenheit fahrenheit = new Fahrenheit();
            fahrenheit.Degree = (celsius.Degree * 9 / 5) + 32;
            return fahrenheit;
        }
    }
}
