using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Escuela
    {
        string nombre;
        string direcion;
        string CEO;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value.ToUpper(); }

        }
        public int AnoCreacion { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }

        public TiposEscuela TipoEscuela { get; set; }

        public List<Curso> Cursos{get;set;}

        public Escuela(string nombre, int ano)
        {
            this.Nombre = nombre;
            this.AnoCreacion = ano;
        }
        public Escuela(string nombre, int anocreacion, TiposEscuela tipo, string pais = "", string ciudad = "")
        {
            this.Nombre = nombre;
            this.AnoCreacion = anocreacion;
            this.TipoEscuela = tipo;
            this.Pais = pais;
            this.Ciudad = ciudad;
        }
        public override string ToString()
        {
            return $"Nombre: {Nombre}, Tipo: {TipoEscuela}\n Pais: {Pais}, Cuidad: {Ciudad}";
        }
    }
}