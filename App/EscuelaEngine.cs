using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    //sealed permite que se creen instancias de esta clase, pero no deja que otros Objetos Herenden de esta.
    public sealed class EscuelaEngine
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
        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {
            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();
            diccionario.Add(LlaveDiccionario.Escuela, new[] { escuela });
            diccionario.Add(LlaveDiccionario.Cursos, escuela.Cursos.Cast<ObjetoEscuelaBase>());
            var listatmpEva = new List<Evaluacion>();
            var listatmpAlunm= new List<Alumno>();
            var listatmpAsig= new List<Asignatura>();
            foreach (var curso in escuela.Cursos)
            {
                listatmpAlunm.AddRange(curso.Alumnos);
                listatmpAsig.AddRange(curso.Asignaturas);
                foreach (var alunm in curso.Alumnos)
                {
                    listatmpEva.AddRange(alunm.Evaluaciones);
                }
                
            }
            diccionario.Add(LlaveDiccionario.Asignaturas, listatmpAsig.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Alumnos, listatmpAlunm.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Evaluaciones, listatmpEva.Cast<ObjetoEscuelaBase>());


            return diccionario;
        }
        //Parametros no oblicatorios, al no ser a~adidos los parametros cuando se llama el metodo por defecto los va a poner como true como se ve en el metodo de abajo o si no agregar otro valor del parametro cuando se llama desde otro lugar.
        public List<ObjetoEscuelaBase> GetObjetoEscuela(
            out int contEva,
            out int contAlumn,
            out int contAsig,
            out int contCursos,
            bool traerEvaluaciones = true,
            bool traerAlumnos = true,
            bool traerAsiganaturas = true,
            bool traerCursos = true)
        {
            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(escuela);
            listaObj.AddRange(escuela.Cursos);
            contAsig = 0;
            contAlumn = 0;
            contEva = 0;
            contCursos = 0;
            if (traerCursos)
            {
                contCursos = escuela.Cursos.Count;
                foreach (var curso in escuela.Cursos)
                {
                    contAsig += curso.Asignaturas.Count;
                    contAlumn += curso.Alumnos.Count;
                    if (traerAsiganaturas)
                    {

                        listaObj.AddRange(curso.Asignaturas);

                    }
                    if (traerAlumnos)
                    {
                        listaObj.AddRange(curso.Alumnos);

                    }
                    if (traerEvaluaciones)
                    {
                        foreach (var alumno in curso.Alumnos)
                        {
                            listaObj.AddRange(alumno.Evaluaciones);
                            contEva += alumno.Evaluaciones.Count();
                        }
                    }

                }
            }

            return listaObj;
        }

        #region Metodos de carga
        private void CargarEvaluaciones()
        {
            var lista = new List<Evaluacion>();
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
        #endregion


    }
}