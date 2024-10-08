using DX.Models;
using DX.View;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 1.Tạo phương thức CreateDatabase
    /// 2.Tạo phương thức DropDatabase
    /// </summary>
    public partial class MainWindow : Window
    {
        static void InsertAccount()
        {
            using var dbContext = new DXSP();
            var account = new object[]
            {
                new Account() {Username = "p.tan@mpvuni.com.vn",Password="admin",Type = 1},
                new Account() {Username = "n.quang@mpvuni.com.vn",Password="admin",Type = 1},
                new Account() {Username = "p.diep@mpvuni.com.vn",Password="admin",Type = 1},
                new Account() {Username = "l.hoa@mpvuni.com.vn",Password="12345",Type = 2},
                new Account() {Username = "t.thuha@mpvuni.com.vn",Password="12345",Type = 2},
                new Account() {Username = "n.dung@mpvuni.com.vn",Password="12345",Type = 2}
            };
            dbContext.AddRange(account);
            dbContext.SaveChanges();
        }
        static void CreateDatabase()
        {
            using var dbcontex = new DXSP();
            string dbname = dbcontex.Database.GetDbConnection().Database;
            dbcontex.Database.EnsureCreated();
        }
        static void DropDatabase()
        {
            using var dbcontex = new DXSP();
            string dbname = dbcontex.Database.GetDbConnection().Database;
            dbcontex.Database.EnsureDeleted ();
        }
        public MainWindow()
        {
            InitializeComponent();
            //CreateDatabase();
            //DropDatabase();
            //InsertAccount();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            Admin adminWindow = new Admin();
            this.Hide();
            adminWindow.Show();
            this.Show();
            
        }

        private void btnexit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}