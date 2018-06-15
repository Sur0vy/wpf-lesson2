using System.Collections.ObjectModel;
using System.Linq;

namespace WpfApp3
{
    /// <summary>
    /// view model for the application main Directory view
    /// </summary>
    public class DirectoryStructureViewModel: BaseViewModel
    {
        #region Public properties
        /// <summary>
        /// the list of all directories on the machine
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }
        #endregion

        #region Constuctor

        /// <summary>
        /// default constructor
        /// </summary>
        public DirectoryStructureViewModel()
        {
            //get the logical drives
            var children = DirectoryStructure.GetLogicalDrives();

            //create the view model from the data
            this.Items = new ObservableCollection<DirectoryItemViewModel>(
                            children.Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive)));
        }
        #endregion
    }
}
