using MvvmCross.Platforms.Wpf.Views;
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
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : MvxWpfView
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void Minimize(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
            
        }

        private void Maximize(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Normal)
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            else
                Application.Current.MainWindow.WindowState = WindowState.Normal;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ScrollWithMouse(object sender, MouseEventArgs e)
        {
            double Yunit = (PdfViewer.ActualHeight - ViewerScroll.ActualHeight) / ViewerScroll.ActualHeight;
            ViewerScroll.ScrollToVerticalOffset(Mouse.GetPosition(Application.Current.MainWindow).Y * Yunit);

            double XUnit = (PdfViewer.ActualWidth - ViewerScroll.ActualWidth) / ViewerScroll.ActualWidth;
            ViewerScroll.ScrollToHorizontalOffset(Mouse.GetPosition(Application.Current.MainWindow).X * XUnit);
        }


    }
}
