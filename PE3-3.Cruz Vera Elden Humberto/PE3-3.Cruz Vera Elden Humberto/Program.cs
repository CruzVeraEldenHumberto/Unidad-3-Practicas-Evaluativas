using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE3_3.Cruz_Vera_Elden_Humberto
{
    class Program
    {
        static void Main(string[] args)
        {
            Operacion op = new Operacion(); // se instancia el objeto de la clase Operacion
            op.Principal(); // se manda a llamar el metodo Principal de la clase Operacion
            Console.ReadKey();
        }
    }
}
