using System.Collections.Generic;
using CoreEscuela.Util;
namespace CoreEscuela.Entidades
{
    public class Escuela : ObjetoEscuelaBase, ILugar
    {
        public int AnoCreacion { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Direccion { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }

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
        public void LimpiarLugar()
        {
            Printer.DibujarLinea(30);
            System.Console.WriteLine("Limpiando Escuela...");
            foreach(var curso in Cursos){
                curso.LimpiarLugar();
            }
            Printer.DibujarLinea(30);
            System.Console.WriteLine($"Escuela {Nombre} limpiada");
            Printer.DibujarLinea(30);
        }

    }
}