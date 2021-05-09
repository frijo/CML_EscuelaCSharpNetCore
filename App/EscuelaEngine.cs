using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
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

            this.CargarCursos();
            CargarAsignaturas();


            CargarEvaluaciones();
        }

        private void CargarEvaluaciones()
        {
            foreach (var curso in escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alunmo in curso.Alumnos)
                    {
                        var rnd = new Random();
                        for (int i = 0; i < 3; i++)
                        {
                            var ev = new Evaluacion
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alunmo
                            };
                            alunmo.Evaluaciones.Add(ev);
                        }
                    }

                }

            }
        }

        private void CargarAsignaturas()
        {

            foreach (var curso in escuela.Cursos)
            {

                List<Asignatura> listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre="Matematicas"},
                    new Asignatura{Nombre="Educacion Fisica"},
                    new Asignatura{Nombre="Castellano"},
                    new Asignatura{Nombre="Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;

            }
        }

        private List<Alumno> GeneararAlumnosRandom(int cantidad)
        {
            string[] nombre = { "Steve", "Karol", "David", "Melany", "Carlos", "Cristina" };
            string[] apellido = { "Mclarend", "Alpizar", "Solis", "Rojas", "Villagran", "Duran" };
            string[] nombre2 = { "Fabricio", "Tatiana", "Jose", "Jimena", "Manuel", "Maria" };

            var listaAlumnos = from n1 in nombre
                               from n2 in nombre2
                               from a1 in apellido
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };
            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            escuela.Cursos = new List<Curso>(){
                new Curso() { Nombre = "101", Jornada= TiposJornada.Manana },
                new Curso() { Nombre = "201", Jornada= TiposJornada.Manana },
                new Curso() { Nombre = "301", Jornada= TiposJornada.Manana },
                new Curso() { Nombre = "401", Jornada= TiposJornada.Manana },
                new Curso() { Nombre = "501", Jornada= TiposJornada.Manana }
            };
            Random rdn = new Random();

            foreach (var curso in escuela.Cursos)
            {
                int cant = rdn.Next(5, 20);
                curso.Alumnos = GeneararAlumnosRandom(cant);
            }
        }

    }
}