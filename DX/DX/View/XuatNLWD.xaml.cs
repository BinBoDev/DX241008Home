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
            this.DataContext = new XuatNLVM();
        }
        // Tìm file để nhập
        #region Phóng to màn hình
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

        #endregion

    }
}
