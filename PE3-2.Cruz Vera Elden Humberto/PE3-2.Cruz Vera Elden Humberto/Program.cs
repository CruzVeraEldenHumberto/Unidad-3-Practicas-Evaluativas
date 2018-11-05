using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE3_2.Cruz_Vera_Elden_Humberto
{
    class Program
    {
        static void Main(string[] args)
        {
            Puente puentesito = new Puente(); // creación de objeto de la clase Puente
            puentesito.Final(); // Manda a llamar al metodo Final de la clase Puente
            Console.ReadKey();
        }
    }
}
