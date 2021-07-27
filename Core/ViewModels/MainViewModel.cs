using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Core.ViewModels
{
    class MainViewModel : MvxViewModel
    {

        public readonly INC<uint> PageIndex = new NC<uint>();

        public void NextPage()
        {
            PageIndex.Value += 1;
        }

        public void PreviousPage()
        {
            PageIndex.Value -= 1;
        }
        
       


    }
}
