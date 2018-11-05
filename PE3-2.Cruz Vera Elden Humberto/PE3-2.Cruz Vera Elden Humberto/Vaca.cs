using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE3_2.Cruz_Vera_Elden_Humberto
{
    public class Vaca // Clase vaca
    {
        public string Nombre { get; set; } // Atributos 
        public int Tiempo { get; set; }

        public Vaca(string nom, int time) // Constructor con dos parametros
        {
            Nombre = nom; // Inicialización
            Tiempo = time;
        }
    }
}
