using SACC.Data;
using SACC.Models;
using SACC.Repositories.Interfaces;

namespace SACC.Repositories {
    public class BookRepository : IBookRepository {

        private readonly Contents _content;

        public BookRepository(Contents content) {
            _content = content;
        }

        public IEnumerable<Book> Books => _content.Books;

        public Book GetBookId(int id) {
            return _content.Books.FirstOrDefault(x => x.BookId == id);
        }

        public Book GetLivro(string book) {
            return _content.Books.FirstOrDefault(b => b.Title == book);
        }
    }
}
