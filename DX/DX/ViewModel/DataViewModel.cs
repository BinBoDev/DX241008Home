using DX.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.ViewModel
{
    public class DataViewModel : INotifyCollectionChanged
    {
        private readonly DXSP dbContext;
        public ObservableCollection<Account> Accounts { get;set; }
        public DataViewModel()
        {
            dbContext = new DXSP();
            GetAccount();
        }

        public void GetAccount()
        {
            Accounts = new ObservableCollection<Account>(dbContext.accounts.ToList());
        }

        public event NotifyCollectionChangedEventHandler? CollectionChanged;
    }
}
