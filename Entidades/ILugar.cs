namespace CoreEscuela.Entidades
{
    //Una Interfaz es una definicion de la estructura que debe tener un Objeto.
    //Una Interfaz tods los atributos son publicos
    public interface ILugar
    {
        string Direccion { get; set; }
        void LimpiarLugar();
    }
}