using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode.Entities
{
    public class Library
    {
        public List<Book> Libros { get; set; }

        // Número de días que cuesta realizar el registro de todos los libros
        public int DiasTotalesRegistro { get; set; }

        // Número de libros que puede enviar la librería por día
        public int NumeroLibrosEnvioDia { get; set; }

        public List<Book> OrderedBooksByScore()
        {
            // TODO: Aplicar algoritmo de ordenación sobre los libros de la librería
            List<Book> aux = new List<Book>();
            aux = Libros;
            Book libroTemporal = new Book();
            int t = Libros.Count();
            for (int i = 1; i < t; i++)
                for (int j = t - 1; j >= i; j--)
                {
                    if (aux.ElementAt(j).Puntuacion < aux.ElementAt(j-1).Puntuacion)
                    {
                        libroTemporal = aux.ElementAt(j);
                        aux.Insert(j, aux.ElementAt(j - 1));
                        aux.Insert(j-1, libroTemporal);
                    }
                }
            Libros = aux;
            return Libros;
        }
    }
}
