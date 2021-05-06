using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class EscuelaEngine
    {
        public Escuela escuela { get; set; }

        public EscuelaEngine()
        {

        }
        public void Inicializar()
        {
            escuela = new Escuela("Escuela Platxi", 1980, TiposEscuela.Primaria, ciudad: "Quesada");
            
            escuela.Cursos = new List<Curso>(){
                new Curso() { Nombre = "101", Jornada= TiposJornada.Manana },
                new Curso() { Nombre = "201", Jornada= TiposJornada.Manana },
                new Curso() { Nombre = "301", Jornada= TiposJornada.Manana },
                new Curso() { Nombre = "401", Jornada= TiposJornada.Manana },
                new Curso() { Nombre = "501", Jornada= TiposJornada.Manana }
            };

           
        }

    }
}