using DX.Commands;
using DX.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DX.ViewModel
{
    public class AccountVM : INotifyPropertyChanged
    {
        private readonly DXSP dbContext;
        public ObservableCollection<Account> Accounts { get; set; }
        private string  username;
        public string  Username
        {
            get { return username; }
            set 
            { 
                username = value; 
                OnPropertyChanged(nameof(Username));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private int type;
        public int Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        private Account selectedAccount;

        public Account SelectedAccount
        {
            get { return selectedAccount; }
            set 
            { 
                selectedAccount = value; 
                OnPropertyChanged(nameof(SelectedAccount));
                OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(Type));

            }
        }




        public ICommand AddCommand { get; set; }
        public ICommand DelCommand { get; set; }
        public ICommand EditCommand { get; set; }


        public AccountVM()
        {
            dbContext = new DXSP();
            Accounts = new ObservableCollection<Account>(dbContext.accounts.ToList());
            AddCommand = new RelayCommand(Add);
            DelCommand = new RelayCommand(Del, CanDelete);
            EditCommand = new RelayCommand(Edit, CanEdit);
        }

        private bool CanEdit(object? obj)
        {
            throw new NotImplementedException();
        }

        private void Edit(object? obj)
        {
            throw new NotImplementedException();
        }

        private bool CanDelete(object? obj)
        {
            throw new NotImplementedException();
        }

        private void Del(object? obj)
        {
            throw new NotImplementedException();
        }

        private void Add(object? obj)
        {
            throw new NotImplementedException();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
