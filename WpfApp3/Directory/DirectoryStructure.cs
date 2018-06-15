using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WpfApp3
{
    /// <summary>
    /// helper class to query information about directory
    /// </summary>
    public static class DirectoryStructure
    {
        /// <summary>
        /// get all logical drives on the computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();

            //foreach (var drive in Directory.GetLogicalDrives())
            //{
            //    var item = new TreeViewItem()
            //    {
            //        Header = drive,
            //        Tag = drive
            //    };

            //    item.Items.Add(null);

            //    item.Expanded += Folder_Expanded;

            //    FolderView.Items.Add(item);
            //}
        }

        /// <summary>
        /// get the directory top-level content
        /// </summary>
        /// <param name="fullPath">the full path to the directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            //create empty list
            var items = new List<DirectoryItem>();

            #region get folders
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
            }
            catch {}
            //directories.ForEach(directoryPath =>
            //{
            //    var subItem = new TreeViewItem()
            //    {
            //        Header = GetFileFilderName(directoryPath),
            //        Tag = directoryPath
            //    };
            //    subItem.Items.Add(null);
            //    subItem.Expanded += Folder_Expanded;
            //    item.Items.Add(subItem);
            //});
            #endregion
            
            #region get files
            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                    items.AddRange(fs.Select(file => new DirectoryItem { FullPath = file, Type = DirectoryItemType.File }));
            }
            catch {}
            //files.ForEach(filePath =>
            //{
            //    var subItem = new TreeViewItem()
            //    {
            //        Header = GetFileFilderName(filePath),
            //        Tag = filePath
            //    };

            //    item.Items.Add(subItem);
            //});
            #endregion

            return items;
        }
        
        #region Helpers
        /// <summary>
        /// find the file or folder name from a full path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileFilderName(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            var normalizedPath = path.Replace('/', '\\');

            var lastIndex = normalizedPath.LastIndexOf('\\');

            if (lastIndex == -1)
                return path;

            return path.Substring(lastIndex + 1);
        }
        #endregion
    }
}
