using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Alumno : ObjetoEscuelaBase
    {
               public List<Evaluacion> Evaluaciones { get; set; }


        public Alumno()
        {
          
            this.Evaluaciones = new List<Evaluacion>();

        }
    }
}