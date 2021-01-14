using System;
using System.Collections.Generic;
using System.IO;
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
using Windows.Data.Pdf;
using Windows.Storage;
using Windows.Storage.Streams;

namespace Ui.Views
{
    /// <summary>
    /// Interaction logic for PdfUserControl.xaml
    /// </summary>
    public partial class PdfUserControl : UserControl
    {

        public PdfUserControl()
        {
            InitializeComponent();
        }

        

        private bool _twoPageView;
        public bool TwoPageView
        {
            get { return _twoPageView; }
            set { _twoPageView = value; }
        }

        private bool _continuousScroll;
        public bool ContinuousScroll
        {
            get { return _continuousScroll; }
            set { _continuousScroll = value; }
        }



        private string _path;
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }


        private string _index;
        public string Index
        {
            get { return _index; }
            set 
            {   
                _index = value;
                GetPdfFileReady();
            }
        }

        async void GetPdfFileReady()
        {   if(PdfFile == null)
                PdfFile = await GetPdfFile(Path);
            Picture();
        }

        PdfDocument PdfFile { get; set; }


        async Task<PdfDocument> GetPdfFile(string path)
        {
            var file = await StorageFile.GetFileFromPathAsync(path);
            var pdfFile = await PdfDocument.LoadFromFileAsync(file);
            return pdfFile;
        }

        async void Picture()
        {
            using (var page = PdfFile.GetPage(Convert.ToUInt32(Index)))
            {
                BitmapImage bitmapImage = await PageToBitmapAsync(page);
                PdfPage.SetValue(Image.SourceProperty, bitmapImage);
                bitmapImage.Freeze();
            }
        }

        async Task<BitmapImage> PageToBitmapAsync(PdfPage page)
        {
            BitmapImage image = new BitmapImage();
            using (var stream = new InMemoryRandomAccessStream())
            {
                var options = new PdfPageRenderOptions {  };
                await page.RenderToStreamAsync(stream, options);
                image.BeginInit();
                image.StreamSource = stream.AsStream();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
            }
            image.Freeze();
            GC.Collect();

            return image;
        }
    }
}
