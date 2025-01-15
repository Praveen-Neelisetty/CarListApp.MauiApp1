using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarListApp.MauiApp1.ViewModels
{
    public class BaseViewModelOld : INotifyPropertyChanged
    {
        private string _title;
        private bool _isLoading;

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                if(_isLoading == value)
                    return;
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get => _title;
            set
            { 
                if(_title == value)
                    return ;
                _title = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
