using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doanchuyennganh.Models
{
    public class Sach
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Đảm bảo Id tự động tăng
        public int Id { get; set; } // ID của sách

        [Required]
        [StringLength(200)]
        public string Ten { get; set; } // Tên sách

        [Required]
        [StringLength(100)]
        public string Tacgia { get; set; } // Tác giả

        [StringLength(2000)]
        public string Mota { get; set; } = "Chưa có mô tả";  // Giá trị mặc định

        public string Anhbia { get; set; } // Ảnh bìa sách

        // Liên kết với thể loại
        [ForeignKey("Theloai")]
        public int TheloaiId { get; set; } // ID thể loại
        public Theloai Theloai { get; set; }

        // Đường dẫn tệp PDF
        public string? PdfFilePath { get; set; } // Cho phép null
        public string? Duongdan { get; set; }
    }
}
