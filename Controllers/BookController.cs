using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SACC.Data;
using SACC.Models;
using SACC.Repositories.Interfaces;

namespace SACC.Controllers {
    public class BookController : Controller {

        private readonly IBookRepository _bookRepository;
        private readonly Contents _context;
        private string _filePath;

        public BookController(IBookRepository bookRepository, Contents context, IWebHostEnvironment env) {
            _bookRepository = bookRepository;
            _context = context;
            _filePath = env.WebRootPath;
        }

        // GET: Book/List
        [HttpGet("book")]
        public IActionResult Index() {
            var books = _bookRepository.Books;
            return View(books);
        }

        // GET: Book/Title
        [HttpGet("book/viewBook/{id}")]
        public IActionResult ViewBook([FromRoute] int id) {
            var book = _bookRepository.GetBookId(id);
            return View(book);
        }

        // GET: Book/Create
        [HttpGet("book/create")]
        public IActionResult Create() {
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("book/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Title,Description,Image,BookFile")] Book book, IFormFile fileImage, IFormFile fileBook) {
            if (ModelState.IsValid) {

                if (!Helpers.Validation.ValidaImagem(fileImage)) {
                    return View(book);
                }

                if (!Helpers.Validation.ValidaPdf(fileBook)) {
                    return View(book);
                }

                var nomeImagem = Helpers.Upload.SalvarImagem(fileImage, _filePath);
                book.Image = nomeImagem;

                var nomePdf = Helpers.Upload.SalvarPdf(fileBook, _filePath);
                book.BookFile = nomePdf;

                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Book/Edit/5
        [HttpGet("book/edit/{id}")]
        public async Task<IActionResult> Edit(int? id) {
            if (id == null || _context.Books == null) {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null) {
                return NotFound();
            }
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("book/edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Title,Description,Image,BookFile")] Book book, IFormFile fileImage, IFormFile fileBook) {
            if (id != book.BookId) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    if (!Helpers.Validation.ValidaImagem(fileImage)) {
                        return View(book);
                    }

                    if (!Helpers.Validation.ValidaPdf(fileBook)) {
                        return View(book);
                    }

                    string imagePathName = _filePath + "\\images\\" + book.Image;
                    string filePathName = _filePath + "\\pdf\\" + book.BookFile;
                    if (System.IO.File.Exists(imagePathName)) {
                        System.IO.File.Delete(imagePathName);
                    }
                    if (System.IO.File.Exists(filePathName)) {
                        System.IO.File.Delete(filePathName);
                    }

                    var nomeImagem = Helpers.Upload.SalvarImagem(fileImage, _filePath);
                    book.Image = nomeImagem;

                    var nomePdf = Helpers.Upload.SalvarPdf(fileBook, _filePath);
                    book.BookFile = nomePdf;

                    _context.Update(book);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!BookExists(book.BookId)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Book/Delete/5
        [HttpGet("book/delete/{id}")]
        public async Task<IActionResult> Delete(int? id) {
            if (id == null || _context.Books == null) {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null) {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost("book/delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromRoute] int id) {
            if (_context.Books == null) {
                return Problem("Entity set 'Contents.Books'  is null.");
            }
            var book = _bookRepository.GetBookId(id);

            string imagePathName = _filePath + "\\images\\" + book.Image;
            string filePathName = _filePath + "\\pdf\\" + book.BookFile;
            if (System.IO.File.Exists(imagePathName)) {
                System.IO.File.Delete(imagePathName);
            }
            if (System.IO.File.Exists(filePathName)) {
                System.IO.File.Delete(filePathName);
            }

            if (book != null) {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id) {
            return (_context.Books?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}