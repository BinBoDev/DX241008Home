using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Models
{
    [Table("XuatNL")]
    public class XuatNL
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CodeNL { get; set; }
        [Required]
        [StringLength(50)]
        public String TenNL { get; set; }
        public int Soluongxuat { get; set; }
        [Required]
        public DateTime Ngaygioxuatthucte { get; set; }
        [Required]
        [StringLength(6)]
        public string KehoachThangNam { get; set; }
        [Required]
        [StringLength(20)]
        public string Index { get; set; }
        public string? Xuatkhosanxuatngay { get; set; }
    }
}
