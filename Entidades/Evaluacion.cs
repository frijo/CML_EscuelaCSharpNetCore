using System;

namespace CoreEscuela.Entidades
{
    public class Evaluacion
    {
        public string Nombre { get; set; }
        public string UniqueId { get; private set; }

        public Alumno Alumno {get;set;}
        public Asignatura Asignatura{get;set;}

        public float Nota{get;set;}

        public Evaluacion()
        {
            this.UniqueId = Guid.NewGuid().ToString();

        }
    }
}