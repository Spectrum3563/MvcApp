using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Model;
using Microsoft.EntityFrameworkCore;

namespace MyMvcApp.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }

        // 1. Hiển thị Danh sách Book
        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

        // 2. Tìm kiếm thông tin về Book theo Title
        [HttpPost]
        public IActionResult Search(string title)
        {
            var books = _context.Books
                .Where(b => b.Title.Contains(title))
                .ToList();
            return View("Index", books);
        }

        // 3. Hiển thị danh sách Book và Review
        public IActionResult ListWithReviews()
        {
            var books = _context.Books
                .Include(b => b.Reviews)
                .ToList();
            return View(books);
        }

        // 4. Hiển thị danh sách Book và Author, sắp xếp theo Order
        public IActionResult ListWithAuthors()
        {
            var books = _context.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .OrderBy(ba => ba.BookAuthors.FirstOrDefault().Order)
                .ToList();
            return View(books);
        }

        // 5. Hiển thị danh sách Book với Title, Price, và số lượng Review
        public IActionResult ListWithReviewCount()
        {
            var books = _context.Books
                .Select(b => new
                {
                    b.Title,
                    b.Price,
                    NumberReviews = b.Reviews.Count
                })
                .ToList();

            return View(books);
        }
    }
}
