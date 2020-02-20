﻿using HashCode.Entities;
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
            string[] lines = System.IO.File.ReadAllLines(@"C:\ruta\archivo.txt");
            System.Console.WriteLine("Contenido del archivo = ");


            //6 2 7
            //  1 2 3 6 5 4

            Resolver resolver = new Resolver();

            int cont = 0;
            foreach (string line in lines)
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
                    resolver.ReadScoreLine(line);
                }
                // cuarta 
                if (cont == 4)
                {
                    resolver.ReadScoreLine(line);
                }

                if (cont > 4)
                {
                    cont = 2;
                }








                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
            }
        }

        
    }
}
