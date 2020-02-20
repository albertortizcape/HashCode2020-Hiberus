using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode.Entities
{
    public class Library
    {
        public int LibraryId { get; set; }
        public List<Book> Libros { get; set; }

        // Número de días que cuesta realizar el registro de todos los libros
        public int DiasTotalesRegistro { get; set; }

        // Número de libros que puede enviar la librería por día
        public int NumeroLibrosEnvioDia { get; set; }

        public List<Book> OrderedBooksByScore()
        {
            // TODO: Aplicar algoritmo de ordenación sobre los libros de la librería

            return null;
        }
    }
}
