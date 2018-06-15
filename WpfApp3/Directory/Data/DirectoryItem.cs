namespace WpfApp3
{
    /// <summary>
    /// Information about directory item (such as drive, folder, file)
    /// </summary>
    public class DirectoryItem
    {
        /// <summary>
        /// item type
        /// </summary>
        public DirectoryItemType Type{ get; set; }

        /// <summary>
        /// absolute path to this item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// the name of this directory item
        /// </summary>
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFilderName(this.FullPath); } }
    }
}
