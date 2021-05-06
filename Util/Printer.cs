using static System.Console;
namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void DibujarLinea(int n=10){
            var linea="".PadLeft(n, '=');
            WriteLine(linea);

        }
        public static void WriteTitle(string title){
            var size= title.Length + 4;
            DibujarLinea(size);
            WriteLine($"| {title} |");
            DibujarLinea(size);

        }        
    }
}