using System.Threading.Tasks;
using Lab3_LeChiCuong_2131200001.Data;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Lab3_LeChiCuong_2131200001.Controllers
{
    public class BookController : Controller
    {

        private readonly AppDbContext _context;

        private readonly IWebHostEnvironment _env;

        public BookController(AppDbContext context, IWebHostEnvironment env)
        {

            _context = context;
            _env = env;

        }

        public async Task<IActionResult> Index([FromQuery] string bookCode)
        {
            Console.WriteLine("Code: " + bookCode);
            var book = await _context.Books
                .Include(book => book.Categories)
                .FirstOrDefaultAsync(book => book.BookCode == bookCode);
            return View(book);
        }

        public async Task<IActionResult> PageProgrammingBook()
        {

            var books = await _context.Books
                  .Include(category => category.Categories)
                  .Where(book => book.Categories.Any(cate => cate.Name == "Programming"))
               .ToListAsync();
            return View(books);
        }

        public async Task<IActionResult> PageFictionBook()
        {

            var books = await _context.Books
                  .Include(category => category.Categories)
                  .Where(book => book.Categories.Any(cate => cate.Name == "Fiction"))
               .ToListAsync();
            return View(books);
        }

        public async Task<IActionResult> ViewPDF([FromQuery] string bookCode)
        {

            var book = await _context.Books
                .Include(book => book.Categories)
                .FirstOrDefaultAsync(book => book.BookCode == bookCode);

            if (book == null)
            {
                ViewBag.Error = true;
                ViewBag.ErrorMessage = "PDF path does not exist";
            }
            else
            {
                if (!System.IO.File.Exists(_env.WebRootPath + "/assets/pdf/" + book.Pdf))
                {
                    ViewBag.Error = true;
                    ViewBag.ErrorMessage = "PDF path does not exist";
                } else
                {
                    ViewBag.Error = false;
                }
            }
            return View(book);
        }

    }
}
