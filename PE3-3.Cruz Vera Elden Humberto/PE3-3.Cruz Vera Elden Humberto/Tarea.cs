using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE3_3.Cruz_Vera_Elden_Humberto
{
    public class Tarea
    {
        //Propiedades
        public int ID { get; set; }
        public string NombreTarea { get; set; }
        public string Descripcion { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Status { get; set; }
        public string DescripcionStatus { get; set; }

        // Constructor con parametros
        public Tarea(int id, string nomTarea, string desc, string fechaInicio, string fechaFin, string status, string desStatus)
        { // se inicializan los atributos de la clase
            ID = id;
            NombreTarea = nomTarea;
            Descripcion = desc;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Status = status;
            DescripcionStatus = desStatus;
        }
    }
}
