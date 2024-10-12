using DX.Commands;
using DX.Models;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace DX.ViewModel
{
    
    public class XuatNLVM : INotifyCollectionChanged
    {
        private readonly DXSP dbContex;
        //public ObservableCollection<XuatNL> XuatNLs { get; set; }

        public ICommand ImportCommand { get; set; }


        public XuatNLVM()
        {
            dbContex = new DXSP();
            ImportCommand = new RelayCommand(Importcmd);
        }

        //private bool CanImporcmd(object? obj)
        //{
        //    throw new NotImplementedException();
        //}

        private void Importcmd(object? obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Tìm file";
            openFileDialog.Filter = "Excel Files (*.xlsx;*.xls)|*.xlsx;*.xls";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Lấy đường dẫn file và hiển thị trong TextBox
                var filePath = openFileDialog.FileName;
                using(var stream = File.Open(filePath,FileMode.Open,FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        //var dataSet = reader.AsDataSet();
                        var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true // Sử dụng hàng đầu tiên làm hàng tiêu đề
                            }
                        });
                        var dataTable = dataSet.Tables[0];
                        //foreach (DataColumn column in dataTable.Columns)
                        //{
                        //    //Console.WriteLine(column.ColumnName); 
                        //    MessageBox.Show(column.ColumnName);
                        //}
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var xuatNL = new XuatNL()
                            {
                                CodeNL = row["CodeNL"] != DBNull.Value ? Convert.ToInt32(row["CodeNL"]) : throw new Exception("CodeNL không được trống"),
                                TenNL = row["TenNL"].ToString(),
                                Soluongxuat = row["Soluongxuat"] != DBNull.Value ? Convert.ToInt32(row["Soluongxuat"]) : 0,
                                Ngaygioxuatthucte = Convert.ToDateTime(row["Ngaygioxuatthucte"]),
                                KehoachThangNam = row["KehoachThangNam"].ToString(),
                                Index = row["Index"].ToString(),
                                Xuatkhosanxuatngay = row["Xuatkhosanxuatngay"] != DBNull.Value ? row["Xuatkhosanxuatngay"].ToString() : null
                            };
                            dbContex.xuatNLs.Add(xuatNL);
                        }
                        dbContex.SaveChanges();
                        MessageBox.Show("Import Data thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }

        public event NotifyCollectionChangedEventHandler? CollectionChanged;
    }
}
