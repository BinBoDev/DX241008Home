using DX.Commands;
using DX.Models;
using ExcelDataReader;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace DX.ViewModel
{
    
    public class XuatNLVM : INotifyPropertyChanged
    {
        private readonly DXSP dbContex;
        public ObservableCollection<XuatNL> XuatNLs { get; set; }
        public ObservableCollection<XuatNL> ExcelImport { get; set; }
        public ObservableCollection<XuatNL> ExcelSelected { get; set; }
        public ObservableCollection<XuatNL> ExcelShow { get; set; }

        private XuatNL selectedXuatNL;
        public XuatNL SelectedXuatNL
        {
            get { return selectedXuatNL; }
            set
            {
                selectedXuatNL = value;
                OnPropertyChanged(nameof(SelectedXuatNL));
            }
        }

        //Thuộc tính CheckBox
        private bool isSelectedRow;

        public bool IsSelectedRow
        {
            get { return isSelectedRow; }
            set
            {
                isSelectedRow = value;
                OnPropertyChanged(nameof(IsSelectedRow));
            }
        }


        //Thhuoocj tính Select Time bắt đầu
        private DateTime startDay = DateTime.Now;
        public DateTime StartDay
        {
            get { return startDay; }
            set
            {
                startDay = value;
                OnPropertyChanged(nameof(StartDay));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private DateTime endtDay = DateTime.Now;

        public DateTime EndDay
        {
            get { return endtDay; }
            set
            {
                endtDay = value;
                OnPropertyChanged(nameof(EndDay));
            }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set 
            { 
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        private int codeNL;

        public int CodeNL
        {
            get { return codeNL; }
            set
            {
                codeNL = value;
                OnPropertyChanged(nameof(CodeNL));
            }
        }
        private string tenNL;

        public string TenNL
        {
            get { return tenNL; }
            set
            {
                tenNL = value;
                OnPropertyChanged(nameof(TenNL));
            }
        }
        private int soluongxuat;

        public int Soluongxuat
        {
            get { return soluongxuat; }
            set
            {
                soluongxuat = value;
                OnPropertyChanged(nameof(Soluongxuat));
            }
        }
        private DateTime ngaygioxuatthucte;

        public DateTime Ngaygioxuatthucte
        {
            get { return ngaygioxuatthucte; }
            set
            {
                ngaygioxuatthucte = value;
                OnPropertyChanged(nameof(Ngaygioxuatthucte));
            }
        }
        private string kehoachThangNam;

        public string KehoachThangNam
        {
            get { return kehoachThangNam; }
            set
            {
                kehoachThangNam = value;
                OnPropertyChanged(nameof(KehoachThangNam));
            }
        }
        private string index;

        public string Index
        {
            get { return index; }
            set
            {
                index = value;
                OnPropertyChanged(nameof(Index));
            }
        }
        private string xuatkhosanxuatngay;

        public event PropertyChangedEventHandler? PropertyChanged;
        

        public string Xuatkhosanxuatngay
        {
            get { return xuatkhosanxuatngay; }
            set
            {
                xuatkhosanxuatngay = value;
                OnPropertyChanged(nameof(Xuatkhosanxuatngay));
            }
        }
        //public event PropertyChangedEventHandler? PropertyChanged;
        //private void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        public ICommand ImportCommand { get; set; }
        public ICommand FillDataCammand {  get; set; }
        public ICommand ShowExcelCommand { get; set; }
        public ICommand IsCheckCommand { get; set; }
        public ICommand UpDateDataGrig {  get; set; }
        public ICommand UnCheckCommand { get; set; }
        public ICommand DelItem { get; set; }
        public XuatNLVM()
        {
            dbContex = new DXSP();
            ImportCommand = new RelayCommand(Importcmd);
            FillDataCammand = new RelayCommand(Filted);
            ShowExcelCommand = new RelayCommand(ShowExcel);
            IsCheckCommand = new RelayCommand(IsCheckRow, CanCheck);
            UpDateDataGrig = new RelayCommand(UpDateData,CanUpdateData);
            DelItem = new RelayCommand(DelSelecedtItem, CanDelItem);
            XuatNLs = new ObservableCollection<XuatNL>(dbContex.xuatNLs.ToList());
            ExcelShow = new ObservableCollection<XuatNL>();//Dòng này có ý nghĩa khởi tạo giá trị
            ExcelSelected = new ObservableCollection<XuatNL>();
        }

        private bool CanDelItem(object? obj)
        {
            return IsSelectedRow != null;  
        }

        private void DelSelecedtItem(object? obj)
        {
           
        }

        private bool CanUpdateData(object? obj)
        {
            return ExcelSelected.Count > 0;
        }

        private void UnCheckRow(object? obj)
        {   
            if(SelectedXuatNL != null)
            {
                ExcelSelected.Remove(selectedXuatNL);
            }    
            
        }

        private bool CanCheck(object? obj)
        {
            return SelectedXuatNL != null;
        }

        private void UpDateData(object? obj)
        {
            dbContex.xuatNLs.AddRange(ExcelSelected);
            dbContex.SaveChanges();
            MessageBox.Show("Cập nhật thành công!");
            XuatNLs = new ObservableCollection<XuatNL>(dbContex.xuatNLs.ToList());
            OnPropertyChanged(nameof(XuatNLs));
        }

        private void Checkcmd(object? obj)
        {
            MessageBox.Show($"{ExcelSelected.Count}");
        }

        private void IsCheckRow(object? obj)
        {
            ExcelSelected.Add(selectedXuatNL);
            //SelectedXuatNL = null;
        }

        private void ShowExcel(object? obj)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn file Excel";
            openFileDialog.Filter = "Excel Files (*.xlsx;*.xls)|*.xlsx;*.xls";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var filePath = openFileDialog.FileName;

                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = _ => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                        });

                        var dataTable = dataSet.Tables[0];

                        foreach (DataRow row in dataTable.Rows)
                        {

                            var excelFile = new XuatNL()
                            {
                                CodeNL = row["Code NL"] != DBNull.Value ? Convert.ToInt32(row["Code NL"]) : 0,
                                TenNL = row["Ten NL"].ToString(),
                                Soluongxuat = row["So luong xuat"] != DBNull.Value ? Convert.ToInt32(row["So luong xuat"]) : 0,
                                Ngaygioxuatthucte = Convert.ToDateTime(row["Ngay gio xuat thuc te"]),
                                KehoachThangNam = row["KH thang nam"].ToString(),
                                Index = row["Index"].ToString(),
                                Xuatkhosanxuatngay = row["Xuat kho cho SX ngay"]?.ToString()
                            };

                            ExcelShow.Add(excelFile);
                        }
                        ExcelShow = new ObservableCollection<XuatNL>(ExcelShow);
                        MessageBox.Show("Import dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void Filted(object? obj)
        {
            var dbContex = new DXSP();
            if(StartDay <= EndDay )
            {
                var filteredList = dbContex.xuatNLs.
                    Where(x => ((x.Ngaygioxuatthucte.Date >= StartDay.Date) && (x.Ngaygioxuatthucte.Date <= EndDay.Date ))).ToList();
                //XuatNLs = new ObservableCollection<XuatNL>(filteredList);
                if (filteredList.Any())
                {
                    // Cập nhật XuatNLs và thông báo thay đổi
                    XuatNLs.Clear();
                    foreach (var item in filteredList)
                    {
                        XuatNLs.Add(item);
                    }
                    //Thăm dò quá trình
                    //MessageBox.Show("Lọc OK");
                    //OnPropertyChanged(nameof(XuatNLs));
                    //KHông được tạo mới
                    //XuatNLs = new ObservableCollection<XuatNL>(XuatNLs);

                }
                else
                {
                    MessageBox.Show("Không có dữ liệu nào phù hợp với ngày đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Quay lại danh sách gốc nếu cần
                    //XuatNLs.Clear();
                    //foreach (var item in dbContex.xuatNLs.ToList())
                    //{
                    //    XuatNLs.Add(item);
                    //}
                    //OnPropertyChanged(nameof(XuatNLs));
                }
                //Thăm dò quá trình
                //MessageBox.Show("Không vào đây");
            }
            else
            {
                MessageBox.Show("Ngày bắt đầu nhỏ hơn ngày kết thúc!", "Lỗi chọn ngày", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        //Một cách xem các cột đang chứa cái gì
                        //foreach (DataColumn column in dataTable.Columns)
                        //{
                        //    //Console.WriteLine(column.ColumnName); 
                        //    MessageBox.Show(column.ColumnName);
                        //}
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var xuatNL = new XuatNL()
                            {
                                CodeNL = row["Code NL"] != DBNull.Value ? Convert.ToInt32(row["Code NL"]) : throw new Exception("CodeNL không được trống"),
                                TenNL = row["Ten NL"].ToString(),
                                Soluongxuat = row["So luong xuat"] != DBNull.Value ? Convert.ToInt32(row["So luong xuat"]) : 0,
                                Ngaygioxuatthucte = Convert.ToDateTime(row["Ngay gio xuat thuc te"]),
                                KehoachThangNam = row["KH thang nam"].ToString(),
                                Index = row["Index"].ToString(),
                                Xuatkhosanxuatngay = row["Xuat kho cho SX ngay"] != DBNull.Value ? row["Xuat kho cho SX ngay"].ToString() : null
                            };
                            dbContex.xuatNLs.Add(xuatNL);
                        }
                        dbContex.SaveChanges();
                        MessageBox.Show("Import Data thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //XuatNLs = new ObservableCollection<XuatNL>(dbContex.xuatNLs.ToList());
                    }
                }
            }

        }

        //public event NotifyCollectionChangedEventHandler? CollectionChanged;
    }
}
