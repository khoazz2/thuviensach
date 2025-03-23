using doanchuyennganh.Models;

namespace doanchuyennganh.ViewModels
{
    public class BookViewModel
    {
        // Danh sách sách
        public List<Sach> Saches { get; set; }

        // Danh sách thể loại
        public List<Theloai> Theloais { get; set; }

        // Chứa thông tin về thể loại sách được lọc
        public int? SelectedTheloaiId { get; set; }
    }
}
