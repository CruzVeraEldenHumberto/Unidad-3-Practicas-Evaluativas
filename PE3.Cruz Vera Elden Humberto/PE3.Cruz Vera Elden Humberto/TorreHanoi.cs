using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE3.Cruz_Vera_Elden_Humberto
{ // profe aqui tengo un detalle con la impresion, encontre un metodo recursivo, pero la impresion sale toda fea
    class TorreHanoi
    {
        Stack<int> primera = new Stack<int>();//pila de primera 
        Stack<int> segunda = new Stack<int>();//pila segunda
        Stack<int> tercera = new Stack<int>();//pila a donde se deben mover los discos en orden de mayor a menor
        int cantidadDiscos; // cantidad de discos que va a tener la primer torre
        int contAux =0;
        public void TorresHanoi()
        {
            Console.Write("¿Cuantos discos deseas en la torre?: ");
            cantidadDiscos = Int16.Parse(Console.ReadLine()); // captura de discos que va a tener la torre
            contAux = cantidadDiscos; // contador auxiliar para añadir los discos a la pila
            while(contAux>0) // mientras que contAux sea mayor a 0
            {
                primera.Push(contAux); // se añade un elemento a la pila
                contAux--;// disminuye este contador en 1
            }

            Hanoi(cantidadDiscos, primera, segunda, tercera); // se manda a llamar a Hanoi y se envian 4 parametros
            Imprimir(primera, segunda, tercera); // se manda auxiliar llamar a im
            Console.ReadKey();
        }

        // metodo para imprimir y demostrar el movimiento de las torres
        static void Mover(Stack<int>origen, Stack<int>auxiliar, Stack<int>destino) // recibe las pilas como parametros
        {
            Imprimir(origen,auxiliar,destino); //manda a llamar a Imprimir, contiene 3 parametros
        }

        // Metodo recursivo que realiza los movimientos de los discos de cada torre, tiene 4 parametros
        // numero de discos, pila 1, pila 2 y pila 3
        static void Hanoi(int n, Stack<int> origen, Stack<int> auxiliar, Stack<int> destino)
        {
            
            if (n == 1) // si n este siendo el numero de discos sea 1
            {
                Mover(origen, auxiliar, destino); // manda a llamar a Mover para ver el movimiento
                destino.Push(origen.Pop()); // mete en la tercera columna un elemento y saca uno de la primera
            }
            else
            {
                // Los metodos se mandan a llamar a ellos mismos, con diferentes parametros, con el fin de realizar
                // todos los movimientos necesarios con las 3 pilas
                Hanoi(n - 1, origen, destino, auxiliar); // mueve los discos a la pila 2
                Hanoi(1,origen,auxiliar,destino); // mueve el disco mas grande
                Hanoi(n - 1, auxiliar, origen, destino); // mueve los discos restantes a la pila 3

            }
        }
        // Metodo para imprimir las 3 pilas para que no corra todo de golpe
        static void Imprimir(Stack<int> origen, Stack<int> auxiliar, Stack<int>destino) // recibe como parametros las 3 pilas
        {
            Console.Write("presione una tecla ");
            Console.ReadKey();
            Console.Clear();
            Console.Write("Primer torre:\n ");
            foreach (int num in origen) // imprime los valores de la pila1
            {
                Console.Write(num + "\n ");
            }
            Console.WriteLine();
            Console.Write("Segunda torre: \n");
            foreach (int num in auxiliar) // imprime los valores de la pila2
            {
                Console.Write(num + "\n ");
            }
            Console.WriteLine();
            Console.Write("Tercer torre:\n ");
            foreach (int num in destino) // imprime los valores de la pila3
            {
                Console.Write(num + "\n ");
            }
            Console.WriteLine();

        }

    }
}
