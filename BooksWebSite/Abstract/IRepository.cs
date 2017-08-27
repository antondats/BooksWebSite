using BooksWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWebSite.Abstract
{
    public interface IRepository
    {
        IEnumerable<Book> Books { get; }
        IEnumerable<Magazine> Magazines { get; }
        IEnumerable<Brochure> Brochures { get; }

        IEnumerable<Wastepaper> GetAllSubjects();

        void SaveBook(Book book);
        Book DeleteBook(int bookId);

        void SaveMagazine(Magazine magazine);
        Magazine DeleteMagazine(int magazineId);

        void SaveBrochure(Brochure brochure);
        Brochure DeleteBrochure(int brochureId);
    }
}
