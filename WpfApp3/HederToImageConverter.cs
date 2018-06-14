using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfApp3
{
    /// <summary>
    /// convert full pach to specific image
    /// </summary>
    
    [ValueConversion(typeof(string), typeof(BitmapImage))]

    public class HederToImageConverter : IValueConverter
    {
        public static HederToImageConverter Instance = new HederToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = (string)value;

            if (path == null)
                return null;

            var name = MainWindow.GetFileFilderName(path);

            string image;

            if (string.IsNullOrEmpty(name))
                image = "/Images/drive.png";
            else if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
                image = "/Images/folder.png";
            else
                image = "/Images/file.png";



            return new BitmapImage(new Uri($"pack://application:,,,{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
