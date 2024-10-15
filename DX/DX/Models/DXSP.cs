using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Models
{
    /// <summary>
    /// 1.Để biểu diễn một cơ sở dữ liệu ta tạo ra một lớp kế thừa từ Dbcontext
    /// 2.Nạp chông phương thức OnConfiguring để cấu hình kết nối đến Database
    /// 3.Gọi phương thức optionsBuilder.UseSqlServer(); để cho biết lớp DXSP làm việc với SQL Server -> cần chuỗi kết nối đến SQL Server
    /// 4.Đến đây có thể qua MainWindow tạo một phương thức Create Database
    /// 5.
    /// </summary>

    public class DXSP : DbContext
    {
        //Khai báo chuỗi kết nối đến SQL Serve

        ////**************connectionString for Home******************
        //private const string connectionString = @"
        //                                        Server=DESKTOP-7E0C4GH\SQLEXPRESS;
        //                                        Initial Catalog=DXSP;
        //                                        User ID=sa;
        //                                        Password=binbong1215;
        //                                        TrustServerCertificate=True;";
        //**************connectionString for Uni******************
        private const string connectionString = @"
                                                Server=SERVER3\SQLEXPRESS;
                                                Initial Catalog=DXSP;
                                                User ID=sa;
                                                Password=2911;
                                                TrustServerCertificate=True;";
        //Khai báo một Table Account trong CSDL DXSP
        public DbSet<Account> accounts { get; set; }
        //Khai báo một Table XuatNL
        public DbSet<XuatNL> xuatNLs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
