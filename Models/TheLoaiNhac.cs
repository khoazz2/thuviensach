using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace doanchuyennganh.Models
{
    public class TheLoaiNhac
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Ten { get; set; }

        public ICollection<Nhac> Nhacs { get; set; }
    }
}
