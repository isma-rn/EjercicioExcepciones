using System;
using System.Diagnostics;

namespace PruebaExcepciones
{
    class Program
    {
        static void Main(string[] args)
        {            
            int limite = 4500;
            IniciarPruebaEvitandoExcepciones(limite);
            IniciarPruebaLanzandoExcepciones(limite);                        
            Console.ReadLine();
        }

        public static void IniciarPruebaLanzandoExcepciones(int limite)
        {
            Console.WriteLine("Iniciando \"Lanzando Excepciones\", limite = {0}", limite);            
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < limite; i++)
            {                
                try
                {
                    throw new Exception();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Lanzando {0}", i);
                    Console.SetCursorPosition(0, Console.CursorTop-1);
                }
            }
            stopWatch.Stop();
            Console.WriteLine("\tFinalizado " + ObtenerFormatoTiempo(stopWatch.Elapsed));
        }

        public static void IniciarPruebaEvitandoExcepciones(int limite)
        {
            Console.WriteLine("Iniciando \"Evitando Excepciones\", limite = {0}", limite);
            Stopwatch stopWatch = new Stopwatch();            
            stopWatch.Start();
            for (int i = 0; i < limite; i++)
            {                
                if (int.TryParse("hola", out int x))
                {

                }
                else
                {
                    Console.WriteLine("Evitando {0}", i);
                    Console.SetCursorPosition(0, Console.CursorTop-1);
                }
            }
            stopWatch.Stop();
            Console.WriteLine("\tFinalizado en " + ObtenerFormatoTiempo(stopWatch.Elapsed));
        }

        public static string ObtenerFormatoTiempo(TimeSpan ts)
        {
            return String.Format("{0:00}h:{1:00}m:{2:00}s.{3:00}ms", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        }
    }
}