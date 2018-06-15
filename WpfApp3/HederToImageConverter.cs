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
    
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]

    public class HederToImageConverter : IValueConverter
    {
        public static HederToImageConverter Instance = new HederToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            var image = "/Images/file.png";

            switch ((DirectoryItemType)value)
            {
                case DirectoryItemType.Drive:
                    image = "/Images/drive.png";
                    break;
                case DirectoryItemType.Folder:
                    image = "/Images/folder.png";
                    break;
            }

            return new BitmapImage(new Uri($"pack://application:,,,{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
