using System;

namespace CoreEscuela.Entidades
{
    // Al hacer que esta clase se Abstracta, no se puede instanciar, Solo sirve para heredar a las otras clases.
    public abstract class ObjetoEscuelaBase
    {
        public string Nombre { get; set; }
        public string UniqueId { get; private set; }

        public ObjetoEscuelaBase(){
            this.UniqueId = Guid.NewGuid().ToString();
        }

        //Todos los metodos tienene la clase override, al retornar va a mostrar en las variables, clases hijas etc estos dos atributos {Nombre, {UniqueId}}
        public override string ToString()
        {
            return $"{Nombre}, {UniqueId}";
        }
    }
}