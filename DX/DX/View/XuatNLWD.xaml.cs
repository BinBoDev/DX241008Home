using DX.ViewModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DX.View
{
    /// <summary>
    /// Interaction logic for XuatNL.xaml
    /// </summary>
    public partial class XuatNLWD : Window
    {
        public XuatNLWD()
        {
            InitializeComponent();
            DataContext = new XuatNLVM();
        }
        // Tìm file để nhập
        private void btnSearchFile_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Title = "Tìm file";
            //openFileDialog.Filter = "Excel Files (*.xlsx;*.xls)|*.xlsx;*.xls";
            //if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    // Lấy đường dẫn file và hiển thị trong TextBox
            //    txtFilePath.Text = openFileDialog.FileName;
            //}
        }
        //Nhập file vào CSDL
        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }
    }
}
