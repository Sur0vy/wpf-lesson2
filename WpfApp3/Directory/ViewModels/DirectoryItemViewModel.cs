using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace WpfApp3
{
    /// <summary>
    /// a view model for each directory item
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {
        #region Properties

        #endregion

        #region public comands

        /// <summary>
        /// command to expand this item
        /// </summary>
        public ICommand ExpandCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="fullPath">The full path of ttis item</param>
        /// <param name="type">The type of item</param>
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            //create command
            this.ExpandCommand = new RelayCommand(Expand);

            //setters
            this.FullPath = fullPath;
            this.Type = type;

            this.ClearChildren();
        }
        #endregion

        #region public properties
        /// <summary>
        /// item type
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// the full path to the item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// the name of this directory item
        /// </summary>
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFilderName(this.FullPath); } }

        /// <summary>
        /// the list of all children contained inside this item
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }
        
        /// <summary>
        /// indicate if this item can be expanded
        /// </summary>
        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }

        /// <summary>
        /// indicate if the current children is expand 
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return this.Children?.Count(f => f != null) > 0;
            }
            set
            {
                //if the UI tells us to expand...
                if (value == true)
                    Expand();
                else
                    this.ClearChildren();
            }
        }
        #endregion

        #region helper methods
        /// <summary>
        /// remove all children from the list
        /// </summary>
        private void ClearChildren()
        {
            //clear item
            this.Children = new ObservableCollection<DirectoryItemViewModel>();
            //show the expand arrow if we are not a file
            if (this.Type != DirectoryItemType.File)
                this.Children.Add(null);
        }
        #endregion

        /// <summary>
        /// expand this directory and find all childrens
        /// </summary>
        private void Expand()
        {
            //can't expand
            if (this.Type == DirectoryItemType.File)
                return;

            //find all children
            var children = DirectoryStructure.GetDirectoryContents(this.FullPath);
            this.Children = new ObservableCollection<DirectoryItemViewModel>(
                                children.Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));
        }
    }
}
