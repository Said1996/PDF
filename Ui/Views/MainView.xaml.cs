using MvvmCross.Platforms.Wpf.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        bool CanScroll = true;

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
            double Yunit = (PdfViewer.ActualHeight - ViewerScroll.ActualHeight) / MainGrid.ActualHeight;
            ViewerScroll.ScrollToVerticalOffset(Mouse.GetPosition(Application.Current.MainWindow).Y * Yunit);

            double XUnit = (PdfViewer.ActualWidth - ViewerScroll.ActualWidth) / MainGrid.ActualWidth;
            ViewerScroll.ScrollToHorizontalOffset(Mouse.GetPosition(Application.Current.MainWindow).X * XUnit);
        }

        

        private void PdfViewer_MouseLeftButtonDown_DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                Application.Current.MainWindow.DragMove();
        }

        private void PdfViewer_MouseRightButtonDown_AllowScroll(object sender, MouseButtonEventArgs e)
        {
            if (CanScroll == true)
            {
                this.PreviewMouseMove -= ScrollWithMouse;
                CanScroll = false;
            }
            else
            {
                this.PreviewMouseMove += ScrollWithMouse;
                CanScroll = true;
            }    
        }

        private void MvxWpfView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            { 
                
                ViewerScroll.ScrollToVerticalOffset(ViewerScroll.VerticalOffset - ViewerScroll.ActualHeight);
            }
            else if (e.Key == Key.S)
            {
                ViewerScroll.ScrollToVerticalOffset(ViewerScroll.VerticalOffset + ViewerScroll.ActualHeight);
            }
            else if(e.Key == Key.D)
            {
                ViewerScroll.ScrollToHorizontalOffset(ViewerScroll.HorizontalOffset + ViewerScroll.ActualWidth);
            }
            else if (e.Key == Key.A)
            {
                ViewerScroll.ScrollToHorizontalOffset(ViewerScroll.HorizontalOffset - ViewerScroll.ActualWidth);
            }

            else if (e.Key == Key.Escape)
            {
                PdfViewer.Width = MainGrid.ColumnDefinitions[1].ActualWidth * 2 + 200;
                MainGrid.ColumnDefinitions[0].Width = new GridLength(200);
                MainGrid.ColumnDefinitions[2].Width = new GridLength(200);
            }
            else if (e.Key == Key.Z)
            {
                PdfViewer.Width = ViewerScroll.ActualWidth;
            }
            else if(e.Key == Key.X)
            {
                PdfViewer.Width = (ViewerScroll.ActualHeight / PdfViewer.ActualHeight) * PdfViewer.ActualWidth;
            }
            else if(e.Key == Key.C)
            {
                MainGrid.ColumnDefinitions[0].Width = new GridLength(0);
                MainGrid.ColumnDefinitions[2].Width = new GridLength(0);
            }
        }

        private async void Zoom(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
            if (e.Delta > 0)
            {
                for (int i = 0; i < 15; i++)
                {
                    await Task.Delay(1);
                    PdfViewer.Width = PdfViewer.ActualWidth + 2;
                }
            }
            else if (e.Delta < 0)
            {
                for (int i = 0; i < 15; i++)
                {
                    if (PdfViewer.Width >= 2)
                    {
                        await Task.Delay(1);
                        PdfViewer.Width -= 2;
                    }
                }
            }
        }    
    }
}
