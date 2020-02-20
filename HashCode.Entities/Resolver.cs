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
        public List<Library> Libraries { get; set; }
        public int DiasEscaneo { get; set; }

        public List<Book> BookList;

        public Resolver()
        {
         
        }
        public void ReadFirstLine(string firstLine)
        {
            string[] dta = firstLine.Split(' ');
            NumeroLibros = int.Parse(dta[0]);
            int numLibraries = int.Parse(dta[1]);

            Libraries = new List<Library>();
            DiasEscaneo = int.Parse(dta[2]);
        }

        public void ReadScoreLine(string secondLine)
        {
            BookList = new List<Book>();

            string[] dta = secondLine.Split(' ');
            for (int i = 0; i < dta.Length-1; i++)
            {
                var book = new Book();
                book.Id = i;
                book.Puntuacion = int.Parse(dta[i]);

                BookList.Add(book);
            }
        }

        public void ReadDefineLibrary(string linea)
        {
            string[] dta = linea.Split(' ');
            int numeroLibro = int.Parse(dta[0]);
            int numeroDias = int.Parse(dta[1]);
            int numeroEnvio = int.Parse(dta[2]);

            Library libra = new Library();
            libra.NumeroLibrosEnvioDia = numeroEnvio;
            libra.DiasTotalesRegistro = numeroDias;

            Libraries.Add(libra);
        }

        public void ReadBooksId(string booksId, int libraryId)
        {
            // En la última librería, añadir los libros del array de libros
          
            var library = Libraries[libraryId];
            library.Libros = new List<Book>();

            string[] dta = booksId.Split(' ');
            for (int i = 0; i <= dta.Length-1; i++)
            {
                var book = BookList.FirstOrDefault(b => b.Id == int.Parse(dta[i]));
           
                library.Libros.Add(book);
            }
        }

        public string Result()
        {
            StringBuilder sb = new StringBuilder();

            List<Library> librariesThatWillBeScanned = GetOptimizedLibrariesPerDays();

            // Primera respuesta: Numero de librerías que se pueden escanear
            sb.AppendLine(librariesThatWillBeScanned.Count.ToString());

            // Resto de respuesta:
            GetRestOfTheFile(sb, librariesThatWillBeScanned);

            return sb.ToString();
        }

        private void GetRestOfTheFile(StringBuilder sb, List<Library> librariesThatWillBeScanned)
        {
            foreach (Library lib in librariesThatWillBeScanned)
            {
                GetLibraryString(sb, lib);
            }
        }

        private void GetLibraryString(StringBuilder sb, Library lib)
        {
            int numDaysFromSignedUp = lib.StartDay;
            List<Book> librosEscanear = BooksThatWillBeScannedFromLibrary(numDaysFromSignedUp, lib);

            GetFirstLineFromLibrary(sb, lib.LibraryId, librosEscanear);

            GetSecondLineFromLibrary(sb, librosEscanear);
        }

        private List<Book> BooksThatWillBeScannedFromLibrary(int numDaysFromSignedUp, Library lib)
        {
            int numTotalDays = DiasEscaneo - numDaysFromSignedUp;
            int numTotalBooks = numTotalDays * lib.NumeroLibrosEnvioDia;

            List<Book> totalBooksScanned = new List<Book>();
            for (int i = 0; i <= numTotalBooks; i++)
            {
                var book = lib.Libros[i];
                totalBooksScanned.Add(book);
            }

            return totalBooksScanned;
        }

        private void GetSecondLineFromLibrary(StringBuilder sb, List<Book> librosEscanear)
        {
            foreach (Book book in librosEscanear)
            {
                sb.Append(book.Id);
                sb.Append(" ");
            }

            sb.AppendLine();
        }

        private void GetFirstLineFromLibrary(StringBuilder sb, int libraryId, List<Book> librosEscanear)
        {
            sb.Append(libraryId);
            sb.Append(" ");
            sb.AppendLine(librosEscanear.Count.ToString());
        }

        private List<Library> GetOptimizedLibrariesPerDays()
        {
            // Coger el número de días que tengo totales
            // Recorrer todas las librerías e ir descontando tiempo hasta que el resultado sea 0 (nunca menor que 0)
            // Devolver las librerías que se pueden escanear en esos días
            throw new NotImplementedException();
        }
    }
}
