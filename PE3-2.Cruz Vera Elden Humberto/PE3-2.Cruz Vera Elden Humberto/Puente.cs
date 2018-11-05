using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE3_2.Cruz_Vera_Elden_Humberto
{
    class Puente
    {
        Queue<Vaca> lado1 = new Queue<Vaca>(); // Colas de tipo Vaca
        Queue<Vaca> lado2 = new Queue<Vaca>();

        string texto; // Variable de cadena para imprimir el encabezado en medio

        string nom; // Variables que seran enviadas como parametros al constructor de la clase Vaca
        int time;

        int tiempoTotal=0; // Tiempo total del recorrido
        int aux1 = 0; // Contador para realizar calculos de tiempo de las vacas

        Vaca vaquita; // Se define el objeto vaquita de la clase Vaca

        private void AgregarVacas() // Metodo para agregar las vacas a la cola
        {
            for(int Cont = 0; Cont<4; Cont++) // Ciclo que inicia en 0 y termina en 4 para agregar 4 vacas
            {
                switch(Cont) // switch que utiliza Cont para cambiar el caso
                {
                    // En cada caso se asigna el nombre y tiempo distinto de cada vaca
                    case 0:
                        nom = "Daisy"; 
                        time = 4;
                        break;

                    case 1:
                        nom = "Mazie";
                        time = 2;
                        break;

                    case 2:
                        nom = "Crazy";
                        time = 10;
                        break;

                    case 3:
                        nom = "Lazy";
                        time = 20;
                        break;
                }
                vaquita = new Vaca(nom, time); // se instancia el objeto vaquita con dos parametros
                lado1.Enqueue(vaquita); // Se agrega un objeto vaca a la cola
            }
        }

        private void MostrarVacas() // Imprime las vacas en ambos lados del puente
        {
            AgregarVacas(); // Manda a llamar a AgregarVacas();
            texto = "----------Vacas de Bob----------";

            // Pone el texto en medio de la consola
            Console.SetCursorPosition((Console.WindowWidth - texto.Length) / 2, Console.CursorTop); 
            Console.WriteLine(texto); // Imprime el texto Vacas de Bob
            Console.WriteLine("Lado izquierdo del puente:");

            foreach (var item in lado1) // Muestra vacas de lado1
            {
                Console.WriteLine("Nombre: {0}  |  Tiempo: {1} minutos", item.Nombre, item.Tiempo);
            }

            Console.WriteLine("\nLado derecho del puente:");
            if (lado2.Count ==0) // Si no hay vacas muestra un mensaje
                Console.WriteLine("No hay vacas de este lado");
            foreach (var item in lado2) // Muestra vacas de lado2
            {
                Console.WriteLine("Nombre: {0}  |  Tiempo: {1} minutos", item.Nombre, item.Tiempo);
            }

            // Mensajes de información para el usuario
            Console.WriteLine("\nLas vacas estan actualmente en el lado izquierdo del puente.");

            Console.WriteLine("Las 4 vacas tienen que pasar de un lado del puente al otro en 34 minutos.");

            Console.Write("\nPresione una tecla para continuar: ");
            Console.ReadKey();
            Console.Clear(); // Limpia la pantalla
        }

        private void Movimiento1() // Movimiento 1 de las vacas, se mueven dos
        {
            MostrarVacas(); // Llamada de metodo
            foreach (var item in lado1)
            {
                if(aux1==0)
                    tiempoTotal = item.Tiempo; // Agrega el tiempo de la vaca mas lenta
                if (aux1==2)
                    break; // condición para romper el ciclo
                aux1++; // contador auxiliar para ver que vacas se van a mover
                lado2.Enqueue(item); // las vacas que se mueven se agregan a la otra cola
            }
            aux1 = 0;
            lado1.Dequeue(); // Se eliminan las vacas de la cola despues de mandarlas a la otra
            lado1.Dequeue();

            Console.WriteLine("Lado izquierdo del puente:");

            foreach (var item in lado1) // Imprime las vacas de lado1
            {
                Console.WriteLine("Nombre: {0}  |  Tiempo: {1} minutos", item.Nombre, item.Tiempo);
            }

            Console.WriteLine("\nLado derecho del puente:");

            foreach (var item in lado2) // Imprime las vacas de lado2
            {
                Console.WriteLine("Nombre: {0}  |  Tiempo: {1} minutos", item.Nombre, item.Tiempo);
            }

            Console.WriteLine("\nTiempo actual: {0} minutos", tiempoTotal); // Imprime tiempo que ha pasado
            Console.Write("Presione una tecla para continuar: ");
            Console.ReadKey();
            Console.Clear(); // limpia la pantalla

        }

        private void Movimiento2() // Movimiento 2 de las vacas
        {
            Movimiento1(); // Llamada de metodo

            foreach (var item in lado2) // Ciclo para sacar tiempo de solo una vaca
            {
                if (aux1 == 0)
                    tiempoTotal = tiempoTotal + item.Tiempo; // Agrega el tiempototal al tiempo de la vaca en movimiento
                if (aux1 == 1)
                    break; // al cumplir la condición se rompe el ciclo
                aux1++;
                lado1.Enqueue(item); // Se agrega la vaca que se movió a lado1
            }
            aux1 = 0;
            lado2.Dequeue(); // Se elimina una vaca de lado2

            Console.WriteLine("Lado izquierdo del puente:"); // Imprime las vacas de lado1

            foreach (var item in lado1)
            {
                Console.WriteLine("Nombre: {0}  |  Tiempo: {1} minutos", item.Nombre, item.Tiempo);
            }

            Console.WriteLine("\nLado derecho del puente:"); // Imprime las vacas de lado2

            foreach (var item in lado2)
            {
                Console.WriteLine("Nombre: {0}  |  Tiempo: {1} minutos", item.Nombre, item.Tiempo);
            }

            Console.WriteLine("\nTiempo actual: {0} minutos", tiempoTotal); // Imprime tiempo total
            Console.Write("Presione una tecla para continuar: ");
            Console.ReadKey();
            Console.Clear(); // Limpia consola
        }

        private void Movimiento3() // Movimiento3 de las vacas
        {
            Movimiento2(); // Llamada de metodo
            foreach (var item in lado1)
            {
                if (aux1 == 1) // Se añade el valor de tiempototal el valor que ya tenia antes mas el de la vaca mas lenta
                    tiempoTotal = tiempoTotal + item.Tiempo;

                if (aux1 == 2)   
                    break; // al cumplir la condicion se rompe el ciclo
                aux1++; // contador auxiliar para solo añadir ciertas vacas
                lado2.Enqueue(item); // Añade vacas a lado2
            }
            aux1 = 0;
            lado1.Dequeue(); // Se remueven las vacas que se movieron
            lado1.Dequeue();

            Console.WriteLine("Lado izquierdo del puente:"); // Imprime las vacas de lado1
            foreach (var item in lado1)
            {
                Console.WriteLine("Nombre: {0}  |  Tiempo: {1} minutos", item.Nombre, item.Tiempo);
            }

            Console.WriteLine("\nLado derecho del puente:"); // Imprime las vacas de lado2

            foreach (var item in lado2)
            {
                Console.WriteLine("Nombre: {0}  |  Tiempo: {1} minutos", item.Nombre, item.Tiempo);
            }

            Console.WriteLine("\nTiempo actual: {0} minutos", tiempoTotal); // Imprime tiempo transcurrido
            Console.Write("Presione una tecla para continuar: ");
            Console.ReadKey();
            Console.Clear();  // Limpia la pantalla
        }

        private void Movimiento4()
        {
            Movimiento3(); // Llamada de metodo
            foreach (var item in lado2) 
            {
                if (aux1 == 0)
                    tiempoTotal = tiempoTotal + item.Tiempo; // agrega al tiempoTotal el que ya tenia mas el de una vaca

                if (aux1 == 1)
                    break; // se rompe el ciclo al cumplir la condicion
                aux1++;
                lado1.Enqueue(item); // se añade una vaca a lado1
            }
            aux1 = 0;
            lado2.Dequeue(); // quita una vaca de lado2

            Console.WriteLine("Lado izquierdo del puente:"); // Imprime vacas de lado1 
            foreach (var item in lado1)
            {
                Console.WriteLine("Nombre: {0}  |  Tiempo: {1} minutos", item.Nombre, item.Tiempo);
            }

            Console.WriteLine("\nLado derecho del puente:"); // Imprime vacas de lado2

            foreach (var item in lado2)
            {
                Console.WriteLine("Nombre: {0}  |  Tiempo: {1} minutos", item.Nombre, item.Tiempo);
            }

            Console.WriteLine("\nTiempo actual: {0} minutos", tiempoTotal); // Muestra tiempo transcurrido
            Console.Write("Presione una tecla para continuar: ");
            Console.ReadKey();
            Console.Clear(); // Limpia la pantalla
        }

        public void Final() // Realiza el ultimo movimiento
        {
            Movimiento4(); // Llamada de metodo
            
            foreach (var item in lado1) 
            {
                if (aux1 == 0)
                    tiempoTotal = tiempoTotal + item.Tiempo; // añade a tiempoTotal lo que ya tenia mas tiempo de vaca lenta

                if (aux1 == 2)
                    break; // al cumplir la condicion se rompe el ciclo
                aux1++; // contador auxiliar para poder saber que vacas se van a mover
                lado2.Enqueue(item); // añade vacas a lado2
            }
            aux1 = 0;
            lado1.Dequeue(); // elimina las vacas de lado1
            lado1.Dequeue();

            Console.WriteLine("Lado izquierdo del puente:"); // Vacas de lado1
            if (lado1.Count == 0) // Si no hay vacas muestra un mensaje
                Console.WriteLine("No hay vacas de este lado");
            foreach (var item in lado1)
            {
                    Console.WriteLine("Nombre: {0}  |  Tiempo: {1} minutos", item.Nombre, item.Tiempo);
            }

            Console.WriteLine("\nLado derecho del puente:"); // Imprime vacas de lado2

            foreach (var item in lado2)
            {
                Console.WriteLine("Nombre: {0}  |  Tiempo: {1} minutos", item.Nombre, item.Tiempo);
            }

            Console.WriteLine("\nTiempo final después de cruzar el puente: {0} minutos", tiempoTotal); // tiempoToal
            Console.WriteLine("\nLas vacas estan actualmente en el lado derecho del puente."); // mensaje de despedida
            Console.Write("Presione una tecla para salir: ");

        }
    }
}
