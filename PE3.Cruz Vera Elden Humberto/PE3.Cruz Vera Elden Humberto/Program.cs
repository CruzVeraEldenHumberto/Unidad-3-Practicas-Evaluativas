using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE3.Cruz_Vera_Elden_Humberto
{
    class Program
    {
        static void Main(string[] args)
        {
            TorreHanoi torresita = new TorreHanoi(); // crea objeto de la clase TorreHanoi
            torresita.TorresHanoi(); // manda a llamar el metodo TorresHanoi
            Console.ReadKey();
        }
    }
}
