using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace DX.Models
{
    /// <summary>
    /// 1.Tạo một lớp Account được coi là một Table trong DXSP
    /// 2.Sử dụng thuộc tính Table để tạo một bảng
    /// </summary>
    /// 

    [Table("Account")]
    public class Account
    { 
        
        [Key] //Thuộc tính Key của trường Id
        public int Id { get; set; }
        [Required] // Khác NULL
        [StringLength(30)] // Trường Usernam có kiểu nVarchar(50)

        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        public int Type { get; set; }

}
}
