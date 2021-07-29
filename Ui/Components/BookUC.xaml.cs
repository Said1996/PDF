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
    public partial class BookUC : UserControl
    {
        public BookUC()
        {
            InitializeComponent();
        }



        public Book StoredBook
        {
            get { return (Book)GetValue(StoredBookProperty); }
            set { SetValue(StoredBookProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StoredBook.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StoredBookProperty =
            DependencyProperty.Register("StoredBook", typeof(Book), typeof(ownerclass), new PropertyMetadata(0));



    }
}
