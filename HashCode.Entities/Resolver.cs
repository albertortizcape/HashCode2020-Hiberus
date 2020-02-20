using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode.Entities
{
    public class Resolver
    {
        public int NumeroLibros { get; set; }
        public Library[] Libraries { get; set; }
        public int DiasEscaneo { get; set; }

        public List<Book> BookList;

        public void ReadFirstLine(string firstLine)
        {
            string[] dta = firstLine.Split(' ');
            NumeroLibros = int.Parse(dta[0]);
            int numLibraries = int.Parse(dta[1]);

            Libraries = new Library[numLibraries];
            DiasEscaneo = int.Parse(dta[2]);
        }

        public void ReadScoreLine(string secondLine)
        {
            BookList = new List<Book>();

            string[] dta = secondLine.Split(' ');
            for (int i = 0; 0 < dta.Length; i++)
            {
                var book = new Book();
                book.Id = i;
                book.Puntuacion = int.Parse(dta[i]);

                BookList.Add(book);
            }
        }

        public void ReadDefineLibrary()
        {

        }

        public void ReadBooksId(string booksId, int libraryId)
        {
            // En la última librería, añadir los libros del array de libros
            var library = Libraries[libraryId];

            string[] dta = booksId.Split(' ');
            for (int i = 0; i < dta.Length; i++)
            {
                var book = BookList.FirstOrDefault(b => b.Id == int.Parse(dta[i]));
                library.Libros.Add(book);
            }
        }

        public void Result()
        {
            
        }
    }
}
