using DX.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DX.View
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            DataContext = new  AccountVM();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AccountManager accountManager = new AccountManager();
            //this.Hide();
            //accountManager.ShowDialog();
            //this.Show();
            accountManager.Closed += AccountManager_Closed;
            accountManager.Show();
            this.Hide();
        }

        private void AccountManager_Closed(object? sender, EventArgs e)
        {
            this.Show();
        }

        private void XuatNL_Click(object sender, RoutedEventArgs e)
        {
            XuatNLWD xuatNL = new XuatNLWD();
            xuatNL.Closed += XuatNL_Closed;
            xuatNL.Show();
            this.Hide();

        }

        private void XuatNL_Closed(object? sender, EventArgs e)
        {
            this.Show();
        }

        private void NextPageDataSainpen(object sender, RoutedEventArgs e)
        {
            DataSPWD dataSPWD = new DataSPWD();
            dataSPWD.Closed += DataSPWD_Closed;
            dataSPWD.Show();
            this.Hide();
        }

        private void DataSPWD_Closed(object? sender, EventArgs e)
        {
            this.Show();
        }
    }
    //public class BoolToIntConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        if (value is int intValue && parameter is string stringParameter && int.TryParse(stringParameter, out int paramValue))
    //        {
    //            return intValue == paramValue;
    //        }
    //        return false;
    //    }
        
    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        return (bool)value ? int.Parse(parameter.ToString()) : 0;
    //    }
    //}
}
