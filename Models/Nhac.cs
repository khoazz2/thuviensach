using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace doanchuyennganh.Models
{
    public class Nhac
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Ten { get; set; }

        [Required]
        [StringLength(100)]
        public string Tacgia { get; set; }

        [StringLength(2000)]
        public string Mota { get; set; } = "Chưa có mô tả";

        public string Anhbia { get; set; }

        [ForeignKey("TheloaiNhac")]
        public int TheloaiId { get; set; }
        public TheLoaiNhac TheloaiNhacs { get; set; }

        [Required]
        public string? Duongdan { get; set; } // Đường dẫn file nhạc
    }
}
