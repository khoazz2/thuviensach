using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace doanchuyennganh.Models
{
    public class Theloai
    {
        [Key]
        public int Id { get; set; } // ID của thể loại

        [Required]
        [StringLength(100)]
        public string Ten { get; set; } // Tên thể loại

        [StringLength(500)]
        public string Mota { get; set; } // Mô tả thể loại

        // Liên kết với Sách
        public ICollection<Sach> Saches { get; set; }
    }
}
