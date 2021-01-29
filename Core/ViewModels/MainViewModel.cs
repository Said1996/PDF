using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Core.ViewModels
{
    class MainViewModel : MvxViewModel
    {
        private uint _pageIndex;
        public uint PageIndex
        {
            get { return _pageIndex; }
            set {SetProperty(ref _pageIndex, value); }
        }

        private uint _finalPage;
        public uint FinalPage
        {
            get { return _finalPage; }
            set {SetProperty(ref _finalPage, value); }
        }



        private ICommand _nextPage;
        public ICommand NextPage
        {
            get
            {
                _nextPage = _nextPage ?? new MvxCommand(Next);
                return _nextPage;
            }
        }

        private void Next()
        {
            PageIndex += 1;
        }

        private ICommand _previousPage;
        public ICommand PreviousPage
        {
            get
            {
                _previousPage = _previousPage ?? new MvxCommand(Previous);
                return _previousPage;
            }
        }

        private void Previous()
        {
            PageIndex -= 1;
        }

        private ICommand _aboutToClose;
        public ICommand AboutToClose
        {
            get
            {
                _aboutToClose = _aboutToClose ?? new MvxCommand(Close);
                return _aboutToClose;
            }
        }

        private void Close()
        {
            Close();
        }


    }
}
