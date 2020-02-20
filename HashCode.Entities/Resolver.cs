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

        public void ReadDefineLibrary(string linea, int libraryId)
        {
            string[] dta = linea.Split(' ');
            int numeroLibro = int.Parse(dta[0]);
            int numeroDias = int.Parse(dta[1]);
            int numeroEnvio = int.Parse(dta[2]);

            Library libra = new Library();
            libra.LibraryId = libraryId;

            libra.NumeroLibrosEnvioDia = numeroEnvio;
            libra.DiasTotalesRegistro = numeroDias;

            Libraries.Add(libra);

            Console.WriteLine(numeroLibro + " " + numeroDias);
        }

        public void ReadBooksId(string booksId, int libraryId)
        {
            // En la última librería, añadir los libros del array de libros

            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss") + " Get Library " + libraryId);
            var library = Libraries[libraryId];
            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss") + " Get Library " + libraryId);

            library.Libros = new List<Book>();

            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss") + " split");
            string[] dta = booksId.Split(' ');
            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss") + " end split");

            for (int i = 0; i <= dta.Length-1; i++)
            {
                var book = BookList.FirstOrDefault(b => b.Id == int.Parse(dta[i]));

                if (book != null)
                {
                    library.Libros.Add(book);
                }
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
                if (i < lib.Libros.Count())
                {
                    var book = lib.LibrosOrdenados[i];
                    totalBooksScanned.Add(book);
                }
                else 
                {
                    break;
                }
                
         
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
            int totaldays = DiasEscaneo;
            List<Library> librarys = new List<Library>();
            bool primero = false;
            //contador que lleva la posicion
            int contstart = 0;

            foreach(Library lib in Libraries)
            {
                if (!primero)
                {
                    if(lib.DiasTotalesRegistro <= totaldays)
                    {
                        lib.StartDay = contstart;
                        contstart += lib.DiasTotalesRegistro;
                        librarys.Add(lib);
                        primero = true;
                        totaldays -= lib.DiasTotalesRegistro;
                    }
                   
                }
                else if(totaldays > 0)
                {
                    if(totaldays - lib.DiasTotalesRegistro>=0)
                    {
                        lib.StartDay = contstart;
                        contstart += lib.DiasTotalesRegistro;
                        librarys.Add(lib);
                        primero = true;
                        totaldays -= lib.DiasTotalesRegistro;
                    }
                }
                else
                {
                    break;
                }
            }


            return librarys;
        }
    }
}
