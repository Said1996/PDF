using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    class MainViewModel : MvxViewModel
    {
        private int _pageIndex;

        public int PageIndex
        {
            get { return _pageIndex; }
            set {SetProperty(ref _pageIndex, value); }
        }

    }
}
