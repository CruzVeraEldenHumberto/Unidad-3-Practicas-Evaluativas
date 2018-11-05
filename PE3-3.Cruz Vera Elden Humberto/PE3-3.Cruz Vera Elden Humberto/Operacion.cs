using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE3_3.Cruz_Vera_Elden_Humberto
{
    class Operacion
    {
        // Creacion de listas de tipo Tarea, Pendiente Proceso y Terminadas
        List<Tarea> Pendiente = new List<Tarea>();
        List<Tarea> Proceso = new List<Tarea>();
        List<Tarea> Terminadas = new List<Tarea>();

        Tarea tareaChida; // Objeto de tipo Tarea
        // Variables que se enviaran como parametros al constructor
        int id;
        string nomTarea;
        string descTarea;
        string fechaInicio = "";
        string fechaFin = "";
        string status = "";
        string desStatus = "";

        int contAux; //Contador Auxiliar
        int opcion; // Opcion para el Menu
        int numTareas; // variable que captura el numero de tareas que desea el usuario

        private void AgregarTareaInicial() // Agrega las primeras tareas a la lista
        {
            Console.Write("\nID: "); // captura ID
            id = int.Parse(Console.ReadLine());

            foreach (var item in Pendiente) // Por cada objeto de Pendiente realiza el siguiente codigo
            {
                while (tareaChida.ID == id) // Mientras el id sea igual a la propiedad ID en alguna parte de la lista
                { // muestra el siguiente mensaje pidiendo que capture nuevamente el ID
                    Console.WriteLine("Tarea duplicada, intente agregar una tarea diferente");
                    Console.Write("\nID: ");
                    id = int.Parse(Console.ReadLine());
                }
            }

            foreach (var item in Proceso) // Mientras el id sea igual a la propiedad ID en alguna parte de la lista
            {// muestra el siguiente mensaje pidiendo que capture nuevamente el ID
                while (tareaChida.ID == id)
                {
                    Console.WriteLine("Tarea duplicada, intente agregar una tarea diferente");
                    Console.Write("\nID: ");
                    id = int.Parse(Console.ReadLine());
                }
            }

            foreach (var item in Terminadas)// Mientras el id sea igual a la propiedad ID en alguna parte de la lista
            {// muestra el siguiente mensaje pidiendo que capture nuevamente el ID
                while (tareaChida.ID == id)
                {
                    Console.WriteLine("Tarea duplicada, intente agregar una tarea diferente");
                    Console.Write("\nID: ");
                    id = int.Parse(Console.ReadLine());
                }
            }

            // Captura propiedades del objeto como el nombre, descripcion, status, etc
            Console.Write("Nombre de la Tarea: ");
            nomTarea = Console.ReadLine();
            Console.Write("Descripcion: ");
            descTarea = Console.ReadLine();
            Console.Write("Status (Pendiente/Proceso/Terminada): ");
            status = Console.ReadLine();

            // Mientras que el status no tenga estas condiciones le pide al usuario que ingrese el status otra vez
            while (status != "Proceso" && status != "Terminada" && status != "Pendiente")
            {
                Console.WriteLine("Status no valido, escriba el status de nuevo");
                Console.Write("Status: (Pendiente/Proceso/Terminada)");
                status = Console.ReadLine(); // captura de status nuevamente
            }

            if (status == "Proceso") // Si el status es igual a Proceso pide que capture Fecha de inicio
            {
                Console.Write("Fecha de inicio:");
                fechaInicio = Console.ReadLine();
            }

            if (status == "Terminada") // Si el status es igual a Proceso pide que capture Fecha de inicio y fin
            {
                Console.Write("Fecha de inicio:");
                fechaInicio = Console.ReadLine();
                Console.Write("Fecha de fin:");
                fechaFin = Console.ReadLine();
            }

            Console.Write("Descripcion del Status: "); // Descripción sobre el status
            desStatus = Console.ReadLine();
            Console.WriteLine();

            // Instancia el objeto tareaChida de la clase Tarea y manda parametros al constructor de la clase
            tareaChida = new Tarea(id, nomTarea, descTarea, fechaInicio, fechaFin, status, desStatus);


            // Dependiendo del status que tenga añade un objeto tarea ya sea a Pendiente, Proceso o Terminada
            if (status == "Pendiente")
            {
                Pendiente.Add(tareaChida);
            }

            if (status == "Proceso")
            {
                Proceso.Add(tareaChida);
            }

            if (status == "Terminada")
            {
                Terminadas.Add(tareaChida);
            }
        }

        private void Menu() //Menu para que el usuario pueda ver o modificar tareas
        {
            Console.Clear();
            Console.WriteLine("1. Agregar tareas");
            Console.WriteLine("2. Ver tareas");
            Console.WriteLine("3. Modificar tarea");
            Console.WriteLine("4. Salir del programa");
            Console.Write("Presione el número de su elección: ");
            opcion = Int16.Parse(Console.ReadLine()); // captura  de la opción del usuario
            switch (opcion) // switch case de la variable opción
            {
                case 1: // En este caso manda a llamar a AgregarTareaAdicional para que añadabn tareas a la lista
                    Console.WriteLine("\nCuantas tareas desea Agregar: ");
                    numTareas = int.Parse(Console.ReadLine()); // captura del numero de tareas

                    for (int i = 0; i < numTareas; i++) // hasta que no se termine el ciclo, agrega tareas a la lista
                    {
                        AgregarTareaAdicional();
                    }
                    Menu(); // se regresa al menu

                    break; // rompe el caso

                case 2:
                    VerTareas();
                    break; // rompe el caso

                case 3:
                    EditarTarea();
                    break; // rompe el caso/se sale del switch

                default: // opcion por defecta, si ninguno de los otros casos ocurre termina el programa
                    Console.WriteLine("\nGracias por utilizar el programa");
                    Console.Write("Presione una tecla para salir: ");
                    Console.ReadKey();
                    Environment.Exit(0); // ciera la aplicación
                    break; // se sale del switch
            }
        }

        private void AgregarTareaAdicional() // Metodo para agregar tareas
        {
            Console.Clear(); // limpia la pantalla
            Console.Write("ID: ");
            id = int.Parse(Console.ReadLine());
            foreach (var item in Pendiente)   // busca todos los objetos en Pendiente
            {
                while (tareaChida.ID == id)
                // Mientras el id sea igual a la propiedad ID en alguna parte de la lista
                // muestra el siguiente mensaje pidiendo que capture nuevamente el ID
                {
                    Console.WriteLine("Tarea duplicada, intente agregar una tarea diferente");
                    Console.Write("ID: ");
                    id = int.Parse(Console.ReadLine()); // captura de ID
                }

            }
            // Captura de los datos de la tarea
            Console.WriteLine("Nombre de la Tarea: ");
            nomTarea = Console.ReadLine();
            Console.Write("Descripcion: ");
            descTarea = Console.ReadLine();
            status = "Pendiente"; // cada tarea nueva que se agregue siempre estara pendiente
            Console.Write("Descripcion del Status: ");
            desStatus = Console.ReadLine();
            Console.WriteLine();
            // Se mandan como parametros las variables que se capturaron y se envian al constructor de Tarea
            tareaChida = new Tarea(id, nomTarea, descTarea, fechaInicio, fechaFin, status, desStatus);
            Pendiente.Add(tareaChida); // se añade el objeto a la lista Pendiente
        }

        private void EditarTarea() // Metodo para editar tareas existentes
        {
            Console.Clear(); // limpia la consola
            Console.WriteLine("Que tipo de tarea desea editar:");
            Console.Write("1. Tareas Pendientes, 2. Tareas En Proceso, 3. Tareas Terminadas: ");
            int Opcion = int.Parse(Console.ReadLine()); // captura de la tarea que desean modificar
            switch (Opcion) // switch case que tiene como variable Opcion
            {
                case 1: // caso 1 es para modificar tareas Pendientes
                    foreach (var item in Pendiente) // despliega todas las tareas de la lista Pendiente
                    {
                        // Imprime ID y nombre de la tarea
                        Console.WriteLine("ID: {0} | Nombre: {1}", item.ID, item.NombreTarea);
                    }

                    Console.WriteLine("\nQue tarea desea editar (Ingrese ID): ");
                    id = int.Parse(Console.ReadLine()); // captura del ID de la tarea a modificar
                    contAux = -1; // Contador auxiliar para remover Tarea de la lista Pendite
                    foreach (var item in Pendiente) // busca todas las tareas de la lista Pendiente
                    {
                        contAux++; // incrementa en uno el contador auxiliar, para asi remover la tarea correcta
                        if (tareaChida.ID == id) // si el ID de la tarea de la lista Pendiente es igual a id
                        {
                            Console.Write("Escriba el status de la tarea: ");
                            status = Console.ReadLine(); // pide que capture el nuevo status de la tarea

                            while (status != "Terminada" && status != "Proceso")
                            {
                                // mientras que el status sea distinto a Terminada y Proceso le pide al usuario que lo capture
                                // de nuevo
                                Console.WriteLine("Status no valido");
                                Console.Write("Escriba el status de la tarea: ");
                                status = Console.ReadLine(); // capturando status
                            }

                            if (status == "Proceso") // si el status es igual a Proceso
                            {
                                tareaChida.Status = status; // el atributo de la tarea cambia a Proceso
                                // captuta de atributos
                                Console.Write("Ingrese la fecha de inicio de la tarea: ");
                                tareaChida.FechaInicio = Console.ReadLine();
                                Console.Write("Agregue una descripción del status: ");
                                tareaChida.DescripcionStatus = Console.ReadLine();

                                Proceso.Add(item); // añade la tarea a la lista Proceso
                                Pendiente.RemoveAt(contAux); // remueve la tarea de la lista Pendiente
                                break; // rompe el ciclo
                            }

                            if (status == "Terminada") // si el status es igual a Terminada
                            {
                                tareaChida.Status = status; // el atributo de la tarea cambia Terminada
                                // captura de atributos
                                Console.Write("Ingrese la fecha de inicio de la tarea");
                                tareaChida.FechaInicio = Console.ReadLine();
                                Console.Write("Ingrese la fecha de fin de la tarea");
                                tareaChida.FechaFin = Console.ReadLine();
                                Console.Write("Agregue una descripción del status");
                                tareaChida.DescripcionStatus = Console.ReadLine();

                                Terminadas.Add(item);//añade la tarea a la lista Terminada
                                Pendiente.RemoveAt(contAux); // remuve la tarea de la lista Pendiente
                                break; // rompe el ciclo

                            }

                        }
                    }
                    Menu();
                    break; // termina el caso 1

                case 2: // inicia el caso 2 para las tareas en Proceso
                    foreach (var item in Proceso)
                    { // por cada objeto en la lsta Proceso, imprime el id y nombre de las tareas de la lista
                        Console.WriteLine("ID: {0} | Nombre: {1}", item.ID, item.NombreTarea);
                    }

                    Console.WriteLine("\nQue tarea desea editar: (Ingrese ID)");
                    id = int.Parse(Console.ReadLine()); // captura el id de la tarea a modificar
                    contAux = -1; // contador auxiliar utilizado para remover una tarea de la lista Proceso
                    foreach (var item in Proceso)
                    {
                        contAux++; // incrementa en uno el contador auxiliar, para asi remover la tarea correcta
                        if (tareaChida.ID == id) // si el ID de la tarea de la lista Pendiente es igual a id
                        {
                            Console.Write("Escriba el status de la tarea");
                            status = Console.ReadLine(); // Pide que capture de nuevo el status

                            while (status != "Terminada") // mientras que el status sea distinto a Terminada indica
                            { // que el status no es valido
                                Console.WriteLine("Status no valido");
                                Console.Write("Escriba el status de la tarea");
                                status = Console.ReadLine(); // captura del status por segunda vez
                            }

                            if (status == "Terminada") // si el status coincide entonces
                            {
                                tareaChida.Status = status; // el atributo Status toma el valor de status
                                // Se le asignan valores a estos atributos de Tarea
                                Console.Write("Ingrese la fecha de inicio de la tarea");
                                tareaChida.FechaInicio = Console.ReadLine();
                                Console.Write("Ingrese la fecha de fin de la tarea");
                                tareaChida.FechaFin = Console.ReadLine();
                                Console.Write("Agregue una descripción del status");
                                tareaChida.DescripcionStatus = Console.ReadLine();

                                Terminadas.Add(item); // se añade un objeto tarea a la lista Terminadas
                                Proceso.RemoveAt(contAux); // remueve la tarea que antes estaba en Proceso
                                break; // se rompe el ciclo
                            }

                        }

                    }
                    Menu(); // regresa al Menu
                    break; // se termina el caso 2

                case 3: // caso 3 para las tareas Terminadas
                    foreach (var item in Terminadas)
                    { // por cada objeto en la lista Termindas, imprime el id y nombre de las tareas de esta lista
                        Console.WriteLine("ID: {0} | Nombre: {1}", item.ID, item.NombreTarea);
                    }

                    Console.WriteLine("\nQue tarea desea editar: (Ingrese ID)");
                    id = int.Parse(Console.ReadLine()); // captura de id
                    contAux = -1; // variable auxiliar para eliminar el objeto tarea de esta lista
                    foreach (var item in Terminadas)
                    {
                        contAux++; // se incrementa en 1 esta variable, para asi remover la tarea correcto
                        if (tareaChida.ID == id) // si el ID de la tarea de la lista Pendiente es igual a id
                        {
                            Console.Write("Escriba el status de la tarea");
                            status = Console.ReadLine(); // Pide que capture de nuevo el status

                            while (status != "Proceso") // mientras que el status sea distinto a Proceso indica
                            {  // que el status no es valido
                                Console.WriteLine("Status no valido");
                                Console.Write("Escriba el status de la tarea");
                                status = Console.ReadLine(); // captura del status por segunda vez
                            }

                            if (status == "Proceso") // si el status coincide entonces
                            {
                                tareaChida.Status = status; // el atributo Status toma el valor de status
                                // Se le asignan valores a estos atributos de Tarea
                                Console.Write("Ingrese la fecha de inicio de la tarea");
                                tareaChida.FechaInicio = Console.ReadLine();
                                Console.Write("Agregue una descripción del status");
                                tareaChida.DescripcionStatus = Console.ReadLine();
                                Proceso.Add(item); // se añade un objeto Tarea a la lista Proceso
                                Terminadas.RemoveAt(contAux); // se remueve un objeto de la lista Terminadas
                                break; // se rompe el ciclo foreach
                            }

                        }

                    }
                    Menu(); // se regresa al Menu
                    break; // se termina el caso 3
            }
        }

        private void VerTareas() // Metodo para ver las tareas existentes
        {
            Console.Clear(); // limpia la pantalla
            Console.WriteLine("Lista global ");
            Console.WriteLine("1. Pendientes");
            Console.WriteLine("2. En Proceso");
            Console.WriteLine("3. Terminadas");
            Console.Write("Presione el número de su elección: ");
            opcion = Int16.Parse(Console.ReadLine()); // Captura del tipo de tarea deseada

            switch (opcion) // switch case que depende la variable capturada opcion
            {
                case 1://Caso 1 para las tareas Pendientes
                    Console.Clear(); // limpia la pantalla
                    Console.WriteLine("Tareas pendientes");
                    foreach (var item in Pendiente) // Busca todas las tareas de la lista Pendiente
                    { // despliega el ID de la lista Pendiente
                        Console.WriteLine(item.ID);
                    }
                    Console.WriteLine("\nEscriba el id de la tarea:");
                    id = Int16.Parse(Console.ReadLine()); // captura del id a buscar
                    foreach (var item in Pendiente) // busca los objetos de Pendiente
                    {
                        if (item.ID == id) // si el id captura es el mismo que el de la lista
                        { // despliega los atributos de la Tarea
                            Console.WriteLine();
                            Console.WriteLine("ID: {0}", item.ID);
                            Console.WriteLine("Nombre: {0}", item.NombreTarea);
                            Console.WriteLine("Descripción: {0}", item.Descripcion);
                            Console.WriteLine("Status: {0}", item.Status);
                            Console.WriteLine("Descripción del Status: {0}", item.DescripcionStatus);
                            Console.WriteLine();
                        }
                    }
                    Console.Write("Presione una tecla para continuar: ");
                    Console.ReadKey();
                    Menu(); // se regresa a Menu
                    break; // se sale del switch

                case 2: // Caso 2 para las tareas pendientes
                    Console.Clear(); // limpia la consola
                    Console.WriteLine("Tareas en proceso");
                    foreach (var item in Proceso)
                    { // despliega el ID de todas las tareas de Proceso
                        Console.WriteLine(item.ID);
                    }
                    Console.WriteLine("\nEscriba el id de la tarea:");
                    id = Int16.Parse(Console.ReadLine()); // captura el id que desea consultar
                    foreach (var item in Proceso) // busca todos los objetos dentro de Proceso
                    {
                        if (item.ID == id) // si el id captura es el mismo que el de la lista
                        { // despliega atributos de la tarea
                            Console.WriteLine();
                            Console.WriteLine("ID: {0}", item.ID);
                            Console.WriteLine("Nombre: {0}", item.NombreTarea);
                            Console.WriteLine("Descripción: {0}", item.Descripcion);
                            Console.WriteLine("Status: {0}", item.Status);
                            Console.WriteLine("Fecha de inicio: {0}", item.FechaInicio);
                            Console.WriteLine("Descripción del Status: {0}", item.DescripcionStatus);
                            Console.WriteLine();
                        }

                    }
                    Console.Write("Presione una tecla para continuar: ");
                    Console.ReadKey();
                    Menu(); // Se regresa al Menu
                    break; // Se sale del switch

                case 3: // Caso 3 para las tareas terminadas
                    Console.Clear(); // limpia la pantalla
                    Console.WriteLine("Tareas terminadas");
                    foreach (var item in Terminadas) // busca todos los objetos de la lista Terminadas
                    { // Imprime el atributo ID de la Tarea
                        Console.WriteLine(item.ID);
                    }
                    Console.WriteLine("\nEscriba el id de la tarea:");
                    id = Int16.Parse(Console.ReadLine()); // captura del id que desea consultar
                    foreach (var item in Terminadas)
                    {
                        if (item.ID == id) // si el id captura es el mismo que el de la lista
                        { // despliega atributos de la tarea
                            Console.WriteLine();
                            Console.WriteLine("ID: {0}", item.ID);
                            Console.WriteLine("Nombre: {0}", item.NombreTarea);
                            Console.WriteLine("Descripción: {0}", item.Descripcion);
                            Console.WriteLine("Status: {0}", item.Status);
                            Console.WriteLine("Fecha de inicio: {0}", item.FechaInicio);
                            Console.WriteLine("Fecha de finalización: {0}", item.FechaFin);
                            Console.WriteLine("Descripción del Status: {0}", item.DescripcionStatus);
                            Console.WriteLine();
                        }
                    }
                    Console.Write("Presione una tecla para continuar: ");
                    Console.ReadKey();
                    Menu(); // se regresa al Menu
                    break; // se sale del switch
            }
        }

        public void Principal() //Metodo que inicia el programa de tipo publico
        {
            Console.Write("Cuantas tareas desea Agregar: "); // Pregunta al usuario las tareas que desea agregar
            numTareas = int.Parse(Console.ReadLine()); // captura numero de tareas deseadas

            for (int i = 0; i < numTareas; i++) // se agregan tareas hasta que el ciclo termine su ejecución
            {
                AgregarTareaInicial(); // Manda a llamar al metodo 
            }

            Console.Write("Presione una tecla para continuar "); // Mensaje para el usuario
            Console.ReadKey();

            Menu(); // Manda a llamar a Menu

        }
    }
}
