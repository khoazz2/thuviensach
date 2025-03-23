using doanchuyennganh.Models;

namespace doanchuyennganh.Models
{
    public class NhacModel
    {
        public IEnumerable<TheLoaiNhac> TheLoaiNhacs { get; set; } // Danh sách thể loại nhạc
        public IEnumerable<Nhac> Nhacs { get; set; } // Danh sách bài nhạc
    }
}
