using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console; // Helps to not write the Console everytime

namespace CoreEscuela
{

    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Escuela Platxi", 1980, TiposEscuela.Primaria, ciudad: "Quesada");
            WriteLine(escuela);
            WriteLine("================");
            var cursoarreglo = new Curso[]{
                new Curso() { Nombre = "101" },
                new Curso() { Nombre = "201" },
                new Curso { Nombre = "301" }
            };
            //Curso[] cursoarreglo = {...,...,...} //Otra forma de inicializar un arreglo

            //Aisignando Cursos desde Escuela

            /*  ImprimirCursosWhile(escuela.Cursos );
                ImprimirCursoDoWHile(escuela.Cursos );
                ImprimirCursoFor(escuela.Cursos );
                ImprimirCursoForEach(escuela.Cursos );
            */
            escuela.Cursos = new List<Curso>(){
                new Curso() { Nombre = "101", Jornada= TiposJornada.Manana },
                new Curso() { Nombre = "201", Jornada= TiposJornada.Manana },
                new Curso { Nombre = "301", Jornada= TiposJornada.Manana }
            };

            var listaCursos = new List<Curso>(){
                new Curso() { Nombre = "401", Jornada= TiposJornada.Manana },
                new Curso() { Nombre = "501", Jornada= TiposJornada.Manana },
                new Curso { Nombre = "501", Jornada= TiposJornada.Tarde }
            };
            //escuela.Cursos.Clear();
            //
            escuela.Cursos.Add(new Curso { Nombre = "102", Jornada = TiposJornada.Tarde });
            escuela.Cursos.Add(new Curso { Nombre = "202", Jornada = TiposJornada.Tarde });


            //escuela.Cursos.Remove(temp);

            //Other way to add a complete list to the Curses.
            escuela.Cursos.AddRange(listaCursos);
            Curso temp = new Curso { Nombre = "101-vacante", Jornada = TiposJornada.Noche };
            escuela.Cursos.Add(temp);
            ImprimirCursosEscuela(escuela);
            escuela.Cursos.Remove(temp);
            ImprimirCursosEscuela(escuela);

            //deleting course with a delegate method 
            //escuela.Cursos.RemoveAll(Predicado);

            //deleting course with a delegate
            escuela.Cursos.RemoveAll(delegate (Curso cur){
                return cur.Nombre =="301";
            });
            //Deleton with lambda expretion
            escuela.Cursos.RemoveAll((cur)=> cur.Nombre=="501" && cur.Jornada==TiposJornada.Manana);

            ImprimirCursosEscuela(escuela);
        }

        private static bool Predicado(Curso obj)
        {
            return obj.Nombre =="301";
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("================");
            WriteLine("Cursos de la Escuela");
            WriteLine("================");

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
                    WriteLine($"Nombre del Cruso: {curso.Nombre}, ID del Curso : {curso.UniqueId} , Tipo de Jornada : {curso.Jornada} ");
                }
            }

        }

        private static void ImprimirCursoForEach(Curso[] cursoarreglo)
        {
            WriteLine("Metodo ForEach");
            foreach (var curso in cursoarreglo)
            {
                WriteLine($"Nombre del Cruso: {curso.Nombre}, ID del Curso : {curso.UniqueId} ");
            }
        }

        private static void ImprimirCursoFor(Curso[] cursoarreglo)
        {
            WriteLine("Metodo For");
            for (int i = 0; i < cursoarreglo.Length; i++)
            {
                WriteLine($"Nombre del Cruso: {cursoarreglo[i].Nombre}, ID del Curso : {cursoarreglo[i].UniqueId} ");
            }
        }

        private static void ImprimirCursoDoWHile(Curso[] cursoarreglo)
        {
            WriteLine("Methodo DO-While");
            int cont = 0;
            do
            {


                WriteLine($"Nombre del Cruso: {cursoarreglo[cont].Nombre}, ID del Curso : {cursoarreglo[cont].UniqueId} ");
                cont++;

            } while (cont < cursoarreglo.Length);
        }

        private static void ImprimirCursosWhile(Curso[] cursoarreglo)
        {
            WriteLine("Methodo While");
            int cont = 0;

            while (cont < cursoarreglo.Length)
            {

                WriteLine($"Nombre del Cruso: {cursoarreglo[cont].Nombre}, ID del Curso : {cursoarreglo[cont].UniqueId} ");
                cont++;
            }

        }
    }
}
