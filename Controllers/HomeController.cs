using System.Diagnostics;
using doanchuyennganh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using doanchuyennganh.Data;
using doanchuyennganh.ViewModels;
using static System.Reflection.Metadata.BlobBuilder;

namespace doanchuyennganh.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController>_logger;
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController>
            logger, ApplicationDbContext context, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        // Action mặc định cho trang Index
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSongs()
        {
            var songs = await _context.Nhacs
                .Include(n => n.TheloaiNhacs)
                .Select(n => new
                {
                    n.Id,
                    n.Ten,
                    n.Tacgia,
                    n.Anhbia,
                    n.Duongdan,
                    TheLoai = n.TheloaiNhacs.Ten
                })
                .ToListAsync();

            return Ok(songs);
        }

        // Lấy chi tiết bài nhạc theo Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSongById(int id)
        {
            var song = await _context.Nhacs
                .Include(n => n.TheloaiNhacs)
                .Select(n => new
                {
                    n.Id,
                    n.Ten,
                    n.Tacgia,
                    n.Anhbia,
                    n.Duongdan,
                    TheLoai = n.TheloaiNhacs.Ten
                })
                .FirstOrDefaultAsync(n => n.Id == id);

            if (song == null)
            {
                return NotFound("Bài nhạc không tồn tại.");
            }

            return Ok(song);
        }
        // Action tìm kiếm sách

        public IActionResult SearchBook(string keyword)
        {
            {
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    return View("SearchResults", new List<Sach>());
                }

                // Tìm kiếm sách theo tên hoặc tác giả có chứa từ khóa
                var sachs = _context.Saches
                    .Where(b => b.Ten.Contains(keyword) || b.Tacgia.Contains(keyword))
                    .ToList();

                return View("SearchResults", sachs);
            }
        }


        // Các action khác không thay đổi
        public async Task<IActionResult> Book(int? categoryId)
        {
            // Lấy danh sách thể loại
            var theloais = _context.Theloais.ToList();
            var sach = _context.Saches.ToList();

            // Nếu có thể loại được chọn, lọc sách theo thể loại đó
            var saches = categoryId.HasValue
                ? _context.Saches.Where(s => s.TheloaiId == categoryId.Value).ToList()
                : _context.Saches.ToList();

            // Tạo ViewModel
            var viewModel = new BookViewModel
            {
                Saches = saches,
                Theloais = theloais,
                SelectedTheloaiId = categoryId // Truyền categoryId vào ViewModel
            };

            return View("Book", viewModel);
        }
        public async Task<IActionResult> BookDetail(int id)
        {
            var sach = await _context.Saches
             .Include(s => s.Theloai)  // Bao gồm thông tin thể loại nếu cần
             .FirstOrDefaultAsync(s => s.Id == id);

            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }
        public async Task<IActionResult> NhacDetail(int id)
        {
            var nhac = await _context.Nhacs
            .Include(s => s.TheloaiNhacs)  // Bao gồm thông tin thể loại nếu cần
            .FirstOrDefaultAsync(s => s.Id == id);

            if (nhac == null)
            {
                return NotFound();
            }

            return View(nhac);
        }
        public IActionResult Reading(int id)
        {
            var book = _context.Saches.FirstOrDefault(s => s.Id == id);
            if (book == null || string.IsNullOrEmpty(book.PdfFilePath) || book.PdfFilePath == "No PDF available")
            {
                return NotFound(); // Nếu không tìm thấy sách hoặc không có PDF, trả về 404
            }

            // Lấy đường dẫn tuyệt đối tới file PDF
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdfs", book.PdfFilePath);

            // Kiểm tra xem file có tồn tại không
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("PDF file not found.");
            }

            // Trả về view với đường dẫn PDF
            ViewBag.PdfFilePath = filePath;
            return View(book);
        }



        public async Task<IActionResult> Music(int? categoryId)
        {
            var viewModel = new NhacModel
            {
                TheLoaiNhacs = await _context.TheloaiNhacs.ToListAsync(), // Lấy danh sách thể loại nhạc
                Nhacs = categoryId.HasValue
                    ? await _context.Nhacs.Where(n => n.TheloaiId == categoryId).ToListAsync()
                    : await _context.Nhacs.ToListAsync() // Lấy danh sách nhạc theo thể loại hoặc toàn bộ
            };

            return View(viewModel);
        }
        
   

        public IActionResult News() => View();
        public IActionResult Player() => View();
        public IActionResult Podcast() => View();
        public IActionResult Profile() => View();
        public IActionResult Ranking() => View();
        public IActionResult signup() => View();
        public IActionResult Story() => View();
        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
