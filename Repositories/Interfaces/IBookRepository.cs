using SACC.Models;

namespace SACC.Repositories.Interfaces {
    public interface IBookRepository {
        IEnumerable<Book> Books { get; }

        Book GetLivro(string book);

        Book GetBookId(int id);
    }
}
