using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Alumno
    {
        public string Nombre { get; set; }
        public string UniqueId { get; private set; }
        public List<Evaluacion> Evaluaciones { get; set; }


        public Alumno()
        {
            this.UniqueId = Guid.NewGuid().ToString();
            this.Evaluaciones = new List<Evaluacion>();

        }
    }
}