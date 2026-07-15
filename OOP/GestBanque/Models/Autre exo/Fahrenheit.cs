using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Autre_exo
{
    public class Fahrenheit
    {
        public float Degree { get; set; }

        public static explicit operator Celsius(Fahrenheit fahrenheit)
        {
            Celsius celsius = new Celsius();
            celsius.Degree = (fahrenheit.Degree - 32) * 5/9;
            return celsius;
        }
    }
}
