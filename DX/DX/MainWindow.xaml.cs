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
        //Insert Accounts
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
        //Create Database
        static void CreateDatabase()
        {
            using var dbcontex = new DXSP();
            string dbname = dbcontex.Database.GetDbConnection().Database;
            dbcontex.Database.EnsureCreated();
        }
        //Drop Database
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
        private bool CheckUser(string username)
            {
                using var dbcontex = new DXSP();
                if (dbcontex.accounts.Any(a => a.Username == username))
                    {
                    return true;
                    }
                else
                {
                    return false;   
                }
            }
        private bool CheckPassword( string username,string password)
        {
            using var dbcontex = new DXSP();
            if(CheckUser(username))
            {
               var _account = dbcontex.accounts.FirstOrDefault(a => a.Username == username);
                if (_account.Password == password)
                {
                    return true;
                }
                
            }
            return false;
        }
        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            if (CheckUser(txtUsername.Text))
            {
                if(CheckPassword(txtUsername.Text,txtPassword.Password))
                {
                    Admin adminWindow = new Admin();
                    //this.Hide();
                    //adminWindow.ShowDialog();
                    //txtPassword.Clear();
                    //this.Show();
                    adminWindow.Closed += AdminWindow_Closed;
                    adminWindow.Show();
                    txtPassword.Clear();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu", "Lỗi đăng nhập", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }    
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập","Lỗi đăng nhập",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            
            
        }

        private void AdminWindow_Closed(object? sender, EventArgs e)
        {
            this.Show();
        }

        private void btnexit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}