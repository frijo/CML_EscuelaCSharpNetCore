using System;
using System.Collections.Generic;
using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console; // Helps to not write the Console everytime

namespace CoreEscuela
{

    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();

            ImprimirCursosEscuela(engine.escuela);

        }

        private static bool Predicado(Curso obj)
        {
            return obj.Nombre == "301";
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle(escuela.Nombre);

            /* if (escuela.Cursos != null && escuela != null)
             {
                 foreach (var curso in escuela.Cursos)
                 {
                     WriteLine($"Nombre del Cruso: {curso.Nombre}, ID del Curso : {curso.UniqueId} ");
                 }
             }
             */

            //this way verify first if escuela is not null then is going to verify Cursos if also is not null, is a shoter way to verify compared with if validation above.
            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre del Curso: {curso.Nombre}, ID del Curso : {curso.UniqueId} , Tipo de Jornada : {curso.Jornada} ")
                    ;
                    //  WriteLine($"Alumnos del curso: {curso.Nombre}");
                    var cont = 1;
                    foreach (var alunmo in curso.Alumnos)
                    {
                        
                        WriteLine($"{cont}: {alunmo.Nombre}");
                        cont++;
                    }

                    /*   cont = 1;
                       WriteLine($"Asignaturas del curso: {curso.Nombre}");
                       foreach (var asignatura in curso.Asignaturas)
                       {
                           WriteLine($"{cont}: {asignatura.Nombre}");
                           cont++;
                       }
                       */
                     ImprimirEvaluaciones(curso.Alumnos);
                }
            }

        }
        private static void ImprimirEvaluaciones(List<Alumno> alumnos)
        {
            foreach (var alumno in alumnos){
                var cont=1;
                foreach(var ev in alumno.Evaluaciones){
                   
                    WriteLine($"Nota-{cont}.......");
                             
                    WriteLine($"Nota del Alumno: {ev.Alumno.Nombre} en el curso de: {ev.Asignatura.Nombre}");
                    WriteLine($"Evaluacion: {ev.Nombre} Nota: {ev.Nota}");
                    WriteLine("***********");
                    cont++;
                }
            }
        }

    }
}
