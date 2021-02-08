using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ui.Views
{
    /// <summary>
    /// Interaction logic for BookUserControl1.xaml
    /// </summary>
    public partial class BookUserControl1 : UserControl
    {
        public BookUserControl1()
        {
            InitializeComponent();
        }

        private BitmapImage _cover;

        public BitmapImage Cover
        {
            get { return _cover; }
            set 
            { 
                _cover = value; 
                
            }
        }

    }
}
