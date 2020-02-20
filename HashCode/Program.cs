using HashCode.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            // string[] lines = System.IO.File.ReadAllLines(@"C:\a.txt");
            StreamReader sr = new StreamReader(@"C:\a.txt");

            System.Console.WriteLine("Contenido del archivo = ");


            //6 2 7
            //  1 2 3 6 5 4

            Resolver resolver = new Resolver();

            int cont = 0;
            int idLibreria = 0;
            string line;
            while((line = sr.ReadLine()) != null)
            {

                cont++;
          


                // primera linea
                if (cont == 1)
                {
                    resolver.ReadFirstLine(line);
                }
                // seguna linea 
                if (cont == 2)
                {
                    resolver.ReadScoreLine(line);
                }
                // tercera linea 
                if (cont == 3)
                {
                    Console.WriteLine(DateTime.Now.ToString("hh:mm:ss") + " start reading library " + idLibreria);
                    resolver.ReadDefineLibrary(line, idLibreria);
                    Console.WriteLine(DateTime.Now.ToString("hh:mm:ss") + " start reading library " + idLibreria);
                }
                // cuarta 
                if (cont == 4)
                {
                    Console.WriteLine(DateTime.Now.ToString("hh:mm:ss") + " start reading books " + idLibreria);
                    resolver.ReadBooksId(line, idLibreria);
                    Console.WriteLine(DateTime.Now.ToString("hh:mm:ss") + " end reading books " + idLibreria);
                }

                if (cont >= 4)
                {
                    cont = 2;
                    idLibreria++;
                    Console.WriteLine(DateTime.Now.ToString("hh:mm:ss") + " " + idLibreria);


                }
     
                // Use a tab to indent each line of the file.

            }

            sr.Dispose();

            Console.WriteLine("Fin lectura librerías, comienza la fiezzzzztaaaa!");

            string file = resolver.Result();

            StreamWriter sw = new StreamWriter("salida.txt");
            sw.WriteLine(file);
            sw.Flush();
            sw.Dispose();

            Console.WriteLine("\t" + file);

            Console.ReadLine();
        }

        
    }
}
