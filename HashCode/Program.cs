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
            StreamReader sr = new StreamReader("");
            string linea;
            int numLinea=0;
            while((linea=sr.ReadLine()) != null)
            {
                numLinea++;
            }
        }
    }
}
