using PropertyChanged;
using System.ComponentModel;

namespace WpfApp3
{

    /// <summary>
    /// a base view model that fires Property Changed event as needed
    /// </summary>
    //[AddINotifyPropertyChangedInterfaceAttribute]
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// the event that fired when any child property changes value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}